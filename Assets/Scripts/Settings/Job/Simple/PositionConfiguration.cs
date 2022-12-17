using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Education;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings.Job.Simple
{
    [CreateAssetMenu(fileName = "PositionConfiguration", menuName = "LifeSim/Job/Simple/PositionConfiguration", order = 0)]
    public class PositionConfiguration : ScriptableObject
    {
        public string NameDefault;
        public Sprite Icon;
        public int Salary;
        public int HoursPerWeek;
        public float Difficulty;
        public int CountYear;
        public List<OrganizationConfiguration> PossibleOrganizations;

        [Header("Vacancy requirements settings")]
        public PersonRequirement PersonRequirement;
        public PositionChainRequirement PositionChainRequirement;
        public List<ParametersRequirement> ParametersRequirements;
        public List<PositionRequirementGroup> PositionsRequirementGroups;
        public List<EducationRequirementGroup> EducationRequirementGroups;
        
        [Header("Promotion settings")]
        public List<PositionConfiguration> PromotionsDefault;
        public List<Promotion> SpecialPromotions;

        public bool IsMatchVacancyRequirement(Character character, PositionsSettings settings)
        {
            return PositionsRequirementGroups.All(r => r.IsMatch(character)) &&
                   ParametersRequirements.All(r => r.IsMatch(character)) &&
                   EducationRequirementGroups.All(r => r.IsMatch(character)) &&
                   PersonRequirement.IsMatch(character) &&
                   PositionChainRequirement.IsMatch(character, settings, this);
        }
    }
    
    [Serializable]
    public class PositionRequirementGroup
    {
        public List<PositionRequirement> Requirements;
        public RequirementGroupCheckType CheckType;

        public bool IsMatch(Character character)
        {
            switch (CheckType)
            {
                case RequirementGroupCheckType.Any:
                    return Requirements.Any(r => r.IsMatch(character));
                case RequirementGroupCheckType.All:
                    return Requirements.All(r => r.IsMatch(character));
                default:
                    return false;
            }
        }
    }

    public enum RequirementGroupCheckType
    {
        Any,
        All
    }
    
    [Serializable]
    public class PositionRequirement
    {
        public PositionConfiguration PositionConfiguration;
        public int Experience;

        public bool IsMatch(Character character)
        {
            var period = character.OccupationHistory.FirstOrDefault(pair =>
                pair.Key is WorkService workService &&
                ReferenceEquals(workService.PositionConfiguration, PositionConfiguration)).Value;

                if (period != null)
                {
                    return period.Duration.TotalYears >= Experience;
                }

            return false;
        }
    }
    
    [Serializable]
    public class PositionChainRequirement
    {
        public int Experience;

        public bool IsMatch(Character character, PositionsSettings settings, PositionConfiguration configuration)
        {
            if (Experience == 0)
            {
                return true;
            }
            
            var totalChainExperience = 0;
            GetChainExperience(character, settings, configuration, ref totalChainExperience);
            return totalChainExperience >= Experience;
        }

        private void GetChainExperience(Character character, PositionsSettings settings, PositionConfiguration configuration, ref int experience)
        {
            var period = character.OccupationHistory.FirstOrDefault(pair =>
                pair.Key is WorkService workService &&
                ReferenceEquals(workService.PositionConfiguration, configuration)).Value;
            if (period != null)
            {
                experience += period.Duration.TotalYears;
            }
            
            var prevConfigurations = settings.Configurations.Where(c =>
                c.PromotionsDefault.Any(promConfig => ReferenceEquals(promConfig, configuration)) ||
                c.SpecialPromotions.Any(specialProm => specialProm.Promotions.Any(promConfig => ReferenceEquals(promConfig, configuration))));

            foreach (var prevConfiguration in prevConfigurations)
            {
                GetChainExperience(character, settings, prevConfiguration, ref experience);
            }
        }
    }

    [Serializable]
    public class EducationRequirementGroup
    {
        public List<EducationRequirement> Requirements;
        public RequirementGroupCheckType CheckType;

        public bool IsMatch(Character character)
        {
            switch (CheckType)
            {
                case RequirementGroupCheckType.Any:
                    return Requirements.Any(r => r.IsMatch(character));
                case RequirementGroupCheckType.All:
                    return Requirements.All(r => r.IsMatch(character));
                default:
                    return false;
            }
        }
    }
    
    [Serializable]
    public class EducationRequirement
    {
        public GraduationResultType GraduationResult;
        public float PercentGrade;
        public StudyDirectionType StudyDirection;

        public bool IsMatch(Character character)
        {
            if (GraduationResult == GraduationResultType.None)
                return true;
            
            var graduationResult = character.GraduationResults.FirstOrDefault(gr => gr.Type == GraduationResult);
            if (graduationResult == null)
                return false;

            var result = true;
            result &= graduationResult.AcademicPerformance.Value * 100 >= PercentGrade;

            if (StudyDirection != StudyDirectionType.None)
            {
                result &= graduationResult.StudyDirection == StudyDirection;
            }
            
            return result;
        }
    }

    [Serializable]
    public class ParametersRequirement
    {
        public ParameterType Parameter;
        public float Value;
        
        public bool IsMatch(Character character)
        {
            return character.Parameters.Get(Parameter.ToString()).Value >= Value;
        }
    }
    
    [Serializable]
    public class PersonRequirement
    {
        public int Age;
        public int TotalWorkExperience;
        public bool Conviction;

        public bool IsMatch(Character character)
        {
            var result = true;
            result &= character.Age.TotalYears >= Age;
            result &= character.OccupationHistory.Where(pair => pair.Key is WorkService workService)
                .Sum(pair => pair.Value.Duration.TotalYears) >= TotalWorkExperience;
            // todo добавить обработку условия Conviction
            return result;
        }
    }

    [Serializable]
    public class Promotion
    {
        public OrganizationConfiguration Organization;
        public List<PositionConfiguration> Promotions;
    }
}