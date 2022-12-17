using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Screen;
using Core;
using Core.Education;
using Core.Job;
using Core.Job.Simple;
using Extensions;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;
using Settings;
using Settings.Education;
using UnityEngine;
using CharacterComponent = Components.CharacterComponent;

namespace Systems
{
    public class Education : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<Created, CharacterComponent> _characterCreatedFilter;
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
        private EcsFilter<LocationComponent, NewLocation> _newLocationFilter;
        private EcsFilter<CharacterComponent, FirstToCollege> _firstToCollegeEvent;
        private EcsFilter<CharacterComponent, FirstToUniversity> _firstToUnivercityEvent;
        private EcsFilter<OrganizationComponent> _organizationsFilter;
        private EcsFilter<StudyDirectionSelected> _studyDirectionSelectedEvent;
        private EcsFilter<ScreenComponent> _screenFilter;

        private PopupViewManager _popupViewManger;
        private StudyDirectionSettings _studyDirectionSettings;
        private GradeConfiguration _gradeConfiguration;
        private WorldGenerator _worldGenerator;

        private bool _directionSelectionProcess = false;

        public void Run()
        {
            if (!_characterCreatedFilter.IsEmpty())
            {
                foreach (var i in _organizationsFilter)
                {
                    var organization = _organizationsFilter.Get1(i).Organization;
                    if (organization.Services.Any(s => s is EducationService))
                    {
                        _organizationsFilter.GetEntity(i).Destroy();
                    }
                }
            }
            
            foreach (var i in _newLocationFilter)
            {
                var newLocation = _newLocationFilter.Get1(i).Location;
                {
                    // Elementary school
                    var organizationId = Guid.NewGuid().ToString();
                    var elementarySchool = new Core.Organization(organizationId)
                    {
                        Name = LocalizationDictionary.GetLocalizedString("occupation_elementary_school"),
                        Location = newLocation,
                        Type = OrganizationType.Unknown,
                        ScopeType = ScopeType.Education
                    };
                    EducationService service = _worldGenerator.GenerateEducationService(EducationType.PrimarySchool);

                    service.HoursPerWeek = 30;

                    elementarySchool.AddService(service);
                    _world.NewEntity()
                        .Replace(new OrganizationComponent { Organization = elementarySchool });
                }
                {
                    // Middle school
                    var organizationId = Guid.NewGuid().ToString();
                    var middleSchool = new Core.Organization(organizationId)
                    {
                        Name = LocalizationDictionary.GetLocalizedString("occupation_middle_school"),
                        Location = newLocation,
                        Type = OrganizationType.Unknown,
                        ScopeType = ScopeType.Education
                    };
                    EducationService service = _worldGenerator.GenerateEducationService(EducationType.MiddleSchool);

                    service.HoursPerWeek = 30;

                    middleSchool.AddService(service);
                    _world.NewEntity()
                        .Replace(new OrganizationComponent { Organization = middleSchool });
                }
                {
                    // High school
                    var organizationId = Guid.NewGuid().ToString();
                    var highSchool = new Core.Organization(organizationId)
                    {
                        Name = LocalizationDictionary.GetLocalizedString("occupation_high_school"),
                        Location = newLocation,
                        Type = OrganizationType.Unknown,
                        ScopeType = ScopeType.Education
                    };
                    EducationService service = _worldGenerator.GenerateEducationService(EducationType.HighSchool);

                    service.HoursPerWeek = 30;

                    highSchool.AddService(service);
                    _world.NewEntity()
                        .Replace(new OrganizationComponent { Organization = highSchool });
                }
                {
                    // Community college
                    var organizationId = Guid.NewGuid().ToString();
                    var communityCollege = new Organization(organizationId)
                    {
                        Name = LocalizationDictionary.GetLocalizedString("occupation_college"),
                        Location = newLocation,
                        Type = OrganizationType.Unknown,
                        ScopeType = ScopeType.Education
                    };
                    EducationService service = _worldGenerator.GenerateEducationService(EducationType.CommunityCollege);

                    service.HoursPerWeek = 35;

                    communityCollege.AddService(service);
                    _world.NewEntity()
                        .Replace(new OrganizationComponent { Organization = communityCollege });
                }
                {
                    // University
                    var organizationId = Guid.NewGuid().ToString();
                    var university = new Organization(organizationId)
                    {
                        Name = LocalizationDictionary.GetLocalizedString("occupation_university"),
                        Location = newLocation,
                        Type = OrganizationType.Unknown,
                        ScopeType = ScopeType.Education
                    };
                    EducationService service = _worldGenerator.GenerateEducationService(EducationType.University);

                    service.HoursPerWeek = 40;

                    university.AddService(service);
                    _world.NewEntity()
                        .Replace(new OrganizationComponent { Organization = university });
                }
            }

            foreach (var eventIndex in _studyDirectionSelectedEvent)
            {
                var eventData = _studyDirectionSelectedEvent.Get1(eventIndex);
                foreach (var i in _organizationsFilter)
                {
                    var organization = _organizationsFilter.Get1(i).Organization;
                    var service = organization.Services.FirstOrDefault(s => s is EducationService && s.Id == eventData.Service.Id);
                    if (service == null)
                        continue;

                    var educationService = (EducationService)service;
                    educationService.SetStudyDirection(eventData.StudyDirection);
                    _directionSelectionProcess = false;
                }
            }

            foreach (var i in _characterFilter)
            {
                var entity = _characterFilter.GetEntity(i);
                var character = entity.Get<CharacterComponent>().Character;

                if (character.CurrentOccupation is EducationService educationService)
                {
                    if (educationService.Type == EducationType.University)
                    {
                        var timeLeft = WorldDateModule.CurrentDate -
                                       character.OccupationHistory[educationService].StartDate;
                        
                        if ((WorldDate.FromMonths(educationService.DurationMonths) - timeLeft).TotalYears == 2 &&
                            educationService.StudyDirection == null &&
                            !_directionSelectionProcess)
                        {
                            _directionSelectionProcess = true;
                            var studyDirections = _studyDirectionSettings.GetStudyDirections();

                            _world.NewEntity().Replace(new ShowPopup
                            {
                                PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                                {
                                    HeaderText = LocalizationDictionary.GetLocalizedString("occupation_university"),
                                    ContentText = LocalizationDictionary.GetLocalizedString("occupation_university_grade_choose"),
                                    DropdownSettings = studyDirections.Select(sd => sd.Name).ToList(),
                                    ActionsSettings = new List<ActionButtonSettings>
                                    {
                                        new ActionButtonSettings
                                        {
                                            Title = LocalizationDictionary.GetLocalizedString("ok"),
                                            ActionWithInstance = (popup) =>
                                            {
                                                var nonHeaderPopup = (NonHeaderPopupView) popup;
                                                var studyDirection = _studyDirectionSettings.GetStudyDirections()
                                                    .First(sd => sd.Name == nonHeaderPopup.CurrentDropdownValue);

                                                _world.NewEntity().Replace(new StudyDirectionSelected
                                                {
                                                    Service = educationService,
                                                    StudyDirection = studyDirection
                                                });
                                                _world.NewEntity().Replace(new HideCurrentPopup());
                                            }
                                        }
                                    }
                                })
                            });
                        }
                    }
                }
            }
            
