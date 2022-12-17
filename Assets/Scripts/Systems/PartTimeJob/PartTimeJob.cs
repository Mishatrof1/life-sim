using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.Job.Simple;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;
using Settings;
using Settings.Job.Simple;
using UnityEngine;


public class PartTimeJob : IEcsInitSystem, IEcsRunSystem, INavigationElement
{
    private EcsWorld _world;
    private EcsFilter<CharacterComponent> _characterFilter;
    private EcsFilter<OrganizationComponent> _organizationsFilter;
    private EcsFilter<Created> _characterCreatedFilter;
    private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
    private EcsFilter<ApplyPartTimeButton> _applyPartTimeFilter;
    private EcsFilter<BlockComponent> _navigationFilter;
    private EcsFilter<BlockComponent, Active> _navigationActiveFilter;

    private PartTimeJobGenerationSettings _partTimeGeneration;
    private WorldGenerator _worldGenerator;
    private PartTimePositionSettings _partTimePositionSettings;
    private GradeConfiguration _gradeConfiguration;

    private Dictionary<NavigationElementType, string> _popupHeaders;
    private Dictionary<NavigationElementType, string> _popupText;
    private Dictionary<NavigationElementType, string> _buttonTitles;
    private Dictionary<NavigationElementType, string> _buttonDescriptions;

    public void Init()
    {
        _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
        foreach (var i in _organizationsFilter)
        {
            var organization = _organizationsFilter.Get1(i).Organization;
            if (organization.Services.Count == 0 && organization.PartTimeVacancies.Count > 0)
            {
                foreach (var simpleVacancy in organization.PartTimeVacancies)
                {
                    _navigationFilter.RemoveElement(NavigationBlockType.Main, simpleVacancy);
                }
                _organizationsFilter.GetEntity(i).Destroy();
            }
        }
        foreach (var i in _characterFilter)
        {
            var character = _characterFilter.Get1(i).Character;
            GeneratePartTimeJobOrganizations(character.CurrentLocation, _world, character);
        }
        foreach (var i in _organizationsFilter)
        {
            var organization = _organizationsFilter.Get1(i).Organization;
            foreach (var simpleVacancy in organization.PartTimeVacancies)
            {
                _navigationFilter.RegisterElement(NavigationBlockType.Main, simpleVacancy);
            }
        }
    }

    public void Run()
    {
        foreach (var i in _applyPartTimeFilter)
        {
            var vacancy = _applyPartTimeFilter.Get1(i).PartTimeVacancy;
            foreach (var charIndex in _characterFilter)
            {
                var character = _characterFilter.Get1(charIndex).Character;

                var text = "";
                var fields = new List<string>();
                var actions = new List<ActionButtonSettings>();

                if (character.CurrentPartTimeOccupations == null)
                {
                    if (vacancy.PartTimePositionConfiguration.IsMatchVacancyRequirement(character))
                    {
                        var service = new PartTimeServices(Guid.NewGuid().ToString())
                        {
                            PartTimePositionConfiguration = vacancy.PartTimePositionConfiguration,
                            Salary = vacancy.BaseSalary,
                        };

                        vacancy.Organization.AddService(service);

                        _characterFilter.GetEntity(charIndex).Replace(new ChangePartTimeOccupation { Service = service });
                        character.CurrentPartTimeOccupations = service;

                        text = $"Perfect fit!";
                        fields = new List<string>
                        {
                            $"Welcome to {service.PartTimePositionConfiguration.NameDefault}",
                            $"Salary: {(service.Salary * service.PartTimePositionConfiguration.HoursPerWeek).ToMoneyString()}",
                            $"Weekly hours: {service.PartTimePositionConfiguration.HoursPerWeek}h"
                        };
                        actions = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = "Ok",
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                    _world.NewEntity().Replace(new NavigationHome());
                                }
                            }
                        };
                    }
                    else
                    {
                        text = $"Rejected";
                        fields = new List<string>
                        {
                            "You are not qualified for this job"
                        };
                        actions = new List<ActionButtonSettings>
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
                    }
                    _world.NewEntity().Replace(new ShowPopup
                    {
                        PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                        {
                            HeaderText = text,
                            ContentText = string.Join(Environment.NewLine, fields),
                            ActionsSettings = actions
                        })
                    });


                }

            }
        }
              
    }

    public void GeneratePartTimeJobOrganizations(Core.Location location, EcsWorld world, Core.Character character)
    {
        var vacancies = new List<PartTimeVacancy>();

        vacancies = _worldGenerator.GeneratePartTimeVacancies(character, _gradeConfiguration, _partTimePositionSettings,
            _world, _partTimeGeneration.VacancyCount);


        foreach (var vacancy in vacancies)
        {
            var organizationConfiguration = vacancy.PartTimePositionConfiguration.PossibleOrganizations;

            var organization = new Core.Organization(Guid.NewGuid().ToString())
            {
                Name = organizationConfiguration.PossibleNames[_worldGenerator.Random.Next(0, organizationConfiguration.PossibleNames.Count)],

                DislikeFactor = (50 + Utils.NormalDistribution(0, 100, 50, 10)) * 0.01f,
                TargetDislikeFactor = 0
            };

            organization.Location = location;
            organization.AddPartTimeVacancy(vacancy);
            _world.NewEntity()
                .Replace(new OrganizationComponent { Organization = organization });
        }
    }

    public List<NavigationElementType> Types => new List<NavigationElementType>
    {
    };

    public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
    {
        return false;
    }

    public bool CanDisplay(NavigationElementType elementType)
    {
        return false;
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
