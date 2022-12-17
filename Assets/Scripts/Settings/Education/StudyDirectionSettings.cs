using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

namespace Settings.Education
{
    [CreateAssetMenu(fileName = "StudyDirectionSettings", menuName = "LifeSim/Education/StudyDirectionSettings", order = 0)]
    public class StudyDirectionSettings : ScriptableObject
    {
        [SerializeField] private List<StudyDirectionConfiguration> _configurations;

        public List<StudyDirection> GetStudyDirections()
        {
            return _configurations.Select(c => new StudyDirection(c)).ToList();
        }
    }

    [Serializable]
    public class StudyDirectionConfiguration
    {
        public StudyDirectionType Type;
    }

    public class StudyDirection
    {
        private readonly StudyDirectionConfiguration _configuration;

        public string Name => _configuration.Type.ToString();
        public StudyDirectionType Type => _configuration.Type;
        
        public StudyDirection(StudyDirectionConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}