using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Navigation;
using Core;
using DialogSystem;
using Leopotam.Ecs;
using Modules.Navigation;
using Save;

namespace Systems.NavigationElements
{
    public class FightNpcActivity : IEcsInitSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;

        public List<NavigationElementType> Types => new List<NavigationElementType> { NavigationElementType.FightInteraction };
        
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
            if (elementType != NavigationElementType.FightInteraction)
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
                    case RelationshipType.Friend:
                    case RelationshipType.Enemy:
                        if (character.Age.TotalYears < 5)
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
                if (character.Age.TotalYears < 5)
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
            // var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            // _world.NewEntity().Replace(new InkStoryComponent { StoryName = "FightInkStory", CurrentNpc = npc });
            // return true;
            return false;
        }

        
        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            return _navigationFilter.GetDefaultButtonData(NavigationBlockType.Main, elementType);
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            var data = _navigationFilter.GetDefaultScreenData(NavigationBlockType.Main, elementType);
            data.Title = npc.FullName;
            data.Description = npc.RelationshipStatus;
            return data;
        }
    }
}