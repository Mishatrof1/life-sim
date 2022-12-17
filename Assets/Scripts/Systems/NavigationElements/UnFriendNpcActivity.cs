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
using UnityEngine; 

namespace Systems.NavigationElements
{
    public class UnFriendNpcActivity : IEcsInitSystem, IEcsRunSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;
        
        private UnfriendSettings _unfriendSettings;
        private EmptyReactionsSettings _emptyReactionsSettings;

        public List<NavigationElementType> Types => new List<NavigationElementType> {NavigationElementType.UnFriendInteraction};
        
        public void Init()
        {
            _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
        }

        public void Run()
        {
        }

        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return true;
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
            if (elementType != NavigationElementType.UnFriendInteraction)
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
                var relationship = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id).RelationshipType;
                switch (relationship)
                {
                    case RelationshipType.Friend:
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool OnClick(NavigationElementType elementType)
        {
            if (!Types.Contains(elementType))
                return false;

            Core.Character character = null;
            foreach (var i in _characterFilter)
            {
                character = _characterFilter.Get1(i).Character;
            }
            
            var npc = GameProcessingEcs.Instance.CurrentNavigationBlock.GetLastElementInChain<Npc>();
            if (character != null)
            {
                _world.NewEntity()
                    .Replace(new Components.NpcCommunication
                    {
                        Npc = npc,
                        Character = character,
                        Communication = new UnFriendCommunication(_unfriendSettings, _emptyReactionsSettings)
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