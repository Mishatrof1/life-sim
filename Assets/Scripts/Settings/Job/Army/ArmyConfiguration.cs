using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Education;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings.Job.Simple
{
    [CreateAssetMenu(fileName = "ArmyConfiguration", menuName = "LifeSim/Army/ArmyConfiguration", order = 0)]
    public class ArmyConfiguration : ScriptableObject
    {
        public string NameDefault;
        public string EasyName;
        public Sprite Icon;
        
       
        public int CurrentSalary = 0;
        public int HoursPerWeek;
        public float Difficulty;
        public TypeClass typeClass;
        public List<OrganizationConfiguration> PossibleOrganizations;

        [Header("Vacancy requirements settings")]
        public PersonRequirementArmy PersonRequirement;
        public PositionChainRequirementArmy PositionChainRequirement;
        public List<ParametersRequirementArmy> ParametersRequirements;
        public List<PositionRequirementGroupArmy> PositionsRequirementGroups;
        public List<EducationRequirementGroupArmy> EducationRequirementGroups;
        
        [Header("Promotion settings")]
        public List<ArmyConfiguration> PromotionsDefault;
        public List<PromotionArmy> SpecialPromotions;

        public bool IsMatchVacancyRequirement(Character character, ArmySettings settings)
        {
            return PositionsRequirementGroups.All(r => r.IsMatch(character)) &&
                   ParametersRequirements.All(r => r.IsMatch(character)) &&
                   EducationRequirementGroups.All(r => r.IsMatch(character)) &&
                   PersonRequirement.IsMatch(character) &&
                   PositionChainRequirement.IsMatch(character, settings, this);
        }
    }
 
    [System.Serializable]
    public struct Salary
    {
        public string Name;
        public int _Salary;
    }
    
    [Serializable]
    public class PositionRequirementGroupArmy
    {
        public List<PositionRequirementArmy> Requirements;
        public RequirementGroupCheckTypeArmy CheckType;

        public bool IsMatch(Character character)
        {
            switch (CheckType)
            {
                case RequirementGroupCheckTypeArmy.Any:
                    return Requirements.Any(r => r.IsMatch(character));
                case RequirementGroupCheckTypeArmy.All:
                    return Requirements.All(r => r.IsMatch(character));
                default:
                    return false;
            }
        }
    }

    public enum RequirementGroupCheckTypeArmy
    {
        Any,
        All
    }
    
    [Serializable]
    public class PositionRequirementArmy
    {
        public ArmyConfiguration PositionConfiguration;
        public int Experience;

        public bool IsMatch(Character character)
        {
            var period = character.OccupationHistory.FirstOrDefault(pair =>
                pair.Key is WorkService workService &&
                ReferenceEquals(workService.ArmyConfigs, PositionConfiguration)).Value;

            if (period != null)
            {
                return period.Duration.TotalYears >= Experience;
            }

            return false;
        }
    }
    
    [Serializable]
    public class PositionChainRequirementArmy
    {
        public int Experience;

        public bool IsMatch(Character character, ArmySettings settings, ArmyConfiguration configuration)
        {
            if (Experience == 0)
            {
                return true;
            }
            
            var totalChainExperience = 0;
            GetChainExperience(character, settings, configuration, ref totalChainExperience);
            return totalChainExperience >= Experience;
        }

        private void GetChainExperience(Character character, ArmySettings settings, ArmyConfiguration configuration, ref int experience)
        {
            var period = character.OccupationHistory.FirstOrDefault(pair =>
                pair.Key is WorkService workService &&
                ReferenceEquals(workService.ArmyConfigs, configuration)).Value;
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
    public class EducationRequirementGroupArmy
    {
        public List<EducationRequirementArmy> Requirements;
        public RequirementGroupCheckTypeArmy CheckType;

        public bool IsMatch(Character character)
        {
            switch (CheckType)
            {
                case RequirementGroupCheckTypeArmy.Any:
                    return Requirements.Any(r => r.IsMatch(character));
                case RequirementGroupCheckTypeArmy.All:
                    return Requirements.All(r => r.IsMatch(character));
                default:
                    return false;
            }
        }
    }
    
    [Serializable]
    public class EducationRequirementArmy
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
    public class ParametersRequirementArmy
    {
        public ParameterType Parameter;
        public float Value;
        
        public bool IsMatch(Character character)
        {
            return character.Parameters.Get(Parameter.ToString()).Value >= Value;
        }
    }
    
    [Serializable]
    public class PersonRequirementArmy
    {
        public int MinAge;
        public int MaxAge;
        public int TotalWorkExperience;

        public bool IsMatch(Character character)
        {
            var result = true;
            result &= character.Age.TotalYears >= MinAge && character.Age.TotalYears <= MaxAge;
            result &= character.OccupationHistory.Where(pair => pair.Key is WorkService workService)
                .Sum(pair => pair.Value.Duration.TotalYears) >= TotalWorkExperience;
            return result;
        }
    }

    [Serializable]
    public class PromotionArmy
    {
        public OrganizationConfiguration Organization;
        public List<ArmyConfiguration> Promotions;
    }
}
[Serializable]
public enum TypeClass
{
   E_1, 
   E_2,
   E_3,
   E_4,
   E_5,
   E_6,
   E_7,
   E_8,
   E_9,
   ___,
   W_1,
   W_2,
   W_3,
   W_4,
   W_5,
   ____,
   O_1,
   O_2,
    O_3,
    O_4,
    O_5,
    O_6,
    O_7,
    O_8,
    O_9,
}