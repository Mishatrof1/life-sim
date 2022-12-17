using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Core;
using Leopotam.Ecs;
using Modules;
using Save;
using Settings;
using Settings.Job;
using Settings.Job.Simple;
using UnityEngine;
using Organization = Save.Organization;
using SimpleWorkService = Save.SimpleWorkService;
using WorkService = Save.WorkService;
using MilitaryService = Save.MilitaryService;

namespace Systems.Save
{
    public class SaveData : IEcsRunSystem
    {
        private EcsFilter<Focus> _focusFilter;
        private EcsFilter<Pause> _pauseFilter;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<NpcComponent> _npcComponent;
        private EcsFilter<OrganizationComponent> _organizationFilter;
        
        private SpriteSet _spriteSet;
        private PositionChainSet _positionChainSet;
        private PositionsSettings _positionsSettings;
        private PartTimePositionSettings _partTimePositionsSettings;
        private ArmySettings _armySettings;
        private SaveDataProvider _saveDataProvider;

        public void Run()
        {
            var save = false;
            
            foreach (var i in _focusFilter)
            {
                save |= !_focusFilter.Get1(i).HasFocus;
                _focusFilter.GetEntity(i).Destroy();
            }
            
            foreach (var i in _pauseFilter)
            {
                save |= _pauseFilter.Get1(i).IsPaused;
                _pauseFilter.GetEntity(i).Destroy();
            }

            if (!save)
                return;
            
            SetSaveData();
            _saveDataProvider.Save();
            Debug.Log($"<color=yellow>All data saved ({Application.persistentDataPath}).</color>");
        }
        
