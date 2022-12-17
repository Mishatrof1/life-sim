using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;
using Settings.Job;

namespace Core.Job
{
    public class Vacancy : INavigationElement
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<CharacterComponent> _characterFilter;

        public Organization Organization { get; }
        public Position Position { get; set; }
        
        public Vacancy(EcsWorld world, EcsFilter<CharacterComponent> characterFilter, Organization organization)
        {
            _world = world;
            _characterFilter = characterFilter;
            Organization = organization;
        }

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.Vacancy
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return false;
        }
        
        public bool CanDisplay(NavigationElementType elementType)
        {
            return elementType == NavigationElementType.Vacancy;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            foreach (var i in _characterFilter)
            {
                var text = "";
                var buttonSettings = new ActionButtonSettings();
                if (_characterFilter.Get1(i).Character.CheckForPositionRequirements(Position))
                {
                    text = $"{LocalizationDictionary.GetLocalizedString("vacancy_hired")} {Position.Title}";
                    buttonSettings = new ActionButtonSettings
                    {
                        Title = LocalizationDictionary.GetLocalizedString("ok"),
                        Action = () =>
                        {
                            _world.NewEntity().Replace(new GetJobSuccess {Vacancy = this});
                            _world.NewEntity().Replace(new HideCurrentPopup());
                        }
                    };
                }
                else
                {
                    text = $"{LocalizationDictionary.GetLocalizedString("vacancy_reject")} {Position.Title}";
                    buttonSettings = new ActionButtonSettings
                    {
                        Title = LocalizationDictionary.GetLocalizedString("ok"),
                        Action = () =>
                        {
                            _world.NewEntity().Replace(new HideCurrentPopup());
                        }
                    };
                }
                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                    {
                        ContentText = text,
                        ActionsSettings = new List<ActionButtonSettings> { buttonSettings }
                    })
                }) ;
            }
            return false;
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            var button = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
            button.Title = Position.Title;
            button.Icon = Position.Icon;
            button.Description = null;
            return button;
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
        }
    }
}