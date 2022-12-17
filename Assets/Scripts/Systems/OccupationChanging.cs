using System;
using System.Linq;
using Components;
using Components.Events;
using Core;
using Leopotam.Ecs;
using Modules;
using Save;
using UnityEngine;
using CharacterComponent = Components.CharacterComponent;
using EducationService = Core.Education.EducationService;
using WorkService = Core.WorkService;
using SimpleWorkService = Core.SimpleWorkService;
using MilitaryService = Core.MilitaryService;
using Service = Core.Service;

namespace Systems
{
    public class OccupationChanging : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent, ChangeOccupation> _changeOccupationCharacterFilter;
        private EcsFilter<CharacterComponent, MainOccupationChanged> _mainOccupationChangedFilter;
        private EcsFilter<CharacterComponent, ChangePartTimeOccupation> _partTimeOccupationChangedFilter;

        public void Run()
        {
            foreach (var i in _mainOccupationChangedFilter)
            {
                _mainOccupationChangedFilter.GetEntity(i).Del<MainOccupationChanged>();
            }
            
            foreach (var i in _changeOccupationCharacterFilter)
            {
                var changeOccupation = _changeOccupationCharacterFilter.Get2(i);
                var changePatTimeOccupation = _partTimeOccupationChangedFilter.Get2(i);
                var character = _changeOccupationCharacterFilter.Get1(i).Character;

                if (changeOccupation.Service != null)
                {
                    GenerateColleaguesRequest(10, changeOccupation.Service);
                    character.OccupationHistory.Add(changeOccupation.Service, new Period
                    {
                        StartDate = WorldDateModule.CurrentDate,
                        EndDate = new WorldDate()
                    });
                }
                
                if (character.CurrentOccupation != null)
                {
                    character.OccupationHistory[character.CurrentOccupation].EndDate = WorldDateModule.CurrentDate;
                }

                character.CurrentPartTimeOccupations = changePatTimeOccupation.Service;
                character.CurrentOccupation = changeOccupation.Service;
                var smarts = character.Parameters.Get(ParameterType.Smarts.ToString()).Value;
                var endurance = character.Parameters.Get(ParameterType.Endurance.ToString()).Value;

                if (changeOccupation.Service is EducationService educationService)
                {
                    string message = $"{LocalizationDictionary.GetLocalizedString("occupation_change")} {educationService.ToString().ToLower()}";
                    character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(message, 99));
                    educationService.Productivity = (1 + smarts * 0.01f) * endurance * 0.01f;//todo выпилить WorkServica, переименовать SimpleWorkService в WorkService
                    if (educationService.Type != EducationType.PrimarySchool)
                        character.Parameters.Get(ParameterType.Stress.ToString()).Inc(UnityEngine.Random.Range(10f, 30f));

                } else if (changeOccupation.Service is WorkService workService)
                {
                    workService.Productivity = (1 + smarts * 0.01f) * endurance * 0.01f * workService.Difficulty; 
                    character.Parameters.Get(ParameterType.Stress.ToString()).Inc(UnityEngine.Random.Range(10f, 30f));
                }
                else if (changeOccupation.Service is MilitaryService MilitaryService)
                {
                    MilitaryService.Productivity = (1 + smarts * 0.01f) * endurance * 0.01f * MilitaryService.Difficulty; //todo
                }
                else if (changeOccupation.Service is SimpleWorkService simpleWorkService)
                {
                    simpleWorkService.Productivity = (1 + smarts * 0.01f) * endurance * 0.01f * simpleWorkService.Difficulty;
                    character.Parameters.Get(ParameterType.Stress.ToString()).Inc(UnityEngine.Random.Range(10f, 30f));
                }

                _changeOccupationCharacterFilter.GetEntity(i).Del<ChangeOccupation>();
                _changeOccupationCharacterFilter.GetEntity(i).Replace(new MainOccupationChanged());

                _world.NewEntity().Replace(new OccupationChanged { Sender = character});
            }
        }

        private void GenerateColleaguesRequest(int count, Service occupation)
        {
            for (var i = 0; i < count; i++)
            {
                _world.NewEntity().Replace(new NewColleague {IsClassmate = occupation is EducationService, Occupation = occupation});
            }
        }
    }
}