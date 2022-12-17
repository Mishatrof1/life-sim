using System.Collections.Generic;
using System.Globalization;
using Components;
using Core;
using Leopotam.Ecs;
using Popups;
using UnityEngine;
using CharacterComponent = Components.CharacterComponent;

namespace Systems
{
    public class Profile : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent, ShowProfile> _showProfileFilter;

        private string _partTimeJobName;

        public void Run()
        {
            foreach (var i in _showProfileFilter)
            {
                var character = _showProfileFilter.Get1(i).Character;
                if (character.CurrentPartTimeOccupations is PartTimeServices partTimeService)
                {
                    _partTimeJobName = partTimeService.PartTimePositionConfiguration.NameDefault;
                }

                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<ProfilePopup>(new ProfilePopup
                    {
                        Person = character,
                        Gender = character.Gender,
                        NameText = character.FullName,
                        StatusText = $"{character.Age.TotalYears} {LocalizationDictionary.GetLocalizedString("age_string")}, {character.Gender}",
                        OccupationText = character.CurrentOccupation == null ? "" : character.CurrentOccupation.ToString(),
                        PartTimeJobText = _partTimeJobName,
                        MaterialStatusText = LocalizationDictionary.GetLocalizedString("materialstatus_single"),
                        HappinessSliderValue = character.Parameters.Get(ParameterType.Happiness.ToString()).NormalizedValue,
                        HealthSliderValue = character.Parameters.Get(ParameterType.Health.ToString()).NormalizedValue,
                        LooksSliderValue = character.Parameters.Get(ParameterType.Looks.ToString()).NormalizedValue,
                        SmartSliderValue = character.Parameters.Get(ParameterType.Smarts.ToString()).NormalizedValue
                    })
                });}
            }
        }
    }