        private void SetSaveData()
        {
            var globalSaveData = _saveDataProvider.GetSaveData<GlobalSaveData>();
            var characterSaveData = _saveDataProvider.GetSaveData<CharacterSaveData>();
            var npcSaveData = _saveDataProvider.GetSaveData<NpcSaveData>();
            var locationsSaveData = _saveDataProvider.GetSaveData<LocationsSaveData>();
            var organizationsSaveData = _saveDataProvider.GetSaveData<OrganizationsSaveData>();
            var servicesSaveData = _saveDataProvider.GetSaveData<ServicesSaveData>();

            globalSaveData.ResetSaveData();
            characterSaveData.ResetSaveData();
            locationsSaveData.ResetSaveData();
            organizationsSaveData.ResetSaveData();
            servicesSaveData.ResetSaveData();
            npcSaveData.ResetSaveData();
            
            locationsSaveData.Locations = new List<global::Save.Location>();
            
            globalSaveData.CurrentDate = WorldDateModule.CurrentDate;
            globalSaveData.SoundState = SoundProvider.Instance.SoundState;
            globalSaveData.savedLanguage = LocalizationDictionary.Language;
            
            foreach (var i in _charactersFilter)
            {
                var character = _charactersFilter.Get1(i).Character;
                characterSaveData.Character = new CharacterSave
                {
                    Id = character.Id,
                    AvatarSpriteIndex = _spriteSet.SpriteList.IndexOf(character.Avatar),
                    AvailableLocations = character.AvailableLocations.Select(loc => loc.Id).ToList(),
                    BirthLocationId = character.BirthLocation?.Id,
                    BirthDate = character.BirthDate,
                    Birthday = character.Birthday,
                    CurrentLocation = character.CurrentLocation?.Id,
                    CurrentOccupation = character.CurrentOccupation?.Id,
                    PartTimeOccupation = character.CurrentPartTimeOccupations?.Id,
                    OccupationHistory = character.OccupationHistory.Select(period => new OccupationPeriodSave
                    {
                        ServiceId = period.Key.Id,
                        StartDate = period.Value.StartDate,
                        EndDate = period.Value.EndDate
                    }).ToList(),
                
                    InkStoryHistory = character.InkStoryHistory.Select(story => new InkStorySave
                    {
                        StoryName = story.Key,
                        Year = story.Value
                    }).ToList(),
                    FirstName = character.FirstName,
                    LastName = character.LastName,
                    Gender = character.Gender,
                    AgeLog = character.AgeLog.GetAgeLogSaveData(),
                    AppearanceV2Save = new AppearanceSave(character.Appearance),
                    AccessoriesSave = new AccessoriesSave(character.Accessories),

                    ParametersSave = character.Parameters.SaveList(),
                    GraduationResultSaves = character.GraduationResults.Select(gr => new GraduationResultSave(gr)).ToList(),
                    ProdInc = character.ProdInc,
                    ProdDec = character.ProdDec
                };
                
                foreach (var characterAvailableLocation in character.AvailableLocations)
                {
                    locationsSaveData.Locations.Add(new global::Save.Location
                    {
                        Id = characterAvailableLocation.Id,
                        Country = characterAvailableLocation.Country,
                        City = characterAvailableLocation.City,
                        TrafficJamFactor = 0,
                        PublicTransport = 1
                    });
                }
            }

            foreach (var i in _npcComponent)
            {
                var npc = _npcComponent.Get1(i).Npc;
                npcSaveData.Npcs.Add(new NpcSave
                {
                    Id = npc.Id,
                    AvatarSpriteIndex = _spriteSet.SpriteList.IndexOf(npc.Avatar),
                    BirthLocationId = npc.BirthLocation?.Id,
                    BirthDate = npc.BirthDate,
                    CurrentOccupationId = npc.CurrentOccupation?.Id,
                    FirstName = npc.FirstName,
                    LastName = npc.LastName,
                    Gender = npc.Gender,
                    ParametersSave = npc.Parameters.SaveList(),
                    AppearanceV2Save = new AppearanceSave(npc.Appearance),
                    AccessoriesSave = new AccessoriesSave(npc.Accessories),
                    FlirtProgress = npc.FlirtProgress,
                    BefriendProgress = npc.BefriendProgress,
                    Relationships = npc.Relationships.Select(r => new RelationshipSave
                    {
                        Id = r.Person.Id,
                        RelationshipType = r.RelationshipType
                    }).ToList(),
                    
                    ComplimentYearCount = npc.CommunicationYearCount,
                    CommunicationYearCount = npc.CommunicationYearCount,
                    SpendTimeYearCount = npc.SpendTimeYearCount,
                    GiftYearCount = npc.GiftYearCount,
                    PositiveStoryYearCount = npc.PositiveStoryYearCount,
                    NegativeStoryYearCount = npc.NegativeStoryYearCount,
                    InsultYearCount = npc.InsultYearCount,
                    FightYearCount = npc.FightYearCount,
                    DateYearCount = npc.DateYearCount,
                    SexYearCount = npc.SexYearCount,
                    UnFriendYearsCount = npc.UnFriendYearsCount
                });
                
                locationsSaveData.Locations.Add(new global::Save.Location
                {
                    Id = npc.BirthLocation?.Id,
                    Country = npc.BirthLocation?.Country,
                    City = npc.BirthLocation?.City,
                    TrafficJamFactor = 0,
                    PublicTransport = 1
                });
            }

            foreach (var i in _organizationFilter)
            {
                var organization = _organizationFilter.Get1(i).Organization;
                
                organizationsSaveData.Organizations.Add(new Organization
                {
                    Id = organization.Id,
                    Name = organization.Name,
                    Type = organization.Type,
                    ScopeType = organization.ScopeType,
                    LocationId = organization.Location.Id,
                    DislikeFactor = organization.DislikeFactor,
                    TargetDislikeFactor = organization.TargetDislikeFactor
                });
                
                foreach (var service in organization.Services)
                {
                    switch (service)
                    {
                        case Core.Education.EducationService s:
                        {
                            servicesSaveData.EducationServices.Add(new EducationService(s));
                            break;
                        }
                        case Core.WorkService s:
                        {
                            var workServiceSave = new WorkService(s);
                            var chain = _positionChainSet.Chains.FirstOrDefault(chain =>
                                chain.Positions.Any(p => ReferenceEquals(p, s.Position)));
                            var position = chain?.Positions.FirstOrDefault(p => ReferenceEquals(p, s.Position));
                            
                            workServiceSave.PositionChainIndex =
                                chain != null ? _positionChainSet.Chains.IndexOf(chain) : -1;
                            workServiceSave.PositionIndex =
                                position != null ? chain.Positions.IndexOf(position) : -1;
                            servicesSaveData.WorkServices.Add(workServiceSave);
                            break;
                        }
                        case Core.SimpleWorkService s:
                        {
                            var simpleWorkServiceSave = new SimpleWorkService(s);
                            simpleWorkServiceSave.PositionConfigurationIndex =
                                _positionsSettings.Configurations.IndexOf(s.PositionConfiguration);
                            servicesSaveData.SimpleWorkServices.Add(simpleWorkServiceSave);
                            break;
                        }
                        case Core.PartTimeServices s:
                        {
                            var partTimeWorkServiceSave = new PartTimeService(s);
                                partTimeWorkServiceSave.PartTimePositionConfiguration =
                                _partTimePositionsSettings.Configurations.IndexOf(s.PartTimePositionConfiguration);
                            servicesSaveData.PartTimeService.Add(partTimeWorkServiceSave);
                            break;
                        }
                        case Core.MilitaryService s:
                            {
                                var simpleWorkServiceSave = new MilitaryService(s);
                                simpleWorkServiceSave.PositionConfigurationIndex =
                                    _armySettings.Configurations.IndexOf(s.PositionConfiguration);
                                servicesSaveData.MilitaryServices.Add(simpleWorkServiceSave);
                                break;
                            }
                    }
                }
                
                locationsSaveData.Locations.Add(new global::Save.Location
                {
                    Id = organization.Location.Id,
                    Country = organization.Location.Country,
                    City = organization.Location.City,
                    TrafficJamFactor = 0,
                    PublicTransport = 1
                });
            }
        }
    }
}