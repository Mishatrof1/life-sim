using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.Education;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;

namespace Systems
{
    public class OccupationSelection : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<OccupationSelected> _occupationSelectedFilter;
        private EcsFilter<OrganizationComponent> _organizationsFilter;
        private EcsFilter<CharacterComponent, ChangeOccupation> _changeOccupationFilter;
        private EcsFilter<BlockComponent, Active> _navigationFilter;
        
        private PopupViewManager _popupViewManager;

        private EducationType? _selectionProcess;
        
        public void Run()
        {
            foreach (var i in _occupationSelectedFilter)
            {
                var entity = _occupationSelectedFilter.GetEntity(i);
                var occupationSelectedComp = _occupationSelectedFilter.Get1(i);
                switch (occupationSelectedComp.Type)
                {
                    case OccupationSelectionType.Skip:
                    {
                        ChangeOccupation(null, occupationSelectedComp.CharacterId);
                        break;
                    }
                    case OccupationSelectionType.College:
                    {
                        var service = FindEducationServiceByType(EducationType.CommunityCollege);
                        ChangeOccupation(service, occupationSelectedComp.CharacterId);
                        _world.NewEntity().Replace(new ShowPopup
                        {
                            PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                            {
                                HeaderText = LocalizationDictionary.GetLocalizedString("occupation_college"),
                                ContentText = $"{LocalizationDictionary.GetLocalizedString("occupation_change")} {service.Type}",
                                ActionsSettings = new List<ActionButtonSettings>
                                {
                                    new ActionButtonSettings
                                    {
                                        Title = LocalizationDictionary.GetLocalizedString("ok"),
                                        Action = () =>
                                        {
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                            _world.NewEntity().Replace(new NavigationInstantChangePoint
                                            {
                                                NavigationElementType = NavigationElementType.CurrentOccupationScreen
                                            });
                                        }
                                    }
                                }
                            })
                        });
                        break;
                    }
                    case OccupationSelectionType.University:
                    {
                        var service = FindEducationServiceByType(EducationType.University);
                        ChangeOccupation(service, occupationSelectedComp.CharacterId);
                        _world.NewEntity().Replace(new ShowPopup
                        {
                            PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                            {
                                HeaderText = LocalizationDictionary.GetLocalizedString("occupation_university"),
                                ContentText = $"{LocalizationDictionary.GetLocalizedString("occupation_change")} {service.Type}",
                                ActionsSettings = new List<ActionButtonSettings>
                                {
                                    new ActionButtonSettings
                                    {
                                        Title = LocalizationDictionary.GetLocalizedString("ok"),
                                        Action = () =>
                                        {
                                            _world.NewEntity().Replace(new HideCurrentPopup());
                                            _world.NewEntity().Replace(new NavigationInstantChangePoint
                                            {
                                                NavigationElementType = NavigationElementType.CurrentOccupationScreen
                                            });
                                        }
                                    }
                                }
                            })
                        });
                        break;
                    }
                    case OccupationSelectionType.Job:
                    {
                        ChangeOccupation(null, occupationSelectedComp.CharacterId);
                        _world.NewEntity().Replace(new NavigationInstantChangePoint
                        {
                            NavigationElementType = NavigationElementType.FindJobScreen
                        });
                        break;
                    }
                    case OccupationSelectionType.Army:
                        {
                            ChangeOccupation(null, occupationSelectedComp.CharacterId);
                            _world.NewEntity().Replace(new NavigationInstantChangePoint
                            {
                                NavigationElementType = NavigationElementType.FindJobScreen
                            });
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _selectionProcess = null;
                entity.Del<OccupationSelected>();
            }
            
            if (_selectionProcess.HasValue || !_changeOccupationFilter.IsEmpty())
                return;
            
            foreach (var i in _characterFilter)
            {
                var entity = _characterFilter.GetEntity(i);
                var character = entity.Get<CharacterComponent>().Character;

                if (character.CurrentOccupation is EducationService educationService)
                {
                    var educationPeriod =
                        character.OccupationHistory.First(pair => ReferenceEquals(educationService, pair.Key)).Value;
                    var educationDuration = WorldDateModule.CurrentDate - educationPeriod.StartDate;

                    if (educationDuration.TotalMonths == educationService.DurationMonths)
                    {
                        switch (educationService.Type)
                        {
                            case EducationType.HighSchool:
                            {
                                _selectionProcess = educationService.Type;
                                _world.NewEntity().Replace(new ShowPopup
                                {
                                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                    {
                                        HeaderText = LocalizationDictionary.GetLocalizedString("occupation_end_school"),
                                        ContentText = LocalizationDictionary.GetLocalizedString("occupation_end_whats_next"),
                                        ActionsSettings = new List<ActionButtonSettings>
                                        {
                                            CollegeButtonSettings(character.Id),
                                            UniversityButtonSettings(character.Id),
                                            JobButtonSettings(character.Id),
                                            SkipButtonSettings(character.Id)
                                        }
                                    })
                                });
                                break;
                            }
                            case EducationType.CommunityCollege:
                            {
                                _selectionProcess = educationService.Type;
                                _world.NewEntity().Replace(new ShowPopup
                                {
                                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                    {
                                        HeaderText = LocalizationDictionary.GetLocalizedString("occupation_end_college"),
                                        ContentText = LocalizationDictionary.GetLocalizedString("occupation_end_whats_next"),
                                        ActionsSettings = new List<ActionButtonSettings>
                                        {
                                            UniversityButtonSettings(character.Id),
                                            JobButtonSettings(character.Id),
                                            SkipButtonSettings(character.Id)
                                        }
                                    })
                                });
                                break;
                            }
                            case EducationType.University:
                            {
                                _selectionProcess = educationService.Type;
                                _world.NewEntity().Replace(new ShowPopup
                                {
                                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                    {
                                        HeaderText = LocalizationDictionary.GetLocalizedString("occupation_end_university"),
                                        ContentText = LocalizationDictionary.GetLocalizedString("occupation_end_whats_next"),
                                        ActionsSettings = new List<ActionButtonSettings>
                                        {
                                            JobButtonSettings(character.Id),
                                            SkipButtonSettings(character.Id)
                                        }
                                    })
                                });
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void ChangeOccupation(MainOccupation service, string characterId)
        {
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                if (character.Id == characterId)
                {
                    _characterFilter.GetEntity(i).Replace(new ChangeOccupation {Service = service});
                }
            }
        }
        
        private ActionButtonSettings CollegeButtonSettings(string characterId)
        {
            return new ActionButtonSettings
            {
                Title = LocalizationDictionary.GetLocalizedString("occupation_end_goto_college"),
                Action = () =>
                {
                    _world.NewEntity().Replace(new HideCurrentPopup());
                    _world.NewEntity().Replace(new OccupationSelected
                    {
                        CharacterId = characterId,
                        Type = OccupationSelectionType.College
                    });
                }
            };
        }
        
        private ActionButtonSettings UniversityButtonSettings(string characterId)
        {
            return new ActionButtonSettings
            {
                Title = LocalizationDictionary.GetLocalizedString("occupation_end_goto_university"),
                Action = () =>
                {
                    _world.NewEntity().Replace(new HideCurrentPopup());
                    _world.NewEntity().Replace(new OccupationSelected
                    {
                        CharacterId = characterId,
                        Type = OccupationSelectionType.University
                    });
                }
            };
        }
        
        private ActionButtonSettings JobButtonSettings(string characterId)
        {
            return new ActionButtonSettings
            {
                Title = LocalizationDictionary.GetLocalizedString("occupation_end_goto_job"),
                Action = () =>
                {
                    _world.NewEntity().Replace(new HideCurrentPopup());
                    _world.NewEntity().Replace(new OccupationSelected
                    {
                        CharacterId = characterId,
                        Type = OccupationSelectionType.Job
                    });
                }
            };
        }
        
        private ActionButtonSettings SkipButtonSettings(string characterId)
        {
            return new ActionButtonSettings
            {
                Title = LocalizationDictionary.GetLocalizedString("occupation_end_take_time"),
                Action = () =>
                {
                    _world.NewEntity().Replace(new HideCurrentPopup());
                    _world.NewEntity().Replace(new OccupationSelected
                    {
                        CharacterId = characterId,
                        Type = OccupationSelectionType.Skip
                    });
                }
            };
        }
        
        private EducationService FindEducationServiceByType(EducationType educationType)
        {
            foreach (var i in _organizationsFilter)
            {
                var organization = _organizationsFilter.Get1(i).Organization;
                var service = organization.Services.FirstOrDefault(s =>
                    s is EducationService educationService &&
                    educationService.Type == educationType);

                if (service != null)
                {
                    return service as EducationService;
                }
            }

            throw new Exception($"Not found education service of type {educationType}");
        }
    }
}