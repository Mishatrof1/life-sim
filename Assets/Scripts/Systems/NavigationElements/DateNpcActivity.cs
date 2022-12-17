using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.NpcCommunication;
using Leopotam.Ecs;
using Modules.Navigation;
using Settings.NpcCommunication;

namespace Systems.NavigationElements
{
    public class DateNpcActivity : IEcsInitSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;

        private DateSettings _dateSettings;
        private ReactionsSettings _reactionsSettings;

        public void Init()
        {
            _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
        }

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.DateInteraction
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return true;
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
            if (!Types.Contains(elementType))
                return false;

            Core.Character character = null;
            foreach (var i in _characterFilter)
            {
                character = _characterFilter.Get1(i).Character;
            }
            
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            var relationship = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
            if (relationship != null && relationship.RelationshipType == RelationshipType.Lover)
            {
                return false;
            }
            return npc?.FlirtProgress.FlirtResult > 0 && npc?.FlirtProgress.AskOutResult == 0;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            if (!Types.Contains(elementType))
                return false;

            foreach (var i in _characterFilter)
            {
                _world.NewEntity()
                    .Replace(new Components.NpcCommunication
                    {
                        Npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main),
                        Character = _characterFilter.Get1(i).Character,
                        Communication = new DateCommunication(_dateSettings, _reactionsSettings)
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