using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Education;
using Core.Job;
using Core.Job.Simple;
using Modules;
using Popups;
using Settings.Job;
using Vacancy = Core.Job.Simple.Vacancy;

using Leopotam.Ecs;
using Components;
using UnityEngine;
using Modules.Navigation;

namespace Core
{
    public class Character : Person, IParametersOwner
    {
        public HashSet<Location> AvailableLocations { get; set; }
        public Location CurrentLocation { get; set; }
        public MainOccupation CurrentOccupation { get; set; }
        public PartTimeOccupations CurrentPartTimeOccupations {get;set;}
        public Dictionary<MainOccupation, Period> OccupationHistory { get; set; }
        public Dictionary<string, WorldDate> InkStoryHistory { get; set; }
        public AgeLog AgeLog { get; set; }
        public List<GraduationResult> GraduationResults { get; set; }

        public MainOccupation OutOccupation { get; set; }
        public Character(string id, WorldDate birthDate, Parameters parameters, int dayOfBirth) : base(id, birthDate, parameters, dayOfBirth)
        {
            AvailableLocations = new HashSet<Location>();
            OccupationHistory = new Dictionary<MainOccupation, Period>();
            InkStoryHistory = new Dictionary<string, WorldDate>();
            GraduationResults = new List<GraduationResult>();
            AgeLog = new AgeLog();
        }
        
        public Character(string id, WorldDate birthDate, int dayOfBirth) : this(id, birthDate, new Parameters(), dayOfBirth)
        {
        }
        
        public Character(Person person) : this(person.Id, person.BirthDate, person.Parameters, person.Birthday)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
            Gender = person.Gender;
            Avatar = person.Avatar;
            BirthLocation = person.BirthLocation;
            Appearance = person.Appearance;
            Accessories = person.Accessories;
        }
        
        public Character(Save.CharacterSave characterSave) : this(characterSave.Id, characterSave.BirthDate, characterSave.Birthday)
        {
            FirstName = characterSave.FirstName;
            LastName = characterSave.LastName;
            Gender = characterSave.Gender;
            Appearance = new Appearance(characterSave.AppearanceV2Save);
            Accessories = new Accessories(characterSave.AccessoriesSave);
            ProdDec = characterSave.ProdDec;
            ProdInc = characterSave.ProdInc;
            Parameters.Restore(characterSave.ParametersSave);
        }

        [Obsolete]
        public bool CheckForPositionRequirements(Position position)
        {
            var result = true;
            foreach (var requiredSkill in position.RequiredSkills)
            {
                result &= Parameters.Get($"{nameof(SkillType)}_{requiredSkill.Type.ToString()}").Value >= requiredSkill.Value;
            }
            if (position.RequiredExperience > 0)
            {
                var chainExperience = OccupationHistory
                    .Where(pair =>
                        pair.Key is WorkService workService &&
                        position.Chain.Positions.Any(pos => ReferenceEquals(pos, workService.Position)))
                    .Sum(x => x.Value.Duration.TotalMonths);
                result &= position.RequiredExperience <= WorldDate.FromMonths(chainExperience).TotalYears;
            }

            return result;
        }


        public void ResetProductivity()
        {
            ProdInc = 0;
            ProdDec = 0;
        }

        public int ProdInc { get; private set; }
        public int ProdDec { get; private set; }

        public bool IncreaseProductivity()
        {
            if (ProdInc >= 2) return false;

            var smarts = Parameters.Get(ParameterType.Smarts.ToString()).Value * 0.01f;
            var endurance = Parameters.Get(ParameterType.Endurance.ToString()).Value * 0.01f;
            var delta = 0.25f * (0.25f + smarts) * (0.25f + endurance);

            Parameters.Get(ParameterType.Stress.ToString()).Inc(UnityEngine.Random.Range(5f, 15f));

            if (CurrentOccupation is SimpleWorkService work)
            {
                delta *= (1 / work.Difficulty);
                work.Productivity += Math.Max(10,delta*100);
            }
            if (CurrentOccupation is MilitaryService service)
            {
                delta *= (1 / service.Difficulty);
                service.Productivity += Math.Max(10, delta * 100);
            }
            if (CurrentOccupation is EducationService education)
            {
                education.Productivity += Math.Max(10, delta*100);
            }

            ProdInc++;
            return true;
        }

        public bool DecreaseProductivity()
        {
            if (ProdDec >= 2) return false;

            var smarts = Parameters.Get(ParameterType.Smarts.ToString()).Value * 0.01f;
            var endurance = Parameters.Get(ParameterType.Endurance.ToString()).Value * 0.01f;
            var delta = 0.25f * (1.1f - smarts) * (1.1f - endurance);

            Parameters.Get(ParameterType.Stress.ToString()).Dec(UnityEngine.Random.Range(5f,10f));

            if (CurrentOccupation is SimpleWorkService work)
            {
                var yearsInOrganization = OccupationHistory[CurrentOccupation].Duration.TotalYears;
                var dislikeFactor = work.GetDislikeFactor(yearsInOrganization);
                if (dislikeFactor > 0)
                    delta *= 1 / dislikeFactor;
                else delta *= 0;
                work.Productivity = work.Productivity - delta;
            }
            if (CurrentOccupation is MilitaryService service)
            {
                var yearsInOrganization = OccupationHistory[CurrentOccupation].Duration.TotalYears;
                var dislikeFactor = service.GetDislikeFactor(yearsInOrganization);
                if (dislikeFactor > 0)
                    delta *= 1 / dislikeFactor;
                else delta *= 0;
                service.Productivity = service.Productivity - delta;
            }
            if (CurrentOccupation is EducationService education)
            {
                education.Productivity = education.Productivity - delta;
            }
            
            ProdDec++;
            return true;
        }
    }
}