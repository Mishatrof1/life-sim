using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.Job.Simple
{
    [CreateAssetMenu(fileName = "JobGenerationSettings", menuName = "LifeSim/Job/Simple/Job generation settings", order = 0)]
    public class JobGenerationSettings : ScriptableObject
    {
        public int VacancyCount;
        
        public List<string> OrganizationNameSet;
        
        [Header("Настройки для количества возможных вакансий")]
        public int OrganizationsCount;
        public int JobsCountPerOrganization;
        
        [Header("Настройки для распределения требований")]
        [Range(0,1)]
        public float RequirementsPart;
        [Range(0,1)]
        public float ExperiencePart;
        public int ExperianceRangeMin;
        public int ExperianceRangeMax;
        
        [Header("Настройки для расчета базового оклада")]
        public List<BaseValueVariant> BaseValueVariants;
        public float BaseValueExperienceMultiplier;
        
        [Header("Настройки для расчета повышения оклада")]
        public List<PromotionVariant> PromotionVariants;
    }

    [Serializable]
    public class BaseValueVariant
    {
        public Core.Job.Simple.EducationResult EducationResultType;
        public int ValueRangeMin;
        public int ValueRangeMax;
    }

    [Serializable]
    public class PromotionVariant
    {
        public float ProductivityRangeMin;
        public float ProductivityRangeMax;
        
        [Space]
        public float PromotionMultiplierRangeMin;
        public float PromotionMultiplierRangeMax;
    }
}