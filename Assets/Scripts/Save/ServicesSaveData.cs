using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

namespace Save
{
    [CreateAssetMenu]
    public class ServicesSaveData : SaveData
    {
        public List<WorkService> WorkServices;
        public List<SimpleWorkService> SimpleWorkServices;
        public List<PartTimeService> PartTimeService;
        public List<MilitaryService> MilitaryServices;
        public List<EducationService> EducationServices;

        public override void ResetSaveData()
        {
            WorkServices = new List<WorkService>();
            SimpleWorkServices = new List<SimpleWorkService>();
            PartTimeService = new List<PartTimeService>();
            MilitaryServices = new List<MilitaryService>();
            EducationServices = new List<EducationService>();
        }

        public override void OnBeforeSerialize()
        {
            EducationServices?.ForEach(s => s.OnBeforeSerialize());
        }

        public override void OnAfterDeserialize()
        {
            EducationServices?.ForEach(s => s.OnAfterDeserialize());
        }
    }

    [Serializable]
    public class Service
    {
        public string Id;
        public string OrganizationId;
    }

    [Serializable]
    public class MainOccupation : Service
    {
        public int HoursPerWeek;
        public int BefriendProbability;
    }
    [Serializable]
    public class PartTimeOccupations : Service
    {
        public int HoursPerWeek;
    }
    
    [Serializable]
    public class EducationService : MainOccupation
    {
        public EducationType Type;
        public EducationResultType ResultType;
        public float Cost;
        public int DurationMonths;

        [SerializeField] private List<GradesSave> _gradesSaves;
        public Dictionary<string, List<Snapshot>> Grades;
        public string StudyDirection;

        public float Productivity;

        public EducationService(Core.Education.EducationService service)
        {
            Id = service.Id;
            OrganizationId = service.Organization.Id;
            HoursPerWeek = service.HoursPerWeek;
            Type = service.Type;
            Cost = service.Cost;
            DurationMonths = service.DurationMonths;
            Grades = service.Grades;
            StudyDirection = service.StudyDirection?.Type.ToString();
            Productivity = service.Productivity;
            BefriendProbability = service.BefriendProbability;
        }
        
        public void OnBeforeSerialize()
        {
            _gradesSaves = Grades?.Select(g => new GradesSave
            {
                CharacterId = g.Key,
                Grades = g.Value
            }).ToList() ?? new List<GradesSave>();
        }

        public void OnAfterDeserialize()
        {
            Grades = _gradesSaves?.ToDictionary(g => g.CharacterId, g => g.Grades) ??
                     new Dictionary<string, List<Snapshot>>();
        }
    }

    [Serializable]
    public class GradesSave
    {
        public string CharacterId;
        public List<Snapshot> Grades;
    }

    [Serializable]
    public class WorkService : MainOccupation
    {
        public int PositionChainIndex;
        public int PositionIndex;
        public float BaseSalary;
        public float SalaryMultiplier;
        public float DislikeFactor;
        public float TargetDislikeFactor;
        public float Productivity;

        public WorkService(Core.WorkService service)
        {
            Id = service.Id;
            OrganizationId = service.Organization.Id;
            HoursPerWeek = service.HoursPerWeek;
            BaseSalary = service.Salary;
            SalaryMultiplier = service.SalaryMultiplier;
            DislikeFactor = service.DislikeFactor;
            TargetDislikeFactor = service.TargetDislikeFactor;
            Productivity = service.Productivity;
        }
    }
    [Serializable]
    public class PartTimeService : PartTimeOccupations
    {
        public float BaseSalary;
        public int PartTimePositionConfiguration;

        public PartTimeService(Core.PartTimeServices service)
        {
            Id = service.Id;
            OrganizationId = service.Organization.Id;
            HoursPerWeek = service.HoursPerWeek;
            BaseSalary = service.Salary;
        }
    }
    
    [Serializable]
    public class SimpleWorkService : MainOccupation
    {
        public float Salary;
        public int PositionConfigurationIndex;
        public float DislikeFactor;
        public float TargetDislikeFactor;
        public float Productivity;

        public SimpleWorkService(Core.SimpleWorkService service)
        {
            Id = service.Id;
            OrganizationId = service.Organization.Id;
            HoursPerWeek = service.HoursPerWeek;
            Salary = service.Salary;
            DislikeFactor = service.DislikeFactor;
            TargetDislikeFactor = service.TargetDislikeFactor;
            Productivity = service.Productivity;
            BefriendProbability = service.BefriendProbability;
        }
    }

    [Serializable]
    public class MilitaryService : MainOccupation
    {
        public float Salary;
        public int PositionConfigurationIndex;
        public float DislikeFactor;
        public float TargetDislikeFactor;
        public float Productivity;

        public MilitaryService(Core.MilitaryService service)
        {
            Id = service.Id;
            OrganizationId = service.Organization.Id;
            HoursPerWeek = service.HoursPerWeek;
            Salary = service.Salary;
            DislikeFactor = service.DislikeFactor;
            TargetDislikeFactor = service.TargetDislikeFactor;
            Productivity = service.Productivity;
            BefriendProbability = service.BefriendProbability;
        }
    }
}