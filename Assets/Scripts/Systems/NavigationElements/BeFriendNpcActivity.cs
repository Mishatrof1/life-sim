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
    public class BeFriendNpcActivity : IEcsInitSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;
        
        private BeFriendSettings _befriendSettings;
        private EmptyReactionsSettings _emptyReactionsSettings;

        public List<NavigationElementType> Types => new List<NavigationElementType> {NavigationElementType.BeFriendInteraction};

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
            if (elementType != NavigationElementType.BeFriendInteraction)
            {
                return false;
            }
            
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            if (npc?.BefriendProgress.HadFriendStatus ?? false)
                return false;
            
            if (npc?.FlirtProgress.FlirtResult > 0 && npc?.FlirtProgress.AskOutResult == 0)
                return false;

            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                if (npc.Relationships.Count != 0 &&
                    npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id) != null)
                {
                    var relation = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                    if (relation != null)
                    {
                        switch (relation.RelationshipType)
                        {
                            case RelationshipType.Mother:
                            case RelationshipType.Father:
                            case RelationshipType.Brother:
                            case RelationshipType.Sister:
                            case RelationshipType.Friend:
                            case RelationshipType.Lover:
                                return false;
                            default:
                                return false;
                        }
                    }
                }
                
                if (character.Age.TotalYears < 3)
                {
                    AddGrayButton(elementType);
                }
                else
                {
                    RemoveGrayButton(elementType);
                }
            }
            
            return true;
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
                        Communication = new BefriendCommunication(_befriendSettings, _emptyReactionsSettings)
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