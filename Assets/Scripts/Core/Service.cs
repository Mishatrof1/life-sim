using System;
using System.Collections.Generic;
using System.Linq;
using Settings.Job;
using Settings.Job.Simple;

namespace Core
{
    public class Service
    {
        public string Id { get; }
        public Organization Organization { get; set; }

        public Service(string id)
        {
            Id = id;
        }
    }
    
    public class MainOccupation : Service
    {
        public int HoursPerWeek;
        public int BefriendProbability { get; set; }

        public MainOccupation(string id) : base(id)
        {
            BefriendProbability = 60;
        }
    }
    public class PartTimeOccupations : Service
    {

        public int HoursPerWeek;
        public PartTimeOccupations(string id) : base(id)
        {
        }
    }

    //todo выпилить WorkServica, переименовать SimpleWorkService в WorkService
    public class WorkService : MainOccupation
    {
        public float Productivity { get; set; }
        public float DislikeFactor
        {
            get
            {
                return Organization.DislikeFactor;
            }
        }
        public float TargetDislikeFactor
        {
            get
            {
                return Organization.TargetDislikeFactor;
            }
        }
        public float BaseSalary { get; set; }
        public float SalaryMultiplier { get; set; }
        public Position Position { get; set; }
        public float Difficulty
        {
            get
            {
                return PositionConfiguration.Difficulty;
            }
        }
        public PositionConfiguration PositionConfiguration { get; set; }
        public ArmyConfiguration ArmyConfigs { get; set; }

        public WorkService(string id) : base(id)
        {
            SalaryMultiplier = 1;
        }
        
        public WorkService(Save.WorkService serviceSave) : this(serviceSave.Id)
        {
            HoursPerWeek = serviceSave.HoursPerWeek;
            BaseSalary = serviceSave.BaseSalary;
            SalaryMultiplier = serviceSave.SalaryMultiplier;
            Productivity = serviceSave.Productivity;
        }
        
        public float Salary => BaseSalary * SalaryMultiplier;

        public float GetDislikeFactor(int years = 0)
        {
            if (years < 1)
            {
                return DislikeFactor;
            }
            else if (years < 2)
            {
                return DislikeFactor * 2 / 3 + TargetDislikeFactor * 1 / 3;
            }
            else if (years < 3)
            {
                return DislikeFactor * 1 / 3 + TargetDislikeFactor * 2 / 3;
            }
            else return TargetDislikeFactor;
        }

        //будет зависеть от места проживания, места работы
        public int GetHoursInRoad()
        {
            return 0;
        }

        public override string ToString()
        {
            return LocalizationDictionary.GetLocalizedString("occupation_job");
        }

    }

    public class PartTimeServices : PartTimeOccupations
    {
        public PartTimePositionConfiguration PartTimePositionConfiguration { get; set; }
        public float Salary { get; set; }

        public PartTimeServices(string id) : base(id)
        {
        }

        public PartTimeServices(Save.PartTimeService serviceSave) : base(serviceSave.Id)
        {
            HoursPerWeek = serviceSave.HoursPerWeek;
            Salary = serviceSave.BaseSalary;
        }

    }

    public class SimpleWorkService : MainOccupation
    {
        public PositionConfiguration PositionConfiguration { get; set; }
        public float Salary { get; set; }
        public float Productivity { get; set; }
        public float DislikeFactor
        {
            get
            {
                return Organization.DislikeFactor;
            }
        }
        public float TargetDislikeFactor
        {
            get
            {
                return Organization.TargetDislikeFactor;
            }
        }

        public float Difficulty
        {
            get
            {
                return PositionConfiguration.Difficulty;
            }
        }

        public SimpleWorkService(string id) : base(id)
        {
        }
       
        public SimpleWorkService(Save.SimpleWorkService serviceSave) : base(serviceSave.Id)
        {
            HoursPerWeek = serviceSave.HoursPerWeek;
            Salary = serviceSave.Salary;
            Productivity = serviceSave.Productivity;
            BefriendProbability = serviceSave.BefriendProbability;
        }

        public float GetDislikeFactor(int years = 0)
        {
            if (years < 1)
            {
                return DislikeFactor;
            }
            else if (years < 2)
            {
                return DislikeFactor * 2 / 3 + TargetDislikeFactor * 1 / 3;
            }
            else if (years < 3)
            {
                return DislikeFactor * 1 / 3 + TargetDislikeFactor * 2 / 3;
            }
            else return TargetDislikeFactor;
        }

        //будет зависеть от места проживания, места работы
        public int GetHoursInRoad()
        {
            return 0;
        }

        public override string ToString()
        {
            return LocalizationDictionary.GetLocalizedString("occupation_job");
        }
    }
    public class MilitaryService : MainOccupation
    {
        public ArmyConfiguration PositionConfiguration { get; set; }
        public float Salary { get; set; }
        public float Productivity { get; set; }
        public float DislikeFactor
        {
            get
            {
                return Organization.DislikeFactor;
            }
        }
        public float TargetDislikeFactor
        {
            get
            {
                return Organization.TargetDislikeFactor;
            }
        }

        public float Difficulty
        {
            get
            {
                return PositionConfiguration.Difficulty;
            }
        }

        public MilitaryService(string id) : base(id)
        {
        }

        public MilitaryService(Save.MilitaryService serviceSave) : base(serviceSave.Id)
        {
            HoursPerWeek = serviceSave.HoursPerWeek;
            Salary = serviceSave.Salary;
            Productivity = serviceSave.Productivity;
            BefriendProbability = serviceSave.BefriendProbability;
        }

        public float GetDislikeFactor(int years = 0)
        {
            if (years < 1)
            {
                return DislikeFactor;
            }
            else if (years < 2)
            {
                return DislikeFactor * 2 / 3 + TargetDislikeFactor * 1 / 3;
            }
            else if (years < 3)
            {
                return DislikeFactor * 1 / 3 + TargetDislikeFactor * 2 / 3;
            }
            else return TargetDislikeFactor;
        }

        //будет зависеть от места проживания, места работы
        public int GetHoursInRoad()
        {
            return 0;
        }
    }
    }