using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.Education;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Save;
using Settings;
using Settings.Education;
using Settings.Job;
using Settings.Job.Simple;
using UnityEngine;
using CharacterComponent = Components.CharacterComponent;
using EducationService = Save.EducationService;
using MainOccupation = Core.MainOccupation;
using PartTimeOccupations = Core.PartTimeOccupations;
using Organization = Core.Organization;
using SimpleWorkService = Save.SimpleWorkService;
using PartTimeService = Save.PartTimeService;
using MilitaryService = Save.MilitaryService;
using WorkService = Save.WorkService;

namespace Systems
{
    public class GameInit : IEcsInitSystem
    {
        private EcsWorld _world;

        private NavigationSettings _navigationSettings;
        private SaveDataProvider _saveDataProvider;
        private WorldGenerator _worldGenerator;
        private WorldDateModule _worldDateModule;
        private SpriteSet _spriteSet;
        private PositionChainSet _positionChainSet;
        private PositionsSettings _positionsSettings;
        private PartTimePositionSettings _partTimePositionsSettings;
        private ArmySettings _armySettings;
        private StudyDirectionSettings _studyDirectionSettings;
        private GlobalSettings _globalSettings;

        public void Init()
        {
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
            Application.targetFrameRate = 60;
#endif
#if UNITY_EDITOR
            if (_globalSettings.ResetSaveOnStart)
            {
                _saveDataProvider.Clear();
            }
#endif
            
            var characterSaveData = _saveDataProvider.GetSaveData<CharacterSaveData>();
            
            if (string.IsNullOrEmpty(characterSaveData.Character?.Id))
            {
                _world.NewEntity().Replace(new NewCharacter());
                var language = Application.systemLanguage;
                LocalizationDictionary.Setup(_globalSettings,language);
            }
            else
            {
                SetupFromSave();
            }

            var mainNavBlock = new NavigationBlock(NavigationBlockType.Main, NavigationElementType.MainScreen,
                _navigationSettings.Sets.First(s => s.BlockType == NavigationBlockType.Main).Set);
            _world.NewEntity()
                .Replace(new BlockComponent
                {
                    Block = mainNavBlock
                });
            
            var menuBlock = new NavigationBlock(NavigationBlockType.Menu, NavigationElementType.Menu,
                _navigationSettings.Sets.First(s => s.BlockType == NavigationBlockType.Menu).Set);
            _world.NewEntity()
                .Replace(new BlockComponent
                {
                    Block = menuBlock
                });
        }

