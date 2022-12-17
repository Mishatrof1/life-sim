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

namespace Core.Job.Simple
{
    public class Vacancy : INavigationElement
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<CharacterComponent> _characterFilter;
        private readonly GradeConfiguration _gradeConfiguration;
        
        public PositionConfiguration PositionConfiguration { get; set; }
        public Organization Organization { get; set; }
        public float BaseSalary { get; set; }

        public Vacancy(GradeConfiguration gradeConfiguration, PositionConfiguration positionConfiguration, EcsWorld world, EcsFilter<CharacterComponent> characterFilter)
        {
            PositionConfiguration = positionConfiguration;
            _world = world;
            _characterFilter = characterFilter;
            _gradeConfiguration = gradeConfiguration;
        }
        
        

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.Vacancy
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return false;
        }
        
        public bool CanDisplay(NavigationElementType elementType)
        {
            return elementType == NavigationElementType.Vacancy;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            foreach (var i in _characterFilter)
            {
                var educationRequirementsString = GetEducationRequirementsString(PositionConfiguration);
                var workExpRequirementsString = GetWorkExpRequirementsString(PositionConfiguration);

                var text = $"{LocalizationDictionary.GetLocalizedString("vacancy_header")} {Environment.NewLine}";
                text += $"{Environment.NewLine }";
                text += $"{LocalizationDictionary.GetLocalizedString("vacancy_title")}: {PositionConfiguration.NameDefault}{ Environment.NewLine }";
                text += $"{LocalizationDictionary.GetLocalizedString("vacancy_employer")}: {Organization.Name}{ Environment.NewLine }";
                text += $"{LocalizationDictionary.GetLocalizedString("vacancy_salary")}: {BaseSalary.ToMoneyString()}{ Environment.NewLine }";
                text += $"{LocalizationDictionary.GetLocalizedString("vacancy_requirement")}: {(string.IsNullOrEmpty(educationRequirementsString) ? "No requirements" : educationRequirementsString)}{ Environment.NewLine }";
                text += $"{LocalizationDictionary.GetLocalizedString("vacancy_experience")}: {(string.IsNullOrEmpty(workExpRequirementsString) ? "No requirements" : workExpRequirementsString)}";

                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                    {
                        HeaderText = LocalizationDictionary.GetLocalizedString("occupation_job"),
                        ContentText = text,
                        ActionsSettings = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = LocalizationDictionary.GetLocalizedString("vacancy_try"),
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new ApplyJobButton {Vacancy = this});
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            },
                            new ActionButtonSettings
                            {
                                Title = LocalizationDictionary.GetLocalizedString("cancel"),
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

        private string GetEducationRequirementsString(PositionConfiguration position)
        {
            var all = string.Join(", ", position.EducationRequirementGroups
                .Where(g => g.CheckType == RequirementGroupCheckType.All || g.Requirements.Count == 1)
                .Select(g =>
                {
                    return string.Join(", ",
                        g.Requirements.Select(r =>
                            $"{r.GraduationResult}{(r.PercentGrade > 0 ? $" {_gradeConfiguration.LetterGradePresenter.GetValue(r.PercentGrade)}" : "")}{(r.StudyDirection == StudyDirectionType.None ? "" : $" {LocalizationDictionary.GetLocalizedString("vacancy_requirement_with")} {r.StudyDirection}")}"));
                }));

            var any = string.Join(", ", position.EducationRequirementGroups
                .Where(g => g.CheckType == RequirementGroupCheckType.Any && g.Requirements.Count > 1)
                .Select(g =>
                {
                    return string.Join(", ",
                        g.Requirements.Select(r =>
                            $"{r.GraduationResult}{(r.PercentGrade > 0 ? $" {_gradeConfiguration.LetterGradePresenter.GetValue(r.PercentGrade)}" : "")}{(r.StudyDirection == StudyDirectionType.None ? "" : $" {LocalizationDictionary.GetLocalizedString("vacancy_requirement_with")} {r.StudyDirection}")}"));
                }));
            
            return $"{all}{(string.IsNullOrEmpty(any) ? "" : $" {LocalizationDictionary.GetLocalizedString("vacancy_requirement_and")} ({any})")}";
        }
        
        private string GetWorkExpRequirementsString(PositionConfiguration position)
        {
            var all = string.Join(", ", position.PositionsRequirementGroups
                .Where(g => g.CheckType == RequirementGroupCheckType.All || g.Requirements.Count == 1)
                .Select(g =>
                {
                    return string.Join(", ",
                        g.Requirements.Select(r => $"{r.PositionConfiguration.NameDefault}"));
                }));

            var any = string.Join(", ", position.PositionsRequirementGroups
                .Where(g => g.CheckType == RequirementGroupCheckType.Any && g.Requirements.Count > 1)
                .Select(g =>
                {
                    return string.Join(", ",
                        g.Requirements.Select(r => $"{r.PositionConfiguration.NameDefault}"));
                }));
            
            return $"{all}{(string.IsNullOrEmpty(any) ? "" : $" {LocalizationDictionary.GetLocalizedString("vacancy_requirement_and")} ({any})")}";
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            var button = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
            button.Title = PositionConfiguration.NameDefault;
            button.Description = BaseSalary.ToMoneyString();
            button.CompanyType = PositionConfiguration.PossibleOrganizations[0].Type.ToString();
            return button;
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
        }
    }
}