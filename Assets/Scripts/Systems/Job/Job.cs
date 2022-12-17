using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.Job;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;
using Settings.Job;
using UnityEngine;

namespace Systems.Job
{
    public class Job : IEcsInitSystem, IEcsRunSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<LocationComponent, NewLocation> _newLocationFilter;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<OrganizationComponent> _organizationFilter;
        private EcsFilter<GetJobSuccess> _jobSucessFilter;
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
        private EcsFilter<BlockComponent> _navigationFilter;

        private WorldGenerator _worldGenerator;
        private PositionChainSet _positionChainSet;

        private const float _skillIncreaseValue = 1;
        
        public void Init()
        {
            foreach (var i in _organizationFilter)
            {
                SetupJobSegment(_organizationFilter.Get1(i).Organization);
            }
            
            _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
        }

        public void Run()
        {
            foreach (var i in _newLocationFilter)
            {
                var newLocation = _newLocationFilter.Get1(i).Location;
                
                var organization = new Organization(Guid.NewGuid().ToString())
                {
                    Name = "Shop",
                    Location = newLocation,
                    Type = OrganizationType.Unknown,
                    ScopeType = ScopeType.Trading,
                    DislikeFactor = (50 + Utils.NormalDistribution(0, 100, 50, 10)) * 0.01f,
                    TargetDislikeFactor = 0
                };
                
                SetupJobSegment(organization);
                _world.NewEntity()
                    .Replace(new OrganizationComponent { Organization = organization });
            }

            foreach (var i in _characterFilter)
            {
                CreateWorkService(_characterFilter.GetEntity(i));
            }

            if (_nextIterationFilter.IsEmpty())
                return;
            
            foreach (var i in _characterFilter)
            {
                var entity = _characterFilter.GetEntity(i);
                var character = _characterFilter.Get1(i).Character;
                if (character.CurrentOccupation is WorkService workService)
                {
                    foreach (var increaseSkill in workService.Position.IncreaseSkills)
                    {
                        character.Parameters.Get($"{nameof(SkillType)}_{increaseSkill.ToString()}").Set(WorldDateModule.Mode switch
                        {
                            WorldDateMode.FullYear => _skillIncreaseValue,
                            WorldDateMode.HalfYear => _skillIncreaseValue * 0.5f,
                            _ => throw new ArgumentException()
                        });
                    }
                    
                    var chainExperience = character.OccupationHistory
                        .Where(pair =>
                            pair.Key is WorkService workService &&
                            workService.Position.Chain.Positions.Any(pos => ReferenceEquals(pos, workService.Position)))
                        .Sum(x => ReferenceEquals(x.Key, character.CurrentOccupation)
                            ? (WorldDateModule.CurrentDate - x.Value.StartDate).TotalMonths
                            : (x.Value.EndDate - x.Value.StartDate).TotalMonths);
                    
                    var averageSkillFactor = workService.Position.RequiredSkills.Count == 0
                        ? WorldDate.FromMonths(chainExperience).TotalYears
                        : workService.Position.RequiredSkills.Sum(x =>
                              character.Parameters.Get($"{nameof(SkillType)}_{x.Type.ToString()}").Value) /
                          workService.Position.RequiredSkills.Count;

                    var productivity = workService.Productivity;
                    var prevPosition = workService.Position.PreviousPosition(workService.Organization.Type,
                        workService.Organization.ScopeType);
                    var productivityThreshold = prevPosition?.IncreaseFactor * 0.9f ?? 0.2f;
                    
                    if (productivity < productivityThreshold)
                    {
                        character.Parameters.Get(ParameterType.Stress.ToString()).Inc(UnityEngine.Random.Range(5f, 25f));
                        entity.Replace(new ChangeOccupation {Service = null});
                        _world.NewEntity().Replace(new ShowPopup
                        {
                            PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                            {
                                HeaderText = workService.Organization.Name,
                                ContentText = $"{LocalizationDictionary.GetLocalizedString("ocuupation_fired_pp")} {workService.Position.Title}",
                                ActionsSettings = new List<ActionButtonSettings>
                                {
                                    new ActionButtonSettings
                                    {
                                        Title = LocalizationDictionary.GetLocalizedString("ok"),
                                        Action = () => _world.NewEntity().Replace(new HideCurrentPopup())
                                    }
                                }
                            })
                        });
                        continue;
                    }
                    
                    var nextPosition = workService.Position.NextPosition(workService.Organization.Type,
                        workService.Organization.ScopeType);
                    if (nextPosition == null)
                        continue;
                    
                    if (productivity >= workService.Position.IncreaseFactor)
                    {
                        var nextWorkService = workService.Organization.CreateWorkService(nextPosition);
                        workService.Organization.AddService(nextWorkService);
                        entity.Replace(new ChangeOccupation {Service = nextWorkService});
                        _world.NewEntity().Replace(new ShowPopup
                        {
                            PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                            {
                                HeaderText = workService.Organization.Name,
                                ContentText = $"{LocalizationDictionary.GetLocalizedString("ocuupation_promotion_pp")} {nextPosition.Title}",
                                ActionsSettings = new List<ActionButtonSettings>
                                {
                                    new ActionButtonSettings
                                    {
                                        Title = LocalizationDictionary.GetLocalizedString("ok"),
                                        Action = () => _world.NewEntity().Replace(new HideCurrentPopup())
                                    }
                                }
                            })
                        });
                    }
                }
            }
        }

        private void CreateWorkService(EcsEntity characterEntity)
        {
            foreach (var i in _jobSucessFilter)
            {
                var vacancy = _jobSucessFilter.Get1(i).Vacancy;
                var workService = vacancy.Organization.CreateWorkService(vacancy);
                vacancy.Organization.AddService(workService);
                characterEntity.Replace(new ChangeOccupation {Service = workService});
                _world.NewEntity().Replace(new NavigationHome());
            }
        }

        private void SetupJobSegment(Organization organization)
        {
            _worldGenerator.GenerateEmployerParameters(organization.Type, organization.Parameters);
            _positionChainSet.GetAvailablePositions(organization.Type, organization.ScopeType)
                .Select(pos => new Vacancy(_world, _characterFilter, organization)
                {
                    Position = pos
                }).ToList()
                .ForEach(x => _navigationFilter.RegisterElement(NavigationBlockType.Main, x));
        }
        
        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.FullTimeJobs
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return false;
        }
        
        public bool CanDisplay(NavigationElementType elementType)
        {
            return elementType == NavigationElementType.FullTimeJobs;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            return true;
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
        }
    }
}