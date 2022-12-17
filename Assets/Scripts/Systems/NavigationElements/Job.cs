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
    public class Job : IEcsInitSystem, IEcsRunSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<CharacterComponent, Resign> _resignFilter;
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
                {NavigationElementType.WorkHarder, LocalizationDictionary.GetLocalizedString("occupation_work_harder_pp_header")},
                {NavigationElementType.SkipWork, LocalizationDictionary.GetLocalizedString("occupation_work_chillout_pp_header")}
            };

            _popupText = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.WorkHarder, LocalizationDictionary.GetLocalizedString("occupation_work_harder_pp")},
                {NavigationElementType.SkipWork, LocalizationDictionary.GetLocalizedString("occupation_work_chillout_pp")}
            };

            _buttonTitles = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.ColleaguesDirectory, LocalizationDictionary.GetLocalizedString("occupation_colleagues_btn_title")},
                {NavigationElementType.WorkHarder, LocalizationDictionary.GetLocalizedString("occupation_work_harde_btn_title")},
                {NavigationElementType.SkipWork, LocalizationDictionary.GetLocalizedString("occupation_work_chillout_btn_title")},
                {NavigationElementType.Schedule, LocalizationDictionary.GetLocalizedString("ocuupation_schedule_btn_title")}
            };

            _buttonDescriptions = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.CurrentOccupationProfile, LocalizationDictionary.GetLocalizedString("ocuupation_profile_btn_descr")},
                {NavigationElementType.Schedule, LocalizationDictionary.GetLocalizedString("ocuupation_schedule_btn_descr")},
                {NavigationElementType.ColleaguesDirectory, null},
                {NavigationElementType.WorkHarder, null},
                {NavigationElementType.SkipWork, null}
            };

        }

        public void Run()
        {
            foreach (var i in _resignFilter)
            {
                _resignFilter.GetEntity(i).Replace(new ChangeOccupation {Service = null});
            }
        }
        
        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.CurrentOccupationScreen,
            NavigationElementType.CurrentOccupationProfile,
            NavigationElementType.Schedule,
            NavigationElementType.ColleaguesDirectory,
            NavigationElementType.Resign,
            NavigationElementType.WorkHarder,
            NavigationElementType.SkipWork
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return elementType == NavigationElementType.ColleaguesDirectory;
        }
        
        public bool CanDisplay(NavigationElementType elementType)
        {
            if (!Types.Contains(elementType))
                return false;
            
            if (elementType == NavigationElementType.CurrentOccupationScreen ||
                elementType == NavigationElementType.CurrentOccupationProfile ||
                elementType == NavigationElementType.ColleaguesDirectory ||
                elementType == NavigationElementType.Schedule ||
                elementType == NavigationElementType.Resign ||
                elementType == NavigationElementType.WorkHarder ||
                elementType == NavigationElementType.SkipWork)
            {
                foreach (var i in _charactersFilter)
                {
                    var character = _charactersFilter.Get1(i).Character;
                    if (character.CurrentOccupation is Core.SimpleWorkService)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            if (!Types.Contains(elementType))
                return false;
            
            switch (elementType)
            {
                case NavigationElementType.CurrentOccupationProfile:
                {
                    foreach (var i in _charactersFilter)
                    {
                        var character = _charactersFilter.Get1(i).Character;
                        var currentOccupation = character.CurrentOccupation;
                        var yearsInOrganization = WorldDateModule.CurrentDate.TotalYears
                                                  - character.OccupationHistory[currentOccupation].StartDate.TotalYears;
                        if (character.CurrentOccupation is Core.WorkService workService)
                        {
                            _world.NewEntity().Replace(new ShowPopup
                            {PopupToShow = new PopupToShow<OccupationPopup>(new OccupationPopup
                            {
                                IsSchool = false,
                                OrganizationNameText = workService.Organization.Name,
                                GradesSliderValue = workService.Productivity * 0.01f,
                                PopularitySliderValue = 1,
                                JobPositionText = workService.Position.Title,
                                JobSalaryText = workService.Salary.ToString("C", new CultureInfo("en-US")),
                                JobYearsInCompanyText = yearsInOrganization.ToString(),
                                JobYearsForPensionText = (20 - yearsInOrganization).ToString(),
                            })});
                        }
                        if (character.CurrentOccupation is Core.SimpleWorkService simpleWorkService)
                        {
                            _world.NewEntity().Replace(new ShowPopup
                            {PopupToShow = new PopupToShow<OccupationPopup>(new OccupationPopup
                            {
                                IsSchool = false,
                                OrganizationNameText = simpleWorkService.Organization.Name,
                                GradesSliderValue = simpleWorkService.Productivity * 0.01f,
                                PopularitySliderValue = 1,
                                JobPositionText = simpleWorkService.PositionConfiguration.NameDefault,
                                JobSalaryText = simpleWorkService.Salary.ToString("C", new CultureInfo("en-US")),
                                JobYearsInCompanyText = yearsInOrganization.ToString(),
                                JobYearsForPensionText = (20 - yearsInOrganization).ToString(),
                            })});
                        }
                    }
                    return false;
                }
                case NavigationElementType.Resign:
                {
                    foreach (var i in _charactersFilter)
                    {
                        var entity = _charactersFilter.GetEntity(i);
                        var character = _charactersFilter.Get1(i).Character;
                        if (character.CurrentOccupation is Core.WorkService || character.CurrentOccupation is Core.SimpleWorkService)
                        {
                            _world.NewEntity().Replace(new ShowPopup
                            {PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                            {
                                HeaderText = character.CurrentOccupation.Organization.Name,
                                ContentText = $"{LocalizationDictionary.GetLocalizedString("ocuupation_resign_pp")}",
                                ActionsSettings = new List<ActionButtonSettings>
                                {
                                    new ActionButtonSettings
                                    {
                                        Title = LocalizationDictionary.GetLocalizedString("yes"),
                                        Action = () =>
                                        {
                                            entity.Replace(new Resign());
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                            _world.NewEntity().Replace(new NavigationHome());
                                        }
                                    },
                                    new ActionButtonSettings
                                    {
                                        Title = LocalizationDictionary.GetLocalizedString("no"),
                                        Action = () =>
                                        {
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                        }
                                    }
                                }
                            })});
                        }
                    }
                    return false;
                }
                case NavigationElementType.Schedule:
                    return false;
                case NavigationElementType.WorkHarder:
                    {
                        foreach (var i in _charactersFilter)
                        {
                            var character = _charactersFilter.Get1(i).Character;

                            PopupToShow popup;

                            if (character.IncreaseProductivity())
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = _popupText[elementType],
                                    ActionsSettings = new List<ActionButtonSettings>
                                    {
                                        new ActionButtonSettings
                                        {
                                            Title = LocalizationDictionary.GetLocalizedString("ok"),
                                            Action = () =>
                                            {
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                                _world.NewEntity().Replace(new RefreshActionScreenButtons());
                                            }
                                        }
                                    }
                                });
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Core.Record(LocalizationDictionary.GetLocalizedString("occupation_work_harder_dyary_entry")));
                            }
                            else
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = $"({LocalizationDictionary.GetLocalizedString("occupation_work_harder_pp_cooldown")})",
                                    ActionsSettings = new List<ActionButtonSettings>
                                    {
                                        new ActionButtonSettings
                                        {
                                            Title = LocalizationDictionary.GetLocalizedString("ok"),
                                            Action = () =>
                                            {
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                            }
                                        }
                                    }
                                });
                            }

                            _world.NewEntity().Replace(new ShowPopup
                            {
                                PopupToShow = popup
                            });
                        }
                        return true;
                    }
                case NavigationElementType.SkipWork:
                    {
                        foreach (var i in _charactersFilter)
                        {
                            var character = _charactersFilter.Get1(i).Character;

                            PopupToShow popup;

                            if (character.DecreaseProductivity())
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = _popupText[elementType],
                                    ActionsSettings = new List<ActionButtonSettings>
                                    {
                                        new ActionButtonSettings
                                        {
                                            Title = LocalizationDictionary.GetLocalizedString("ok"),
                                            Action = () =>
                                            {
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                                _world.NewEntity().Replace(new RefreshActionScreenButtons());
                                            }
                                        }
                                    }
                                });
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Core.Record(LocalizationDictionary.GetLocalizedString("occupation_work_chillout_diary_entry")));
                            }
                            else
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = $"({LocalizationDictionary.GetLocalizedString("occupation_work_chillout_pp_cooldown")})",
                                    ActionsSettings = new List<ActionButtonSettings>
                                    {
                                        new ActionButtonSettings
                                        {
                                            Title = LocalizationDictionary.GetLocalizedString("ok"),
                                            Action = () =>
                                            {
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                            }
                                        }
                                    }
                                });
                            }

                            _world.NewEntity().Replace(new ShowPopup
                            {
                                PopupToShow = popup
                            });
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
                if (character.CurrentOccupation is Core.WorkService workService)
                {
                    switch (elementType)
                    {
                        case NavigationElementType.CurrentOccupationScreen:
                        case NavigationElementType.CurrentOccupationProfile:
                        {
                            buttonData.Title = workService.Position.Title;
                            buttonData.Description = null;
                            break;
                        }
                        case NavigationElementType.ColleaguesDirectory:
                        {
                            buttonData.Title = _buttonTitles[elementType];
                            buttonData.Description = _buttonDescriptions[elementType];
                            break;
                        }
                        case NavigationElementType.Schedule:
                        {
                            if (_navigationActiveFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.CurrentOccupationScreen)
                            {
                                buttonData.Title = LocalizationDictionary.GetLocalizedString("ocuupation_hours_btn_title");
                                buttonData.Description = LocalizationDictionary.GetLocalizedString("ocuupation_hours_btn_descr");
                            }
                            else
                            {
                                buttonData.Title = LocalizationDictionary.GetLocalizedString("ocuupation_schedule_btn_title");
                                buttonData.Description = LocalizationDictionary.GetLocalizedString("ocuupation_schedule_btn_descr");
                            }
                            break;
                        }
                        case NavigationElementType.WorkHarder:
                        {
                            buttonData.Title = _buttonTitles[elementType];
                            buttonData.Description = _buttonDescriptions[elementType];
                            break;
                        }
                        case NavigationElementType.SkipWork:
                        {
                            buttonData.Title = _buttonTitles[elementType];
                            buttonData.Description = _buttonDescriptions[elementType];
                            break;
                        }
                    }
                }
                if (character.CurrentOccupation is Core.SimpleWorkService simpleWorkService)
                {
                    switch (elementType)
                    {
                        case NavigationElementType.CurrentOccupationScreen:
                        case NavigationElementType.CurrentOccupationProfile:
                        {
                            buttonData.Title = simpleWorkService.PositionConfiguration.NameDefault;
                            buttonData.Description = null;
                            break;
                        }
                        case NavigationElementType.ColleaguesDirectory:
                        {
                            buttonData.Title = _buttonTitles[elementType];
                            buttonData.Description = _buttonDescriptions[elementType];
                            break;
                        }
                        case NavigationElementType.Schedule:
                        {
                            buttonData.Title = LocalizationDictionary.GetLocalizedString("ocuupation_schedule_btn_title");
                            buttonData.Description = LocalizationDictionary.GetLocalizedString("ocuupation_schedule_btn_descr");
                            buttonData.Progress = character.Parameters.Get(ParameterType.Stress.ToString()).NormalizedValue;
                            buttonData.ProgressTitle = _buttonDescriptions[elementType];
                            buttonData.SpecifyProgressColor = true;
                            buttonData.ProgressFillColorValue = (1 - character.Parameters.Get(ParameterType.Stress.ToString()).NormalizedValue);
                            break;
                        }
                        case NavigationElementType.WorkHarder:
                        {
                            buttonData.Title = _buttonTitles[elementType];
                            buttonData.Description = _buttonDescriptions[elementType];
                            break;
                        }
                        case NavigationElementType.SkipWork:
                        {
                            buttonData.Title = _buttonTitles[elementType];
                            buttonData.Description = _buttonDescriptions[elementType];
                            break;
                        }
                    }
                }
            }

            return buttonData;
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            var screenData = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
            
            foreach (var i in _charactersFilter)
            {
                var character = _charactersFilter.Get1(i).Character;
                if (character.CurrentOccupation is Core.WorkService workService)
                {
                    switch (elementType)
                    {
                        case NavigationElementType.CurrentOccupationScreen:
                        {
                            screenData.Title = workService.Position.Title;
                            break;
                        }
                        case NavigationElementType.ColleaguesDirectory:
                        {
                            screenData.Title = _buttonTitles[elementType];
                            break;
                        }
                    }
                }
                if (character.CurrentOccupation is Core.SimpleWorkService simpleWorkService)
                {
                    switch (elementType)
                    {
                        case NavigationElementType.CurrentOccupationScreen:
                        {
                            screenData.Title = simpleWorkService.PositionConfiguration.NameDefault;
                            break;
                        }
                        case NavigationElementType.ColleaguesDirectory:
                        {
                            screenData.Title = _buttonTitles[elementType];
                            break;
                        }
                    }
                }
            }

            return screenData;
        }
    }
}