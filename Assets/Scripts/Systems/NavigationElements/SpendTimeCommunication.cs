using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Leopotam.Ecs;
using Modules.Navigation;
using Settings.NpcCommunication;

namespace Systems.NavigationElements
{
    public class SpendTimeCommunication : INavigationElement, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;

        private SpendTimeSettings _spendTimeSettings;
        private EmptyReactionsSettings _emptyReactionsSettings;

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.SpendTimeInteraction
        };
        
        public void Init()
        {
            _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
        }

        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return true;
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
            if (!(Types.Any(t => t == elementType)))
                return false;

            if (IsInteractive())
            {
                RemoveGrayButton(elementType);
            }
            else
            {
                AddGrayButton(elementType);
            }
            
            return true;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            if (IsInteractive())
            {
                foreach (var i in _characterFilter)
                {
                    _world.NewEntity()
                        .Replace(new Components.NpcCommunication
                        {
                            Npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main),
                            Character = _characterFilter.Get1(i).Character,
                            Communication = new Core.NpcCommunication.SpendTimeCommunication(_spendTimeSettings, _emptyReactionsSettings)
                        })
                        .Replace(new New());
                }
            }
            
            return true;
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            var data = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
            data.Title = npc.FullName;
            data.Description = npc.RelationshipStatus;
            return data;
        }

        private bool IsInteractive()
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            if (npc.Age.TotalYears < 3)
                return false;

            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                if (character.Age.TotalYears < 3)
                    return false;

                var relation = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                if (relation?.RelationshipType == RelationshipType.Enemy)
                    return false;
            }

            return true;
        }
        
        private void AddGrayButton(NavigationElementType elementType)
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            if (!npc.GrayButtons.Contains(elementType))
            {
                npc.GrayButtons.Add(elementType);
            }
        }
        
        private void RemoveGrayButton(NavigationElementType elementType)
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            if (npc.GrayButtons.Contains(elementType))
            {
                npc.GrayButtons.Remove(elementType);
            }
        }
    }
}