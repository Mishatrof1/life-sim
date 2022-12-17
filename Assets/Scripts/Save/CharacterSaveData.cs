using System;
using System.Collections.Generic;
using Components;
using Core;
using Core.Education;
using UnityEngine;
using UnityEngine.Serialization;
using EducationResult = Core.Job.Simple.EducationResult;

namespace Save
{
    [CreateAssetMenu]
    public class CharacterSaveData : SaveData
    {
        public CharacterSave Character;

        public override void ResetSaveData()
        {
            Character = null;
        }
    }

    [Serializable]
    public class CharacterSave : PersonSave
    {
        public List<string> AvailableLocations;
        public string CurrentLocation;
        public string CurrentOccupation;
        public string PartTimeOccupation;
        public List<OccupationPeriodSave> OccupationHistory;
        public List<EducationResultType> EducationResultTypes;
        public List<EducationResult> EducationResults;
        public float Balance;
        public List<string> Logs;
        public AgeLogSaveData AgeLog;
        public List<InkStorySave> InkStoryHistory;
        public List<GraduationResultSave> GraduationResultSaves;
        public float StressDelta;
        public int ProdInc;
        public int ProdDec;
    }
    
    [Serializable]
    public class OccupationPeriodSave
    {
        public string ServiceId;
        public WorldDate StartDate;
        public WorldDate EndDate;
    }

    [Serializable]
    public class InkStorySave
    {
        public string StoryName;
        public WorldDate Year;
    }

    [Serializable]
    public class GraduationResultSave
    {
        public GraduationResultType Type;
        public StudyDirectionType StudyDirection;
        public ParameterSaveData AcademicPerformance;
        public string EducationService;

        public GraduationResultSave(GraduationResult graduationResult)
        {
            Type = graduationResult.Type;
            StudyDirection = graduationResult.StudyDirection;
            AcademicPerformance = new ParameterSaveData("", graduationResult.AcademicPerformance);
            EducationService = graduationResult.EducationService.Id;
        }
    }
}