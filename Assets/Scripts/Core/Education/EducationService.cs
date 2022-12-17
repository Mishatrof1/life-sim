using System;
using System.Collections.Generic;
using System.Linq;
using Settings.Education;

namespace Core.Education
{
    public class EducationService : MainOccupation
    {
        public EducationType Type;
        public float Cost;
        public int DurationMonths;
        public Dictionary<string, List<Snapshot>> Grades;
        public float Productivity;

        public StudyDirection StudyDirection { get; private set; }

        public EducationService(string id) : base(id)
        {
            Grades = new Dictionary<string, List<Snapshot>>();
        }
        
        public EducationService(Save.EducationService serviceSave, StudyDirection studyDirection) : this(serviceSave.Id)
        {
            HoursPerWeek = serviceSave.HoursPerWeek;
            Type = serviceSave.Type;
            Cost = serviceSave.Cost;
            DurationMonths = serviceSave.DurationMonths;
            Grades = serviceSave.Grades ?? new Dictionary<string, List<Snapshot>>();
            StudyDirection = studyDirection;
            Productivity = serviceSave.Productivity;
            BefriendProbability = serviceSave.BefriendProbability;
        }

        public void AddGrade(string characterId, Snapshot snapshot)
        {
            if (!Grades.TryGetValue(characterId, out var temp))
            {
                Grades.Add(characterId, new List<Snapshot>());
            }
            Grades[characterId].Add(snapshot);
        }

        public float GetAverageGrade(string characterId)
        {
            if (!Grades.TryGetValue(characterId, out var temp))
            {
                return 0;
            }

            var averageForYears = Grades[characterId]
                .GroupBy(s => s.WorldDate)
                .Select(g => new Snapshot(g.Key, g.Average(s => s.Value))).ToList();

            return averageForYears
                .Skip(Math.Max(0, averageForYears.Count() - 2))
                .Average(s => s.Value);
        }

        public void SetStudyDirection(StudyDirection studyDirection)
        {
            StudyDirection = studyDirection;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case EducationType.PrimarySchool:
                    return LocalizationDictionary.GetLocalizedString("occupation_elementary_school");
                case EducationType.MiddleSchool:
                    return LocalizationDictionary.GetLocalizedString("occupation_middle_school");
                case EducationType.HighSchool:
                    return LocalizationDictionary.GetLocalizedString("occupation_high_school");
                case EducationType.CommunityCollege:
                    return LocalizationDictionary.GetLocalizedString("occupation_college");
                case EducationType.University:
                    return LocalizationDictionary.GetLocalizedString("occupation_university");
                default:
                    return base.ToString();
            }
        }

    }
}