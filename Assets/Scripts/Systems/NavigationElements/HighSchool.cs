using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;
using Save;
using CharacterComponent = Components.CharacterComponent;
using EducationService = Core.Education.EducationService;

namespace Systems.NavigationElements
{
    public class HighSchool : IEcsInitSystem, INavigationElement
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
                {NavigationElementType.SchoolDropOut, LocalizationDictionary.GetLocalizedString("occupation_drop_out_pp_header")},
                {NavigationElementType.SchoolFaculty, LocalizationDictionary.GetLocalizedString("occupation_school_faculty_pp_header")},
                {NavigationElementType.SchoolNurse, LocalizationDictionary.GetLocalizedString("occupation_school_nurse_pp_header")},
                {NavigationElementType.SchoolLibrary, LocalizationDictionary.GetLocalizedString("occupation_school_library_pp_header")},
                {NavigationElementType.SchoolAdministration, LocalizationDictionary.GetLocalizedString("occupation_school_administration_pp_header")},
                {NavigationElementType.SchoolStudyHarder, LocalizationDictionary.GetLocalizedString("occupation_study_harder_pp_header")},
                {NavigationElementType.SchoolSkip, LocalizationDictionary.GetLocalizedString("occupation_study_chillout_pp_header")}
            };

            _popupText = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.SchoolDropOut, LocalizationDictionary.GetLocalizedString("occupation_school_drop_out_pp")},
                {NavigationElementType.SchoolFaculty, LocalizationDictionary.GetLocalizedString("occupation_faculty_pp")},
                {NavigationElementType.SchoolNurse, LocalizationDictionary.GetLocalizedString("occupation_nurse_pp")},
                {NavigationElementType.SchoolLibrary, LocalizationDictionary.GetLocalizedString("occupation_library_pp")},
                {NavigationElementType.SchoolAdministration, LocalizationDictionary.GetLocalizedString("occupation_administration_pp")},
                {NavigationElementType.SchoolStudyHarder, LocalizationDictionary.GetLocalizedString("occupation_study_harder_pp")},
                {NavigationElementType.SchoolSkip, LocalizationDictionary.GetLocalizedString("occupation_study_chillout_pp")}
            };

            _buttonTitles = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.CurrentOccupationScreen, LocalizationDictionary.GetLocalizedString("occupation_high_school_screen_btn_title")},
                {NavigationElementType.CurrentOccupationProfile, LocalizationDictionary.GetLocalizedString("occupation_high_school_profile_btn_title")},
                {NavigationElementType.ColleaguesDirectory, LocalizationDictionary.GetLocalizedString("occupation_class_btn_title")},
                {NavigationElementType.Schedule, LocalizationDictionary.GetLocalizedString("ocuupation_schedule_btn_title")}
            };

            _buttonDescriptions = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.CurrentOccupationProfile, LocalizationDictionary.GetLocalizedString("occupation_high_school_profile_btn_descr")},
                {NavigationElementType.Schedule, LocalizationDictionary.GetLocalizedString("ocuupation_schedule_btn_descr")},
                {NavigationElementType.ColleaguesDirectory, null}
            };
        }

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.CurrentOccupationScreen,
            NavigationElementType.CurrentOccupationProfile,
            NavigationElementType.ColleaguesDirectory,
            NavigationElementType.Schedule,
            NavigationElementType.SchoolDropOut,
            NavigationElementType.SchoolFaculty,
            NavigationElementType.SchoolNurse,
            NavigationElementType.SchoolLibrary,
            NavigationElementType.SchoolAdministration,
            NavigationElementType.SchoolStudyHarder,
            NavigationElementType.SchoolSkip
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
                elementType == NavigationElementType.Schedule ||
                elementType == NavigationElementType.ColleaguesDirectory ||
                elementType == NavigationElementType.SchoolDropOut ||
                elementType == NavigationElementType.SchoolFaculty ||
                elementType == NavigationElementType.SchoolNurse ||
                elementType == NavigationElementType.SchoolLibrary ||
                elementType == NavigationElementType.SchoolAdministration ||
                elementType == NavigationElementType.SchoolStudyHarder ||
                elementType == NavigationElementType.SchoolSkip)
            {
                foreach (var i in _charactersFilter)
                {
                    var character = _charactersFilter.Get1(i).Character;
                    if (!(character.CurrentOccupation is EducationService educationService))
                        continue;
                    
                    if (educationService.Type == EducationType.HighSchool)
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
                        _world.NewEntity().Replace(new ShowPopup
                        {
                            PopupToShow = new PopupToShow<OccupationPopup>(new OccupationPopup
                            {
                                IsSchool = true,
                                OrganizationNameText = LocalizationDictionary.GetLocalizedString("occupation_high_school"),
                                SchoolYearsLeftText = (4 - yearsInOrganization).ToString(),
                                GradesSliderValue = (currentOccupation as EducationService).Productivity * 0.01f,
                                PopularitySliderValue = 1,
                            })
                        });
                    }
                    return true;
                }
                case NavigationElementType.SchoolDropOut:
                case NavigationElementType.SchoolFaculty:
                case NavigationElementType.SchoolNurse:
                case NavigationElementType.SchoolLibrary:
                case NavigationElementType.SchoolAdministration:
                    {
                        _world.NewEntity().Replace(new ShowPopup
                        {
                            PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                            {
                                HeaderText = _popupHeaders[elementType],
                                ContentText = _popupText[elementType] + $"{Environment.NewLine}({LocalizationDictionary.GetLocalizedString("work_in_progress")})",
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
                            })
                        });
                        return true;
                    }
                case NavigationElementType.SchoolStudyHarder:
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
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Core.Record(LocalizationDictionary.GetLocalizedString("occupation_study_harder_pp")));
                            }
                            else
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = LocalizationDictionary.GetLocalizedString("occupation_study_harder_pp_cooldown"),
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
                case NavigationElementType.SchoolSkip:
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
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Core.Record(LocalizationDictionary.GetLocalizedString("occupation_study_chillout_pp")));
                            }
                            else
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = LocalizationDictionary.GetLocalizedString("occupation_study_chillout_pp_cooldown"),
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
                case NavigationElementType.Schedule:
                    return false;
                default:
                    return true;
            }
        }


        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            var buttonData = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
            switch (elementType)
            {
                case NavigationElementType.CurrentOccupationScreen:
                case NavigationElementType.CurrentOccupationProfile:
                case NavigationElementType.ColleaguesDirectory:
                {
                    buttonData.Title = _buttonTitles[elementType];
                    buttonData.Description = _buttonDescriptions[elementType];
                    break;
                }
                case NavigationElementType.Schedule:
                {
                    buttonData.Title = _buttonTitles[elementType];
                    buttonData.Description = _buttonDescriptions[elementType];
                    foreach (var i in _charactersFilter)
                    {
                        var character = _charactersFilter.Get1(i).Character;
                        buttonData.Progress = character.Parameters.Get(ParameterType.Stress.ToString()).NormalizedValue;
                        buttonData.ProgressTitle = _buttonDescriptions[elementType];
                        buttonData.SpecifyProgressColor = true;
                        buttonData.ProgressFillColorValue = (1 - character.Parameters.Get(ParameterType.Stress.ToString()).NormalizedValue);
                    }
                    break;
                }
            }
            return buttonData;
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            var screenData = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
            switch (elementType)
            {
                case NavigationElementType.CurrentOccupationScreen:
                case NavigationElementType.ColleaguesDirectory:
                {
                    screenData.Title = _buttonTitles[elementType];
                    break;
                }
            }

            return screenData;
        }
    }
}