using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Leopotam.Ecs;
using Modules.Navigation;
using Popups;
using Settings;
using Settings.Job.Simple;
using UnityEngine;

namespace Core.Job.Simple
{
    public class VacancyArmy : INavigationElement
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<CharacterComponent> _characterFilter;
        private readonly GradeConfiguration _gradeConfiguration;
        
        public ArmyConfiguration PositionConfiguration { get; set; }
        public Organization Organization { get; set; }
        public float BaseSalary { get; set; }


        public VacancyArmy(GradeConfiguration gradeConfiguration, ArmyConfiguration positionConfiguration, EcsWorld world, EcsFilter<CharacterComponent> characterFilter, ArmySettings positionsSettings)
        {
            PositionConfiguration = positionConfiguration;
            _world = world;
            _characterFilter = characterFilter;
            _gradeConfiguration = gradeConfiguration;
            SetSalary(positionsSettings, 0);
        }

     
        
        public int SetSalary(ArmySettings _positionsSettings, int count)
        {
         
            foreach (var item in _positionsSettings.salary.Salaries)
            {
                if (item.Name == PositionConfiguration.typeClass.ToString())
                {
                    if(count <= item.Salary.Count - 1)
                        BaseSalary = item.Salary[count];
                    else
                        BaseSalary = item.Salary[item.Salary.Count - 1];
                }
            }
            return (int)BaseSalary;
        }

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.VacancyArmy
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return false;
        }
        
        public bool CanDisplay(NavigationElementType elementType)
        {
            return elementType == NavigationElementType.VacancyArmy;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            foreach (var i in _characterFilter)
            {
                var educationRequirementsString = GetEducationRequirementsString(PositionConfiguration);
                var workExpRequirementsString = GetWorkExpRequirementsString(PositionConfiguration);

                var text = $"Apply for this open position today! {Environment.NewLine}";
                text += $"{ Environment.NewLine }";
                text += $"Title: {PositionConfiguration.NameDefault}{ Environment.NewLine }";
                text += $"Employer: {Organization.Name}{ Environment.NewLine }";
                text += $"Salary: {BaseSalary.ToMoneyString()}{ Environment.NewLine }";
                text += $"Education req: {(string.IsNullOrEmpty(educationRequirementsString) ? "No requirements" : educationRequirementsString)}{ Environment.NewLine }";
                text += $"Work exp: {(string.IsNullOrEmpty(workExpRequirementsString) ? "No requirements" : workExpRequirementsString)}";

                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                    {
                        HeaderText = "Army!",
                        ContentText = text,
                       
                        ActionsSettings = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = "Вступить в армию",
                                Action = () =>
                                { 
                                     
                                 
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                    _world.NewEntity().Replace(new ApplyArmyButton {Vacancy = this});
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
                    })
                });
            }
            return false;
        }

        private string GetEducationRequirementsString(ArmyConfiguration position)
        {
            var all = string.Join(", ", position.EducationRequirementGroups
                .Where(g => g.CheckType == RequirementGroupCheckTypeArmy.All || g.Requirements.Count == 1)
                .Select(g =>
                {
                    return string.Join(", ",
                        g.Requirements.Select(r =>
                            $"{r.GraduationResult}{(r.PercentGrade > 0 ? $" {_gradeConfiguration.LetterGradePresenter.GetValue(r.PercentGrade)}" : "")}{(r.StudyDirection == StudyDirectionType.None ? "" : $" with {r.StudyDirection}")}"));
                }));

            var any = string.Join(", ", position.EducationRequirementGroups
                .Where(g => g.CheckType == RequirementGroupCheckTypeArmy.Any && g.Requirements.Count > 1)
                .Select(g =>
                {
                    return string.Join(", ",
                        g.Requirements.Select(r =>
                            $"{r.GraduationResult}{(r.PercentGrade > 0 ? $" {_gradeConfiguration.LetterGradePresenter.GetValue(r.PercentGrade)}" : "")}{(r.StudyDirection == StudyDirectionType.None ? "" : $" with {r.StudyDirection}")}"));
                }));
            
            return $"{all}{(string.IsNullOrEmpty(any) ? "" : $" and one of ({any})")}";
        }
        
        private string GetWorkExpRequirementsString(ArmyConfiguration position)
        {
            var all = string.Join(", ", position.PositionsRequirementGroups
                .Where(g => g.CheckType == RequirementGroupCheckTypeArmy.All || g.Requirements.Count == 1)
                .Select(g =>
                {
                    return string.Join(", ",
                        g.Requirements.Select(r => $"{r.PositionConfiguration.NameDefault}"));
                }));

            var any = string.Join(", ", position.PositionsRequirementGroups
                .Where(g => g.CheckType == RequirementGroupCheckTypeArmy.Any && g.Requirements.Count > 1)
                .Select(g =>
                {
                    return string.Join(", ",
                        g.Requirements.Select(r => $"{r.PositionConfiguration.NameDefault}"));
                }));
            
            return $"{all}{(string.IsNullOrEmpty(any) ? "" : $" and one of ({any})")}";
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            var button = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
            button.Title = PositionConfiguration.NameDefault;
            button.Icon = PositionConfiguration.Icon;
            button.Description = BaseSalary.ToMoneyString();
            return button;
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
        }
    }
}