using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;
using Save;
using Screens;

namespace Systems.NavigationElements
{
    public class FindJob : IEcsInitSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;

        private Dictionary<NavigationElementType, string> _popupHeaders;
        private Dictionary<NavigationElementType, string> _popupText;
        private Dictionary<NavigationElementType, string> _buttonTitles;
        private Dictionary<NavigationElementType, string> _buttonDescriptions;

        public void Init()
        {
            _navigationFilter.RegisterElement(NavigationBlockType.Main, this);

            _popupHeaders = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.SkipPartTimeWork, "Quit a part-time job"}
            };

            _popupText = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.SkipPartTimeWork, "Try to quit a part-time job"}
            };

            _buttonTitles = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.SkipPartTimeWork, "Quit a part-time job"}
            };

            _buttonDescriptions = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.SkipPartTimeWork, null}
            };
        }

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.FindPartTimeJob,
            NavigationElementType.SkipWork,
            NavigationElementType.SkipPartTimeWork

        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return false;
        }

        
        public bool CanDisplay(NavigationElementType elementType)
        {
            if (elementType == NavigationElementType.SkipPartTimeWork && _charactersFilter?.Get1(0).Character?.CurrentPartTimeOccupations != null)
            {
                return true;
            }

            if (elementType == NavigationElementType.FindJobScreen)
            {
                return true;
            }
            if (elementType == NavigationElementType.FindPartTimeJob  && _charactersFilter?.Get1(0).Character?.CurrentPartTimeOccupations == null && _charactersFilter?.Get1(0).Character?.Age.TotalYears >= 14)
            {
                return true;
            }

            return false;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            if (!Types.Contains(elementType))
                return false;

            switch (elementType)
            {
                case NavigationElementType.SkipPartTimeWork:
                    {
                        foreach (var i in _charactersFilter)
                        {
                            var character = _charactersFilter.Get1(i).Character;
                            PopupToShow popup;

                            if (character.CurrentPartTimeOccupations != null)
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = _popupText[elementType],
                                    ActionsSettings = new List<ActionButtonSettings>
                                    {
                                        new ActionButtonSettings
                                        {
                                            Title = "Ok",
                                            Action = () =>
                                            {
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                                _world.NewEntity().Replace(new NavigationHome());
                                                character.CurrentPartTimeOccupations = null;
                                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Core.Record("Я уволился с подработки"));
                                            }
                                        },
                                        new ActionButtonSettings
                                        {
                                            Title = "Отмена",
                                            Action = () =>
                                            {
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                            }
                                        }
                                    }
                                });
                                _world.NewEntity().Replace(new ShowPopup
                                {
                                    PopupToShow = popup
                                });
                            }
                        }
                        return true;
                    }
                default:
                    return true;
            }
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            var buttonData = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);

            foreach (var i in _charactersFilter)
            {
                var character = _charactersFilter.Get1(i).Character;
                
                    switch (elementType)
                    {
                        case NavigationElementType.SkipPartTimeWork:
                            {
                                buttonData.Title = _buttonTitles[elementType];
                                buttonData.Description = _buttonDescriptions[elementType];
                                break;
                            }
                    }
            }

            return buttonData;
        }


        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
        }
    }
}