        private void SetupFromSave()
        {
            var globalSaveData = _saveDataProvider.GetSaveData<GlobalSaveData>();
            var characterSaveData = _saveDataProvider.GetSaveData<CharacterSaveData>();
            var npcSaveData = _saveDataProvider.GetSaveData<NpcSaveData>();
            var locationsSaveData = _saveDataProvider.GetSaveData<LocationsSaveData>();
            var organizationsSaveData = _saveDataProvider.GetSaveData<OrganizationsSaveData>();
            var servicesSaveData = _saveDataProvider.GetSaveData<ServicesSaveData>();
            
            var characterSave = characterSaveData.Character;
            if (characterSave == null)
                return;
            
            _worldDateModule.Restore(globalSaveData);
            SoundProvider.Instance.ChangeSoundState(globalSaveData.SoundState);
            LocalizationDictionary.Setup(_globalSettings, globalSaveData.savedLanguage);

            var locations = locationsSaveData.Locations.Select(locSave => new Core.Location(locSave)).ToList();
            locations.ForEach(loc => _world.NewEntity().Replace(new LocationComponent
            {
                Location = loc
            }));

            var organizations = new List<Organization>();
            foreach (var organizationSave in organizationsSaveData.Organizations)
            {
                var organization = new Organization(organizationSave.Id)
                {
                    Name = organizationSave.Name,
                    Type = organizationSave.Type,
                    ScopeType = organizationSave.ScopeType,
                    Location = locations.First(loc => loc.Id == organizationSave.LocationId),
                    DislikeFactor = organizationSave.DislikeFactor,
                    TargetDislikeFactor = organizationSave.TargetDislikeFactor
                };
                organizations.Add(organization);
                _world.NewEntity()
                    .Replace(new OrganizationComponent { Organization = organization });
            }

            var servicesSave =
                servicesSaveData.EducationServices.Cast<global::Save.Service>().Concat(servicesSaveData.WorkServices)
                    .Concat(servicesSaveData.SimpleWorkServices);
            var partTimeServicesSave =
                servicesSaveData.PartTimeService.Cast<global::Save.Service>();
            
            foreach (var serviceSave in servicesSave)
            {
                switch (serviceSave)
                {
                    case EducationService s:
                        {
                            var organization = organizations.First(org => org.Id == s.OrganizationId);
                            var service = new Core.Education.EducationService(s,
                                _studyDirectionSettings.GetStudyDirections()
                                    .FirstOrDefault(d => d.Type.ToString() == s.StudyDirection));
                            organization.AddService(service);
                            break;
                        }
                    case WorkService s:
                        {
                            var organization = organizations.First(org => org.Id == s.OrganizationId);
                            var service = new Core.WorkService(s);
                            if (s.PositionChainIndex >= 0 && s.PositionIndex >= 0)
                            {
                                service.Position = _positionChainSet.Chains[s.PositionChainIndex]
                                    .Positions[s.PositionIndex];
                            }
                            organization.AddService(service);
                            break;
                        }
                    case SimpleWorkService s:
                        {
                            var organization = organizations.First(org => org.Id == s.OrganizationId);
                            var service = new Core.SimpleWorkService(s);
                            service.PositionConfiguration = _positionsSettings.Configurations[s.PositionConfigurationIndex];
                            organization.AddService(service);
                            break;
                        }
                    case MilitaryService s:
                        {
                            var organization = organizations.First(org => org.Id == s.OrganizationId);
                            var service = new Core.MilitaryService(s);
                            service.PositionConfiguration = _armySettings.Configurations[s.PositionConfigurationIndex];
                            organization.AddService(service);
                            break;
                        }
                }
            }
            foreach (var serviceSave in partTimeServicesSave)
            {
                switch (serviceSave)
                {
                    case PartTimeService s:
                    {
                        var organization = organizations.First(org => org.Id == s.OrganizationId);
                        var service = new Core.PartTimeServices(s);
                        service.PartTimePositionConfiguration = _partTimePositionsSettings.Configurations[s.PartTimePositionConfiguration];
                        organization.AddService(service);
                        break;
                    }
                }
            }

            var npcs = new List<Npc>();
            foreach (var npcSave in npcSaveData.Npcs)
            {
                var birthLocation = locationsSaveData.Locations.FirstOrDefault(locSave =>
                    locSave.Id == npcSave.BirthLocationId);
                
                var npc = new Npc(npcSave)
                {
                    Avatar = _spriteSet.SpriteList?[
                        Mathf.Clamp(npcSave.AvatarSpriteIndex, 0,
                            _spriteSet.SpriteList.Count)],
                    CurrentOccupation = npcSave.CurrentOccupationId != null
                        ? organizations.SelectMany(org => org.Services.Where(s => s is MainOccupation))
                            .FirstOrDefault(s => s.Id == npcSave.CurrentOccupationId)
                        : null,
                    BirthLocation = birthLocation != null
                        ? new Core.Location(birthLocation)
                        : null
                };

                _world.NewEntity()
                    .Replace(new NpcComponent {Npc = npc})
                    .Replace(new ParametersComponent {ParametersOwner = npc})
                    .Replace(new PersonComponent {Person = npc});
                
                npcs.Add(npc);
            }

            var characterBirthLocation = locationsSaveData.Locations.FirstOrDefault(locSave =>
                locSave.Id == characterSave.BirthLocationId);
            var characterCurrentLocation = locationsSaveData.Locations.FirstOrDefault(locSave =>
                locSave.Id == characterSave.CurrentLocation);

            var mainOccupationServices = organizations.SelectMany(org => org.Services.Where(s => s is MainOccupation))
                .Cast<MainOccupation>().ToList();
            var partTimeServices = organizations.SelectMany(org => org.Services.Where(s => s is PartTimeOccupations))
                .Cast<PartTimeOccupations>().ToList();

            var avatar =
                _spriteSet.SpriteList?[Mathf.Clamp(characterSave.AvatarSpriteIndex, 0, _spriteSet.SpriteList.Count)];
            var availableLocations = new HashSet<Core.Location>(locationsSaveData.Locations
                .Where(locSave => characterSave.AvailableLocations.Any(id => id == locSave.Id))
                .Select(locSave => new Core.Location(locSave)));
            var charBirthLocation = characterBirthLocation != null
                ? new Core.Location(characterBirthLocation)
                : null;
            var currentLocation = characterCurrentLocation != null
                ? new Core.Location(characterCurrentLocation)
                : null;
            var currentOccupation = characterSave.CurrentOccupation != null
                ? mainOccupationServices.FirstOrDefault(s => s.Id == characterSave.CurrentOccupation)
                : null;
            var currentPartTimeOccupation = characterSave.PartTimeOccupation != null
                ? partTimeServices.FirstOrDefault(s => s.Id == characterSave.PartTimeOccupation)
                : null;
            var occupationHistory = characterSave.OccupationHistory
                .ToDictionary(
                    x => mainOccupationServices.FirstOrDefault(s => s.Id == x.ServiceId),
                    x => new Period
                    {
                        StartDate = x.StartDate,
                        EndDate = x.EndDate
                    });
            var inkStoryHistory = characterSave.InkStoryHistory != null
                ? characterSave.InkStoryHistory.ToDictionary(
                    x => x.StoryName,
                    x => x.Year)
                : new Dictionary<string, WorldDate>();
            var graduationResults = characterSave.GraduationResultSaves
                .Select(gr =>
                {
                    var result = new GraduationResult(gr);
                    result.EducationService =
                        organizations.First(org => org.Services.Any(s => s.Id == gr.EducationService)).Services
                            .First(s => s.Id == gr.EducationService) as Core.Education.EducationService;
                    return result;
                }).ToList();
            var character = new Core.Character(characterSave)
            {
                Avatar = avatar,
                AvailableLocations = availableLocations,
                BirthLocation = charBirthLocation,
                CurrentLocation = currentLocation,
                CurrentOccupation = currentOccupation,
                CurrentPartTimeOccupations = currentPartTimeOccupation,
                OccupationHistory = occupationHistory,
                InkStoryHistory = inkStoryHistory,
                GraduationResults = graduationResults,
                AgeLog = new AgeLog(characterSave.AgeLog),
            };

            var persons = npcs.Cast<Person>();
            persons = persons.Append(character).ToList();

            foreach (var npcSave in npcSaveData.Npcs)
            {
                var npc = npcs.First(n => n.Id == npcSave.Id);
                npc.Relationships = npcSave.Relationships?.Select(rSave => new Relationship
                {
                    Person = persons.First(p => p.Id == rSave.Id),
                    RelationshipType = rSave.RelationshipType
                }).ToList() ?? new List<Relationship>();
            }

            _world.NewEntity()
                .Replace(new CharacterComponent { Character = character })
                .Replace(new ParametersComponent {ParametersOwner = character})
                .Replace(new PersonComponent {Person = character});
        }
    }
}