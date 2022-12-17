using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Education;
using UnityEngine;
using UnityEngine.Serialization;
using Settings;

[CreateAssetMenu(fileName = "PositionConfiguration", menuName = "LifeSim/PartTime/Position configuration", order = 0)]
    public class PartTimePositionConfiguration : ScriptableObject
    {
        public string NameDefault;
        public Sprite Icon;
        [Header("Vacancy parameters")]
        public int HoursPerWeek;
        public int HourlyRate;

        public OrganizationConfiguration PossibleOrganizations;

        [HideInInspector]public int Age = 14;

        public Conditions[] Conditions;
        public EducationParameter[] Education;
        

    public bool IsMatchVacancyRequirement(Character character)
        {
        return IsMatch(character) && EducationTest(character) && character.Age.TotalYears >= Age;
        }

    public bool IsMatch(Character character)
    {
        return true;
        if (Conditions.Length != 0)
        {
            return (character.Parameters.Get(Conditions[0].Parameter.ToString()).Value >= Conditions[0].Value);
        }
        else
        {
            return character.Age.TotalYears >= Age;
        }
    }

    public bool EducationTest(Character character)
    {
        if (Education.Length != 0)
        {
            if (character.CurrentOccupation is EducationService education)
            {
                return education.Type == Education[0].EducationType;
            }
            return false;
        }
        return true;
    }
}
[Serializable]
public struct Conditions
{
    public ParameterType Parameter;
    public float Value;
}
[Serializable]
public struct EducationParameter
{
public EducationType EducationType;
}


