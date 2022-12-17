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

namespace Systems.Job.Simple
{
    public class Military : IEcsInitSystem, IEcsRunSystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<OrganizationComponent> _organizationsFilter;
        private EcsFilter<Created> _characterCreatedFilter;
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
        private EcsFilter<ApplyArmyButton> _applyJobFilter;
        private EcsFilter<BlockComponent> _navigationFilter;

        private JobGenerationSettings _jobGenerationSettings;
        private WorldGenerator _worldGenerator;
        private ArmySettings _positionsSettings;
        private GradeConfiguration _gradeConfiguration;
        private WorldDateModule _worldDateModule;

        
        public static Military instance = null;

        VacancyArmy vac;
        public void Init()
        {
            instance = this;
            _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
            foreach (var i in _organizationsFilter)
            {
                var organization = _organizationsFilter.Get1(i).Organization;
                if (organization.Services.Count == 0 && organization.ArmyVacancies.Count > 0)
                {
                    foreach (var simpleVacancy in organization.ArmyVacancies)
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
                foreach (var simpleVacancy in organization.ArmyVacancies)
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
                    if (organization.Services.Count == 0 && organization.ArmyVacancies.Count > 0)
                    {
                        foreach (var simpleVacancy in organization.ArmyVacancies)
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
                    foreach (var simpleVacancy in organization.ArmyVacancies)
                    {
                        _navigationFilter.RegisterElement(NavigationBlockType.Main, simpleVacancy);
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
                        var service = new MilitaryService(Guid.NewGuid().ToString())
                        {
                            PositionConfiguration = vacancy.PositionConfiguration,
                            Salary = vacancy.BaseSalary,
                            Productivity = (1 + smarts * 0.01f) * endurance * 0.01f * 1/vacancy.PositionConfiguration.Difficulty,
                        };
                        
                        vacancy.Organization.AddService(service);

                        _characterFilter.GetEntity(charIndex).Replace(new ChangeOccupation {Service = service});
                        
                        text = $"The country is proud of you!";
                        fields = new List<string>
                        {
                            $"Welcome to {service.Organization.Name}",
                            $"Title: {service.PositionConfiguration.NameDefault}",
                            $"Employer: {service.Organization.Name}",
                            $"Salary: {service.Salary.ToMoneyString()}",
                            $"Weekly hours: {service.HoursPerWeek}h"
                        };
                        actions = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = "Ok",
                                Action = () =>
                                {
                                     logInfo(character);
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
                            "You are not qualified for this Military"
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
                int count = 0;
                public void Upgrade()
                {
                 var rnd = new System.Random();
                  foreach (var g in _characterFilter)
                  {

                     var character = _characterFilter.Get1(g).Character;
                   
                      if (character.CurrentOccupation is MilitaryService simpleWorkService)
                      {               
                         if (simpleWorkService.PositionConfiguration.PromotionsDefault.Count > 0)
                         {

                            switch (simpleWorkService.PositionConfiguration.typeClass)
                            {

                                              
                                            case TypeClass.E_1:
                                            case TypeClass.E_2:
                                            case TypeClass.E_3:
                                                    SetRunk(simpleWorkService, character);
                                            break;
                                            case TypeClass.E_4:
                                                     if (count >= 1) { SetRunk(simpleWorkService, character);  count = 0; } else count++;
                                            break;
                                            case TypeClass.E_5:
                                            case TypeClass.E_6:
                                            case TypeClass.E_7:   
                                                if (count >= 4) { SetRunk(simpleWorkService, character); count = 0; } else count++;
                                            break;
                                            case TypeClass.E_8:
                                            case TypeClass.E_9: 
                                                var a = rnd.Next(0, 101);
                                                            if(a <= 12)
                                                            {
                                                                SetRunk(simpleWorkService, character);
                                                            }
                                            break;
                                            case TypeClass.W_1:
                                            case TypeClass.W_2:
                                            case TypeClass.W_3:
                                            case TypeClass.W_4:
                                            case TypeClass.W_5:
                                                if (count >= 4) { SetRunk(simpleWorkService, character); count = 0; } else count++;
                                                break;

                                            case TypeClass.O_1:
                                            case TypeClass.O_2:
                                            case TypeClass.O_3:
                                                SetRunk(simpleWorkService, character);
                                                break;
                                            case TypeClass.O_4:
                                                if (count >= 2) { SetRunk(simpleWorkService, character); count = 0; } else count++;
                                                break;
                                            case TypeClass.O_5:
                                            case TypeClass.O_6:
                                            case TypeClass.O_7:
                                                if (count >= 6) { SetRunk(simpleWorkService, character); count = 0; } else count++;
                                                break;
                                            case TypeClass.O_8:
                                            case TypeClass.O_9:
                                                var c = rnd.Next(0, 101);
                                                if (c <= 12)
                                                {
                                                    SetRunk(simpleWorkService, character);
                                                }
                                                break;

                            }

                         }

                      }
               
                  }
            
                }

                void SetRunk(MilitaryService simpleWorkService, Core.Character character)
                {
           
                    simpleWorkService.PositionConfiguration = simpleWorkService.PositionConfiguration.PromotionsDefault[0];
                    vac.PositionConfiguration = simpleWorkService.PositionConfiguration;
                    simpleWorkService.Salary = vac.SetSalary(_positionsSettings, character.OccupationHistory[simpleWorkService].Duration.TotalYears);
                    logInfo(character);
                }
            private void GenerateJobOrganizations(Core.Location location, EcsWorld world, EcsFilter<CharacterComponent> characterFilter)
            {
            var vacancies = new List<VacancyArmy>();
            foreach (var i in characterFilter)
            {
                var character = characterFilter.Get1(i).Character;
                  vacancies = _worldGenerator.GenerateVacanciesArmy(character, _gradeConfiguration, _positionsSettings,
                   _world, _characterFilter, _jobGenerationSettings.VacancyCount);
              
            }
            
            foreach (var vacancy in vacancies)
            {
                var organizationConfiguration = vacancy.PositionConfiguration.PossibleOrganizations[
                    _worldGenerator.Random.Next(0, vacancy.PositionConfiguration.PossibleOrganizations.Count)];

                var organization = new Organization(Guid.NewGuid().ToString())
                {
                    Name = organizationConfiguration.PossibleNames[_worldGenerator.Random.Next(0, organizationConfiguration.PossibleNames.Count)],
                    DislikeFactor = (50 + Utils.NormalDistribution(0, 100, 50, 10)) * 0.01f,
                    TargetDislikeFactor = 0
                }; 
               
                organization.Location = location;
                organization.AddVacancyMilitary(vacancy);
                _world.NewEntity()
                    .Replace(new OrganizationComponent { Organization = organization });
            }
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
        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.FullTimeJobs,
            NavigationElementType.Military

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
}