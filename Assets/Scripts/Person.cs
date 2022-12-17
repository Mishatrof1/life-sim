using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Modules;
using Settings;
using UnityEngine;
using static Settings.ZodiacSettings;

public class Person : BaseObject
{
    public WorldDate BirthDate { get; }
    public int Birthday { get; }
    public Parameters Parameters { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Genders Gender { get; set; }
    public int Sex { get; set; }
    public Sprite Avatar { get; set; }
    public Location BirthLocation { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public WorldDate Age => WorldDateModule.CurrentDate - BirthDate;
    public bool IsAppearenceChanging(WorldDate dateStart, WorldDate dateEnd)
    {
        var ageStageSettings = GameProcessingEcs.Instance.AgeStageSettings;

        var ageStart = (dateStart - BirthDate).TotalYears;
        var ageEnd = (dateEnd - BirthDate).TotalYears;

        var currStage = ageStageSettings.Stages.FirstOrDefault(fp => Age.TotalYears >= fp.YearMin && Age.TotalYears <= fp.YearMax);

        return !((ageStart >= currStage.YearMin && ageStart <= currStage.YearMax) && (ageEnd >= currStage.YearMin && ageEnd <= currStage.YearMax));
    }

    public Appearance Appearance { get; set; }
    public Accessories Accessories { get; set; }
    
    public Person(string id, WorldDate birthDate, int dayOfBirth = 0) : this(id, birthDate, new Parameters(), dayOfBirth)
    {
    }
    
    public Person(string id, WorldDate birthDate, Parameters parameters, int dayOfBirth = 0) : base(id)
    {
        BirthDate = birthDate;
        Parameters = parameters;
        Birthday = dayOfBirth;
    }
    
    public ZodiacSign Zodiac
    {
        get
        {
            return SettingsProvider.Instance.ZodiacSettings.CalculateSign(new DateTime().AddDays(Birthday));
        }
    }

}