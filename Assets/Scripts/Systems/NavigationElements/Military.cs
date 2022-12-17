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
    public class Military : IEcsInitSystem, IEcsRunSystem, INavigationElement
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
                {NavigationElementType.WorkHarder, "Work harder"},
                {NavigationElementType.ExtendContract, "ExtendContract"},
                {NavigationElementType.Resign, "Dischare"},
                {NavigationElementType.Desertion, "Desert"}
            };

            _popupText = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.WorkHarder, "Try to work harder"},
                 {NavigationElementType.ExtendContract, "ExtendContract"},
                    {NavigationElementType.Desertion, "Desert"},
                     {NavigationElementType.Resign, "Dischare"}
            };

            _buttonTitles = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.ColleaguesDirectory, "Co-Workers"},
                {NavigationElementType.WorkHarder, "Work harder"},
                 {NavigationElementType.ExtendContract, "ExtendContract"},
                {NavigationElementType.Desertion, "Desert"},
                 {NavigationElementType.Resign, "Dischare"},
                 {NavigationElementType.Retire, "Retire"}
            };

            _buttonDescriptions = new Dictionary<NavigationElementType, string>
            {
                {NavigationElementType.CurrentOccupationProfile, "Hours"},
                {NavigationElementType.ColleaguesDirectory, null},
                {NavigationElementType.WorkHarder, null},
                {NavigationElementType.SkipWork, null}
            };

        }

        public void Run()
        {
            foreach (var i in _resignFilter)
            {
                _resignFilter.GetEntity(i).Replace(new ChangeOccupation { Service = null });
            }
        }

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.CurrentOccupationScreen,
            NavigationElementType.CurrentOccupationProfile,
            NavigationElementType.ColleaguesDirectory,
            NavigationElementType.Resign,
            NavigationElementType.Desertion,
            NavigationElementType.WorkHarder,
            NavigationElementType.Retire,
            NavigationElementType.ExtendContract,
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
                elementType == NavigationElementType.Resign ||
                elementType == NavigationElementType.Desertion ||
                elementType == NavigationElementType.Retire ||
                elementType == NavigationElementType.WorkHarder ||
                elementType == NavigationElementType.ExtendContract)
            {
                foreach (var i in _charactersFilter)
                {
                    var character = _charactersFilter.Get1(i).Character;
                    if (character.CurrentOccupation is Core.MilitaryService)
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
                                { PopupToShow = new PopupToShow<OccupationPopup>(new OccupationPopup
                                {
                                    IsSchool = false,
                                    OrganizationNameText = workService.Organization.Name,
                                    GradesSliderValue = workService.Productivity * 0.01f,
                                    PopularitySliderValue = 1,
                                    JobPositionText = workService.Position.Title,
                                    JobSalaryText = workService.Salary.ToString("C", new CultureInfo("en-US")),
                                    JobYearsInCompanyText = yearsInOrganization.ToString(),
                                    JobYearsForPensionText = (20 - yearsInOrganization).ToString(),
                                }) });
                            }
                            if (character.CurrentOccupation is Core.MilitaryService simpleWorkService)
                            {
                                _world.NewEntity().Replace(new ShowPopup
                                { PopupToShow = new PopupToShow<OccupationPopup>(new OccupationPopup
                                {
                                    IsSchool = false,
                                    OrganizationNameText = simpleWorkService.Organization.Name,
                                    GradesSliderValue = simpleWorkService.Productivity * 0.01f,
                                    PopularitySliderValue = 1,
                                    JobPositionText = simpleWorkService.PositionConfiguration.NameDefault,
                                    JobSalaryText = simpleWorkService.Salary.ToString("C", new CultureInfo("en-US")),
                                    JobYearsInCompanyText = yearsInOrganization.ToString(),
                                    JobYearsForPensionText = (20 - yearsInOrganization).ToString(),
                                }) });
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
                            if (character.CurrentOccupation is Core.WorkService || character.CurrentOccupation is Core.MilitaryService)
                            {
                                _world.NewEntity().Replace(new ShowPopup
                                { PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = character.CurrentOccupation.Organization.Name,
                                    ContentText = $"Вы уверены, что хотите уйти с этой работы?",
                                    ActionsSettings = new List<ActionButtonSettings>
                                {
                                    new ActionButtonSettings
                                    {
                                        Title = "Да",
                                        Action = () =>
                                        {
                                            entity.Replace(new Resign());
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                            _world.NewEntity().Replace(new NavigationHome());
                                        }
                                    },
                                    new ActionButtonSettings
                                    {
                                        Title = "Нет",
                                        Action = () =>
                                        {
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                        }
                                    }
                                }
                                }) });
                            }
                        }
                        return false;
                    }
                case NavigationElementType.Desertion:
                    {
                        foreach (var i in _charactersFilter)
                        {
                            var entity = _charactersFilter.GetEntity(i);
                            var character = _charactersFilter.Get1(i).Character;
                            if (character.CurrentOccupation is Core.WorkService || character.CurrentOccupation is Core.MilitaryService)
                            {
                                _world.NewEntity().Replace(new ShowPopup
                                {
                                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                    {
                                        HeaderText = character.CurrentOccupation.Organization.Name,
                                        ContentText = $"Вы уверены, что хотите дезертировать?",
                                        ActionsSettings = new List<ActionButtonSettings>
                                {
                                    new ActionButtonSettings
                                    {
                                        Title = "Да",
                                        Action = () =>
                                        {
                                           
                                            Desert(character);
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                            _world.NewEntity().Replace(new NavigationHome());
                                        }
                                    },
                                    new ActionButtonSettings
                                    {
                                        Title = "Нет",
                                        Action = () =>
                                        {
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                        }
                                    }
                                }
                                    })
                                });
                            }
                        }
                        return false;
                    }
                case NavigationElementType.Retire:
                    {
                        foreach (var i in _charactersFilter)
                        {
                            var entity = _charactersFilter.GetEntity(i);
                            var character = _charactersFilter.Get1(i).Character;
                            if (character.CurrentOccupation is Core.WorkService || character.CurrentOccupation is Core.MilitaryService)
                            {
                                _world.NewEntity().Replace(new ShowPopup
                                {
                                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                    {
                                        HeaderText = character.CurrentOccupation.Organization.Name,
                                        ContentText = $"Вы уверены, что хотите  выйти на пенсию?",
                                        ActionsSettings = new List<ActionButtonSettings>
                                {
                                    new ActionButtonSettings
                                    {
                                        Title = "Да",
                                        Action = () =>
                                        {
                                            entity.Replace(new Resign());
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                            _world.NewEntity().Replace(new NavigationHome());
                                        }
                                    },
                                    new ActionButtonSettings
                                    {
                                        Title = "Нет",
                                        Action = () =>
                                        {
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                        }
                                    }
                                }
                                    })
                                });
                            }
                        }
                        return false;
                    }
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
                                            Title = "Ok",
                                            Action = () =>
                                            {
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                            }
                                        }
                                    }
                                });
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Core.Record("ты уже хорошо потрудился на славу родине"));
                            }
                            else
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = "(Ты уже хорошо потрудился на славу родине)",
                                    ActionsSettings = new List<ActionButtonSettings>
                                    {
                                        new ActionButtonSettings
                                        {
                                            Title = "Ok",
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
                                            Title = "Ok",
                                            Action = () =>
                                            {
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                            }
                                        }
                                    }
                                });
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Core.Record("Отдохнул от работы"));
                            }
                            else
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = "(много прогулов)",
                                    ActionsSettings = new List<ActionButtonSettings>
                                    {
                                        new ActionButtonSettings
                                        {
                                            Title = "Ok",
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
                case NavigationElementType.ExtendContract:
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
                                            Title = "Ok",
                                            Action = () =>
                                            {
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                            }
                                        }
                                    }
                                });
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Core.Record("ты уже хорошо потрудился на славу родине"));
                            }
                            else
                            {
                                popup = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = _popupHeaders[elementType],
                                    ContentText = "(Ты уже хорошо потрудился на славу родине)",
                                    ActionsSettings = new List<ActionButtonSettings>
                                    {
                                        new ActionButtonSettings
                                        {
                                            Title = "Ok",
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
                                    buttonData.Title = "Hours";
                                    buttonData.Description = "Adjust your weekly hours";
                                }
                                else
                                {
                                    buttonData.Title = "Schedule";
                                    buttonData.Description = "Stress";
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
                if (character.CurrentOccupation is Core.MilitaryService simpleWorkService)
                {
                    var entity = _charactersFilter.GetEntity(i);

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

                        case NavigationElementType.WorkHarder:
                            {
                                buttonData.Title = _buttonTitles[elementType];
                                buttonData.Description = _buttonDescriptions[elementType];
                                break;
                            }

                        case NavigationElementType.ExtendContract:
                            {
                                if (character.OccupationHistory[character.CurrentOccupation].Duration.TotalYears < 4)
                                    buttonData.EnableState = true;
                                else
                                    buttonData.EnableState = false;
                                break;
                            }
                        case NavigationElementType.Resign: // Увольнение
                            {

                                buttonData.Title = _buttonTitles[elementType];
                                if (character.OccupationHistory[character.CurrentOccupation].Duration.TotalYears < 2)
                                    buttonData.EnableState = true;
                                else

                                    buttonData.EnableState = false;
                                break;
                            }
                        case NavigationElementType.Desertion: // дезертирство
                            {
                                buttonData.Title = _buttonTitles[elementType];
                                
                                break;
                            }
                        case NavigationElementType.Retire: // пенсия
                            {
                                if (character.OccupationHistory[character.CurrentOccupation].Duration.TotalYears < 20)
                                    buttonData.EnableState = true;
                                else
                                    buttonData.EnableState = false;
                                buttonData.Title = _buttonTitles[elementType];
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
                if (character.CurrentOccupation is Core.MilitaryService simpleWorkService)
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
        void Desert(Core.Character character)
        {
            Random a = new Random();
           var Rnd = a.Next(0, 4);
            switch (Rnd)
            {
                case 0:
                case 1:
                   var actions1 = new List<ActionButtonSettings>
                    {
                        new ActionButtonSettings
                           {
                             Title = "Ok",
                             Action = () =>
                              {
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                 character.OutOccupation = character.CurrentOccupation;
                                  Resign();
                                 character.CurrentOccupation = character.OutOccupation;
                              }
                           }
                    };
                    _world.NewEntity().Replace(new ShowPopup
                    {
                        PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                        {
                            HeaderText = "Вы успешно сбежали!",
                            ContentText = "Но вас ищут и скоро найдут!",
                            ActionsSettings = actions1,
                        })
                    }); ;
                    break;
                case 2:
                    var actions2 = new List<ActionButtonSettings>
                    {
                        new ActionButtonSettings
                           {
                             Title = "Ok",
                             Action = () =>
                              {
                                  _world.NewEntity().Replace(new HideCurrentPopup());
                                  Resign();
                                
                              }
                           }
                    };
                    _world.NewEntity().Replace(new ShowPopup
                    {
                        PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                        {
                            HeaderText = "Вы успешно сбежали!",
                            ContentText = "Молодцы!",
                            ActionsSettings = actions2,
                        })
                    }); ;
                    break;
                case 3:

                    var actions3 = new List<ActionButtonSettings>
                    {
                        new ActionButtonSettings
                           {
                             Title = "Ok",
                             Action = () =>
                              {
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                              }
                           }
                    };
                    _world.NewEntity().Replace(new ShowPopup
                    {
                        PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                        {
                            HeaderText = "Вы не смогли сбежать!",
                            ContentText = "Вас поймали!",
                            ActionsSettings = actions3,
                        })
                    }); ;
                  
            
            break;
            }
        }
        

        void Resign()
        {
            foreach (var i in _charactersFilter)
            {
                var entity = _charactersFilter.GetEntity(i);
           
               
                 entity.Replace(new Resign());
                                     
                
            }
        }

       

       
    }

    
}


/*
        при desert 
            25% - success 
            50% - гуляешь 1-2 года потом обратно
            25% - ничего не происходит неудача.
 */