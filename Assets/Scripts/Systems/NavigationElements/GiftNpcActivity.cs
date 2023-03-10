using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.NpcCommunication;
using DialogSystem;
using Leopotam.Ecs;
using Modules.Navigation;
using Save;
using Settings.NpcCommunication;

namespace Systems.NavigationElements
{
    public class GiftNpcActivity : IEcsInitSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;

        private GiftSettings _giftSettings;
        private GiftReactionsSettings _giftReactionsSettings;

        public List<NavigationElementType> Types => new List<NavigationElementType> { NavigationElementType.GiftInteraction };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return true;
        }
        

        public void Init()
        {
            _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
            if (elementType != NavigationElementType.GiftInteraction)
            {
                return false;
            }
            
            if (_navigationActiveFilter.GetCurrentPoint().Type != NavigationElementType.NpcScreen)
            {
                return false;
            }
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            Core.Character character = null;
            foreach (var i in _characterFilter)
            {
                character = _characterFilter.Get1(i).Character;
            }
            
            if (npc.Relationships.Count != 0 &&
                npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id) != null)
            {
                RelationshipType relationship = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id).RelationshipType;
                switch (relationship)
                {
                    case RelationshipType.Mother:
                    case RelationshipType.Father:
                    case RelationshipType.Friend:
                    case RelationshipType.Lover:
                    case RelationshipType.Enemy:
                        if (character.Age.TotalYears < 8)
                        {
                            AddGrayButton(elementType);
                        }
                        else
                        {
                            RemoveGrayButton(elementType);
                        }
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                if (character.Age.TotalYears < 8)
                {
                    AddGrayButton(elementType);
                }
                else
                {
                    RemoveGrayButton(elementType);
                }
                return true;
            }
        }
        
        public void AddGrayButton(NavigationElementType elementType)
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            if (!npc.GrayButtons.Contains(elementType))
            {
                npc.GrayButtons.Add(elementType);
            }
        }
        public void RemoveGrayButton(NavigationElementType elementType)
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            if (npc.GrayButtons.Contains(elementType))
            {
                npc.GrayButtons.Remove(elementType);
            }
        }

        public bool OnClick(NavigationElementType elementType)
        {
            if (!Types.Contains(elementType))
                return false;

            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            foreach (var i in _characterFilter)
            {
                _world.NewEntity()
                    .Replace(new Components.NpcCommunication
                    {
                        Npc = npc,
                        Character = _characterFilter.Get1(i).Character,
                        Communication = new GiftCommunication(_giftSettings, _giftReactionsSettings)
                    })
                    .Replace(new New());
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
    }
}