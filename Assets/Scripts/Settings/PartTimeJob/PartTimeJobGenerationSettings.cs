using System;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "PartTimeJobGenerationSettings", menuName = "LifeSim/PartTime/Generation settings", order = 0)]
    public class PartTimeJobGenerationSettings : ScriptableObject
    {
        [Header("Vacancy count")]
        public int VacancyCount;
    }