            if (_nextIterationFilter.IsEmpty())
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
                    var productivity = educationService.Productivity;

                    character.Parameters.Get(ParameterType.Stress.ToString()).Inc(UnityEngine.Random.Range(-5f,10f));

                    educationService.AddGrade(character.Id, new Snapshot(WorldDateModule.CurrentDate, productivity));
                    if (educationDuration.TotalMonths == educationService.DurationMonths)
                    {
                        var grade = _gradeConfiguration.LetterGradePresenter.GetValue(educationService.GetAverageGrade(character.Id));
                        switch (educationService.Type)
                        {
                            case EducationType.MiddleSchool:
                            {
                                character.GraduationResults.Add(new GraduationResult(educationService,
                                    GraduationResultType.HighSchoolCertificate, StudyDirectionType.None));
                                character.Parameters.Add(ParameterType.HighSchoolCertificate.ToString(),
                                    new Parameter(productivity, 0f, 100f));
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate,
                                    new Record(LocalizationDictionary.GetLocalizedString("occupation_end_diary_entry"),99));
                                break;
                            }
                            case EducationType.HighSchool:
                            {
                                character.GraduationResults.Add(new GraduationResult(educationService,
                                    GraduationResultType.HighSchoolGraduationDiploma, StudyDirectionType.None));
                                character.Parameters.Add(ParameterType.HighSchoolGraduationDiploma.ToString(),
                                    new Parameter(productivity, 0f, 100f));
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate,
                                    new Record(LocalizationDictionary.GetLocalizedString("occupation_end_diary_entry"),99));
                                break;
                            }
                            case EducationType.CommunityCollege:
                            {
                                character.GraduationResults.Add(new GraduationResult(educationService,
                                    GraduationResultType.CommunityCollegeGraduationDiploma, StudyDirectionType.None));
                                character.Parameters.Add(ParameterType.CommunityCollegeGraduationDiploma.ToString(),
                                    new Parameter(productivity, 0f, 100f));
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate,
                                    new Record(LocalizationDictionary.GetLocalizedString("occupation_end_diary_entry"), 99));
                                    break;
                            }
                            case EducationType.University:
                            {
                                   
                                character.GraduationResults.Add(new GraduationResult(educationService,
                                    GraduationResultType.UniversityGraduationDiploma,
                                    educationService.StudyDirection.Type));
                                character.Parameters.Add(ParameterType.UniversityGraduationDiploma.ToString(),
                                    new Parameter(productivity, 0f, 100f));
                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate,
                                    new Record(LocalizationDictionary.GetLocalizedString("occupation_end_diary_entry"), 99));
                                 
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}