using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.Job.Simple;
using Extensions;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;
using Settings;
using Settings.Job.Simple;
using UnityEngine;


namespace Systems.Job.Simple
{
    public class Job : IEcsInitSystem, IEcsRunSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<OrganizationComponent> _organizationsFilter;
        private EcsFilter<Created> _characterCreatedFilter;
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
        private EcsFilter<ApplyJobButton> _applyJobFilter;
        private EcsFilter<FirstToJob> _firstJobEvent;
        private EcsFilter<BlockComponent> _navigationFilter;

        private JobGenerationSettings _jobGenerationSettings;
        private PartTimeJobGenerationSettings _partTimeGeneration;
        private WorldGenerator _worldGenerator;
        private PositionsSettings _positionsSettings;
        private PartTimePositionSettings _partTimePositionSettings;
        private PartTimeJobGenerationSettings _partTimeSettings;
        private GradeConfiguration _gradeConfiguration;
        private WorldDateModule _worldDateModule;

        Vacancy vac;
        public void Init()
        {
            _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
            foreach (var i in _organizationsFilter)
            {
                var organization = _organizationsFilter.Get1(i).Organization;
                if (organization.Services.Count == 0 && organization.SimpleVacancies.Count > 0)
                {
                    foreach (var simpleVacancy in organization.SimpleVacancies)
                    {
                        _navigationFilter.RemoveElement(NavigationBlockType.Main, simpleVacancy);
                    }
                    _organizationsFilter.GetEntity(i).Destroy();   
                }
            }
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                GenerateJobOrganizations(character.CurrentLocation, _world, _characterFilter);
            }
            foreach (var i in _organizationsFilter)
            {
                var organization = _organizationsFilter.Get1(i).Organization;
                foreach (var simpleVacancy in organization.SimpleVacancies)
                {
                    _navigationFilter.RegisterElement(NavigationBlockType.Main, simpleVacancy);
                }
            }
        }

        public void Run()
        {
            if (!_nextIterationFilter.IsEmpty() || !_characterCreatedFilter.IsEmpty())
            {
                foreach (var i in _organizationsFilter)
                {
                    var organization = _organizationsFilter.Get1(i).Organization;
                    if (organization.Services.Count == 0 && organization.SimpleVacancies.Count > 0)
                    {
                        foreach (var simpleVacancy in organization.SimpleVacancies)
                        {
                            _navigationFilter.RemoveElement(NavigationBlockType.Main, simpleVacancy);
                        }
                        _organizationsFilter.GetEntity(i).Destroy();   
                    }
                }
                foreach (var i in _characterFilter)
                {
                    var character = _characterFilter.Get1(i).Character;
                    GenerateJobOrganizations(character.CurrentLocation, _world, _characterFilter);
                }
                foreach (var i in _organizationsFilter)
                {
                    var organization = _organizationsFilter.Get1(i).Organization;
                    foreach (var simpleVacancy in organization.SimpleVacancies)
                    {
                        _navigationFilter.RegisterElement(NavigationBlockType.Main, simpleVacancy);
                    }
                }
            }

            if (!_nextIterationFilter.IsEmpty())
            {
                foreach (var i in _characterFilter)
                {
                    var character = _characterFilter.Get1(i).Character;
                    if (character.CurrentOccupation != null && character.CurrentOccupation is SimpleWorkService simpleWorkService)
                    {
                        var increaseSalaryValue = GetSalaryIncreaseValue(simpleWorkService.Salary);
                        if (increaseSalaryValue > 0)
                        {
                            simpleWorkService.Salary += increaseSalaryValue;

                            var value1 = increaseSalaryValue / (simpleWorkService.Salary - increaseSalaryValue) * 100;
                            var value2 = simpleWorkService.Salary.ToMoneyString();

                            character.AgeLog.AddRecord(WorldDateModule.CurrentDate,
                                new Record(LocalizationDictionary.GetLocalizedString("occupation_salary_raise_diary_entry")));
                        }
                    }
                }
            }
            
            foreach (var i in _applyJobFilter)
            {
                var vacancy = _applyJobFilter.Get1(i).Vacancy;
                vac = vacancy;
                foreach (var charIndex in _characterFilter)
                {
                    var character = _characterFilter.Get1(charIndex).Character;

                    var text = "";
                    var fields = new List<string>();
                    var actions = new List<ActionButtonSettings>();
                    var smarts = character.Parameters.Get(ParameterType.Smarts.ToString()).Value;
                    var endurance = character.Parameters.Get(ParameterType.Endurance.ToString()).Value;

                    if (vacancy.PositionConfiguration.IsMatchVacancyRequirement(character, _positionsSettings))
                    {
                        var service = new SimpleWorkService(Guid.NewGuid().ToString())
                        {
                            PositionConfiguration = vacancy.PositionConfiguration,
                            Salary = vacancy.BaseSalary,
                            Productivity = (1 + smarts * 0.01f) * endurance * 0.01f * 1/vacancy.PositionConfiguration.Difficulty,
                        };
                        
                        vacancy.Organization.AddService(service);

                        _characterFilter.GetEntity(charIndex).Replace(new ChangeOccupation {Service = service});
                        
                        text = $"{LocalizationDictionary.GetLocalizedString("vacancy_accept")}";
                        fields = new List<string>
                        {
                            $"{LocalizationDictionary.GetLocalizedString("vacancy_accept_organization")} {service.Organization.Name}",
                            $"{LocalizationDictionary.GetLocalizedString("vacancy_accept_job")}: {service.PositionConfiguration.NameDefault}",
                            $"{LocalizationDictionary.GetLocalizedString("vacancy_accept_position")}: {service.Organization.Name}",
                            $"{LocalizationDictionary.GetLocalizedString("vacancy_accept_salary")}: {service.Salary.ToMoneyString()}",
                            $"{LocalizationDictionary.GetLocalizedString("vacancy_accept_hours")}: {service.HoursPerWeek}h"
                        };
                        actions = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = LocalizationDictionary.GetLocalizedString("ok"),
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
                        text = $"{LocalizationDictionary.GetLocalizedString("vacancy_denied")}";
                        fields = new List<string>
                        {
                            $"{LocalizationDictionary.GetLocalizedString("vacancy_denied_description")}"
                        };
                        actions = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = LocalizationDictionary.GetLocalizedString("ok"),
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
            Upgrade();
        }
           int count = 0;
        public void Upgrade()
        {
            
            foreach (var g in _characterFilter)
            {

                var character = _characterFilter.Get1(g).Character;

                if (character.CurrentOccupation is SimpleWorkService simpleWorkService)
                {
                    if (simpleWorkService.PositionConfiguration.PromotionsDefault.Count > 0)
                    {
                        SetRunk(simpleWorkService, character);
                    }
                }
            }
        }
        void SetRunk(SimpleWorkService simpleWorkService, Core.Character character)
        {

            simpleWorkService.PositionConfiguration = simpleWorkService.PositionConfiguration.PromotionsDefault[0];
            vac.PositionConfiguration = simpleWorkService.PositionConfiguration;
            simpleWorkService.Salary = vac.PositionConfiguration.Salary;
            logInfo(character);
        }

        void logInfo(Core.Character character)
        {
            if (character.CurrentOccupation is MilitaryService simpleWorkService)
            {
                character.AgeLog.AddRecord(WorldDateModule.CurrentDate,
                 new Record(
                     $"I was promoted to: {simpleWorkService.PositionConfiguration.NameDefault}\n " +
                     $"My Salary is now {(simpleWorkService.Salary * 12).ToMoneyString() }")
                 );

            }
        }
        private float GetSalaryIncreaseValue(float currentSalary)
        {
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                var smarts = character.Parameters.Get(ParameterType.Smarts.ToString()).Value;
                var promotionVariant = _jobGenerationSettings.PromotionVariants.First(v =>
                    smarts >= v.ProductivityRangeMin && smarts < v.ProductivityRangeMax);
                var multiplier = (_worldGenerator.GetRandom(
                    (int) (promotionVariant.PromotionMultiplierRangeMin * 100),
                    ((int) (promotionVariant.PromotionMultiplierRangeMax * 100)) + 1)) / 100f;
                return currentSalary * multiplier;
            }

            return 0;
        }
        private void GenerateJobOrganizations(Core.Location location, EcsWorld world, EcsFilter<CharacterComponent> characterFilter)
        {
            var vacancies = new List<Vacancy>();
            foreach (var i in characterFilter)
            {
                var character = characterFilter.Get1(i).Character;
                vacancies = _worldGenerator.GenerateVacancies(character, _gradeConfiguration, _positionsSettings,
                    _world, _characterFilter, _jobGenerationSettings.VacancyCount);
              
            }
            
            foreach (var vacancy in vacancies)
            {
                var organizationConfiguration = vacancy.PositionConfiguration.PossibleOrganizations[
                    _worldGenerator.Random.Next(0, vacancy.PositionConfiguration.PossibleOrganizations.Count)];

                var organization = new Core.Organization(Guid.NewGuid().ToString())
                {
                    Name = organizationConfiguration.PossibleNames[_worldGenerator.Random.Next(0, organizationConfiguration.PossibleNames.Count)],
                  
                    DislikeFactor = (50 + Utils.NormalDistribution(0, 100, 50, 10))*0.01f,
                    TargetDislikeFactor = 0
                };
               
                organization.Location = location;
                organization.AddVacancy(vacancy);
                _world.NewEntity()
                    .Replace(new OrganizationComponent {Organization = organization});
            }
        }
        
        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.FullTimeJobs,
            NavigationElementType.Military,
            NavigationElementType.Navy,

        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return false;
        }
        
        public bool CanDisplay(NavigationElementType elementType)
        {

            if (elementType == NavigationElementType.FullTimeJobs ||
                 elementType == NavigationElementType.Military)
            {
                return true;
            }

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
}