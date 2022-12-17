using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Core;
using Core.Education;
using Core.Job;
using Core.Job.Simple;
using Leopotam.Ecs;
using Settings;
using Settings.Accessories;
using Settings.Appearance;
using Settings.Job;
using Settings.Job.Simple;
using UnityEngine;
using Organization = Save.Organization;
using Random = System.Random;
using Vacancy = Core.Job.Simple.Vacancy;

namespace Modules
{
    public class WorldGenerator
    {
        private readonly WorldGenerationSettings _worldGenerationSettings;
        private readonly EmployerSet _employerSet;
        private readonly GlobalSettings _globalSettings;

        private List<string> _firstNamesFemale;
        private List<string> _firstNamesMale;
        private List<string> _lastNames;

        public Random Random { get; }

        public WorldGenerator(WorldGenerationSettings worldGenerationSettings, EmployerSet employerSet, GlobalSettings globalSettings)
        {
            _worldGenerationSettings = worldGenerationSettings;
            _employerSet = employerSet;
            _globalSettings = globalSettings;
            Random = new Random(DateTime.Now.Millisecond);
            SetupNamesCollections();
        }

        public Parameters GenerateEmployerParameters(OrganizationType type, Parameters parameters)
        {
            var employerTypeSettings = _employerSet.Employers.First(em => em.EmployerType == type);
            parameters.Add(OrganizationParameter.Wealth.ToString(),
                new Parameter(Random.Next(employerTypeSettings.WealthIndexRange.Min,
                    employerTypeSettings.WealthIndexRange.Max + 1) * 0.01f, 0));
            parameters.Add(OrganizationParameter.Stability.ToString(),
                new Parameter(Random.Next(employerTypeSettings.StabilityIndexRange.Min,
                    employerTypeSettings.StabilityIndexRange.Max + 1) * 0.01f, 0));
            return parameters;
        }

        public Person GeneratePersonData(WorldDate birthDate, AppearanceSettingsList settings, int dayOfBirth = 0)
        {
            var person = new Person(Guid.NewGuid().ToString(), birthDate, dayOfBirth)
            {
                Gender = Random.Next(0, 2) == 0 ? Genders.Male : Genders.Female
            };
            person.FirstName = GetFirstName(person.Gender);
            person.LastName = _lastNames[Random.Next(0, _lastNames.Count)];
            person.Avatar = GenerateAvatar(person.Gender, person.Age);
            person.Appearance = GenerateAppearance(person.Age.TotalYears, person.Gender, settings);
            return person;
        }

        public Appearance GenerateAppearance(int age, Genders gender, AppearanceSettingsList settings)
        {
            var currentSettings =
                settings.AppearanceSettings.First(s => s.Gender == gender && (age >= s.MinAge && age < s.MaxAge));
            var result = new Appearance();
            foreach (var appearanceGroup in currentSettings.AppearanceGroups)
            {
                var index = UnityEngine.Random.Range(0, appearanceGroup.SlotList.Count);
                result.AppearanceGroupsState.Add(appearanceGroup.name, new AppearanceGroupState
                {
                    Index = index
                });
                
                foreach (var slot in appearanceGroup.SlotList[index].Slots)
                {
                    if (!result.ColorGroupsState.ContainsKey(slot.ColorGroup.name))
                    {
                        result.ColorGroupsState.Add(slot.ColorGroup.name, new ColorGroupState
                        {
                            Index = UnityEngine.Random.Range(0, slot.ColorGroup.Colors.Count)
                        });
                    }
                }
            }

            return result;
        }

        public Accessories GenerateAccessories(int age, AccessorySettingsList settings)
        {
            var result = new Accessories();
            var availableGroups = settings.AccessorySettings.Where(s => age >= s.MinAge && age < s.MaxAge).ToList();
            foreach (var group in availableGroups)
            {
                if (UnityEngine.Random.Range(0, 2) > 0)
                    continue;

                var groupItemIndex = UnityEngine.Random.Range(0, group.SlotLists.Count);
                result.AppliedAccessories.Add(group.name, groupItemIndex);

                foreach (var slotData in group.SlotLists[groupItemIndex].Slots)
                {
                    if (!result.ColorGroups.ContainsKey(slotData.ColorGroup.name))
                    {
                        result.ColorGroups.Add(slotData.ColorGroup.name, UnityEngine.Random.Range(0, slotData.ColorGroup.Colors.Count));
                    }
                }
            }
            return result;
        }

        public Character GenerateCharacter(WorldDate characterBirthDate, AppearanceSettingsList settings, bool generateMaxParameters)
        {
            var character = new Character(GeneratePersonData(characterBirthDate, settings, Random.Next(364)));
            character.BirthLocation = GenerateLocationData();
            return SetupCharacterParameters(character, generateMaxParameters);
        }

        private Character SetupCharacterParameters(Character character, bool generateMaxValues)
        {
            character.Parameters.Add(ParameterType.Balance.ToString(), new Parameter());

#if UNITY_EDITOR
            character.Parameters.Get(ParameterType.Balance.ToString()).Set(_globalSettings.StartBalance);
#endif
            
            var minValue = generateMaxValues ? 100 : 10;
            
            character.Parameters.Add(ParameterType.Looks.ToString(), new Parameter(Random.Next(minValue,101), 0, 100));
            character.Parameters.Add(ParameterType.Health.ToString(), new Parameter(Random.Next(minValue,101), 0, 100));
            character.Parameters.Add(ParameterType.Smarts.ToString(), new Parameter(Random.Next(minValue,101), 0, 100));
            character.Parameters.Add(ParameterType.Happiness.ToString(), new Parameter(Random.Next(minValue,101), 0, 100));
            character.Parameters.Add(ParameterType.Strength.ToString(), new Parameter(Random.Next(minValue,101), 0, 100));
            character.Parameters.Add(ParameterType.Willpower.ToString(), new Parameter(Random.Next(minValue,101), 0, 100));
            character.Parameters.Add(ParameterType.Endurance.ToString(), new Parameter(Utils.NormalDistribution(0, 100, 50, 10), 0, 100));
            character.Parameters.Add(ParameterType.Kindness.ToString(), new Parameter(Random.Next(-50,51), -50, 50));
            character.Parameters.Add(ParameterType.Conformity.ToString(), new Parameter(0, -50, 50));            
            character.Parameters.Add(ParameterType.Wealth.ToString(), new Parameter()); //todo финансовая система
            character.Parameters.Add(ParameterType.Stress.ToString(), new Parameter(0,0,100));
            character.Parameters.Add(ParameterType.Art.ToString(), new Parameter(Random.Next(5, 100), 0, 100));
            character.Parameters.Add(ParameterType.Physical.ToString(), new Parameter(Random.Next(5, 100), 0, 100));
            character.Parameters.Add(ParameterType.IT.ToString(), new Parameter(Random.Next(5, 100), 0, 100));
            character.Parameters.Add(ParameterType.Tech.ToString(), new Parameter(Random.Next(5, 100), 0, 100));
            character.Parameters.Add(ParameterType.Academ.ToString(), new Parameter(Random.Next(5, 100), 0, 100));
            character.Parameters.Add(ParameterType.Math.ToString(), new Parameter(Random.Next(5, 100), 0, 100));
            character.Parameters.Add(ParameterType.Natural_Philosofy.ToString(), new Parameter(Random.Next(5, 100), 0, 100));
            character.Parameters.Add(ParameterType.Apllied.ToString(), new Parameter(Random.Next(5, 100), 0, 100));

           
            return character;
        }
        
        private Npc SetupNpcParameters(Npc npc)
        {
            npc.Parameters.Add(ParameterType.Looks.ToString(), new Parameter(Random.Next(10,101), 0, 100));
            npc.Parameters.Add(ParameterType.Health.ToString(), new Parameter(Random.Next(10,101), 0, 100));
            npc.Parameters.Add(ParameterType.Smarts.ToString(), new Parameter(Random.Next(10,101), 0, 100));
            npc.Parameters.Add(ParameterType.Relationship.ToString(), new Parameter(Random.Next(-10,81), -100, 100));
            npc.Parameters.Add(ParameterType.Happiness.ToString(), new Parameter(Random.Next(10,101), 0, 100));
            npc.Parameters.Add(ParameterType.Kindness.ToString(), new Parameter(Random.Next(-50,51), -50, 50));
            npc.Parameters.Add(ParameterType.Conformity.ToString(), new Parameter(Random.Next(-50,51), -50, 50));
            npc.Parameters.Add(ParameterType.Optimism.ToString(), new Parameter(Random.Next(-50,51), -50, 50));
            npc.Parameters.Add(ParameterType.Extroversion.ToString(), new Parameter(Random.Next(-50,51), -50, 50));
            npc.Parameters.Add(ParameterType.Sympathy.ToString(), new Parameter(Random.Next(0,81), 0, 100));
            npc.Parameters.Add(ParameterType.Willpower.ToString(), new Parameter(Random.Next(0,100), 0, 100));
            npc.Parameters.Add(ParameterType.Generosity.ToString(), new Parameter(Random.Next(0, 100), 0,100));
            npc.Parameters.Add(ParameterType.Balance.ToString(), new Parameter(10000,0)); //todo деньги по умолчанию
            npc.Parameters.Add(ParameterType.Wealth.ToString(), new Parameter()); //todo финансовая система
            npc.Parameters.Add(ParameterType.Art.ToString(), new Parameter(Random.Next(0, 100), 0, 100));
            npc.Parameters.Add(ParameterType.Physical.ToString(), new Parameter(Random.Next(0, 100), 0, 100));
            npc.Parameters.Add(ParameterType.IT.ToString(), new Parameter(Random.Next(0, 100), 0, 100));
            npc.Parameters.Add(ParameterType.Tech.ToString(), new Parameter(Random.Next(0, 100), 0, 100));
            npc.Parameters.Add(ParameterType.Academ.ToString(), new Parameter(Random.Next(0, 100), 0, 100));
            npc.Parameters.Add(ParameterType.Math.ToString(), new Parameter(Random.Next(0, 100), 0, 100));
            npc.Parameters.Add(ParameterType.Natural_Philosofy.ToString(), new Parameter(Random.Next(0, 100), 0, 100));
            npc.Parameters.Add(ParameterType.Apllied.ToString(), new Parameter(Random.Next(0, 100), 0, 100));
            return npc;
        }

        public Npc GenerateParentData(Person character, AppearanceSettingsList settings, Genders npcGender, AccessorySettingsList accessorySettingsList)
        {
            var person = GeneratePersonData(character.BirthDate - (WorldDate.FromYears(Random.Next(16, 25))), settings);
            var overrideAppearance = GenerateAppearance(person.Age.TotalYears, npcGender, settings);
            var npc = new Npc(person)
            {
                Gender = npcGender,
                LastName = character.LastName,
                BirthLocation = character.BirthLocation,
                Appearance = overrideAppearance,
                Accessories = GenerateAccessories(person.Age.TotalYears, accessorySettingsList)
            };

            npc.Relationships.Add(new Relationship
            {
                Person = character,
                RelationshipType = npcGender == Genders.Female ? RelationshipType.Mother : RelationshipType.Father
            });
            
            return SetupNpcParameters(npc);
        }

        public Npc GenerateSiblingData(Person character, AppearanceSettingsList settings, Genders npcGender, AccessorySettingsList accessorySettingsList)
        {
            var person = GeneratePersonData(character.BirthDate, settings);
            var overrideAppearance = GenerateAppearance(person.Age.TotalYears, npcGender, settings);
            var npc = new Npc(GeneratePersonData(character.BirthDate, settings))
            {
                Gender = npcGender,
                LastName = character.LastName,
                BirthLocation = character.BirthLocation,
                Appearance = overrideAppearance,
                Accessories = GenerateAccessories(person.Age.TotalYears, accessorySettingsList)
            };

            npc.Relationships.Add(new Relationship
            {
                Person = character,
                RelationshipType = npcGender == Genders.Female ? RelationshipType.Brother : RelationshipType.Sister
            });

            return SetupNpcParameters(npc);
        }
        
        public Npc GenerateClassmateData(Person character, AppearanceSettingsList settings, AccessorySettingsList accessorySettingsList)
        {
            var npc = new Npc(GeneratePersonData(character.BirthDate, settings));
            npc.Accessories = GenerateAccessories(npc.Age.TotalYears, accessorySettingsList);
            return SetupNpcParameters(npc);
        }
        
        public Npc GenerateColleagueData(Person character, AppearanceSettingsList settings, AccessorySettingsList accessorySettingsList)
        {
            var npc = new Npc(GeneratePersonData(character.BirthDate + (WorldDate.FromYears(Random.Next(-5, 5))), settings));
            npc.Accessories = GenerateAccessories(npc.Age.TotalYears, accessorySettingsList);
            return SetupNpcParameters(npc);
        }

        public Location GenerateLocationData()
        {
            return new Location(Guid.NewGuid().ToString())
            {
                City = "Moscow",
                Country = "Russian Federation",
                TrafficJamFactor = 1,
                PublicTransport = 1
            };
        }
       
        public List<Vacancy> GenerateVacancies(Character character, GradeConfiguration gradeConfiguration,
            PositionsSettings positionsSettings, EcsWorld world, EcsFilter<CharacterComponent> characterFilter, int vacancyCount)
        {
            var result = new List<Vacancy>();
            
            var availablePositions = positionsSettings.Configurations
                .Where(c => c.IsMatchVacancyRequirement(character, positionsSettings)).ToList();

            var previousPositions = new List<PositionConfiguration>();
            var nextPositions = new List<PositionConfiguration>();
            foreach (var position in availablePositions)
            {
                if (character.CurrentOccupation == null)
                {
                    var Sol = position.PossibleOrganizations[0].Solvency = Random.Next(0, 100);
                  
                }
                else
                {
                    position.PossibleOrganizations[0].SetSolvency();

                }
                var currentPreviousPositions = positionsSettings.Configurations.Where(c =>
                    c.PromotionsDefault.Any(promConfig => ReferenceEquals(promConfig, position)) ||
                    c.SpecialPromotions.Any(specialProm =>
                        specialProm.Promotions.Any(promConfig => ReferenceEquals(promConfig, position))))
                    .Where(p => !availablePositions.Any(avPos => ReferenceEquals(p, avPos)));
                previousPositions.AddRange(currentPreviousPositions);

                var currentNextPositions = position.PromotionsDefault.Concat(
                    position.SpecialPromotions.SelectMany(specialProm => specialProm.Promotions))
                    .Where(p => !availablePositions.Any(avPos => ReferenceEquals(p, avPos)));
                nextPositions.AddRange(currentNextPositions);
            }

            var availableVacancyCount = vacancyCount / 4;
            var prevVacancyCount = (vacancyCount - availableVacancyCount * 2) / 2;
            var nextVacancyCount = vacancyCount - (availableVacancyCount * 2) - prevVacancyCount;

            for (var i = 0; i < Math.Min(availableVacancyCount, availablePositions.Count); i++)
            {
                var position = availablePositions[i];
                result.Add(new Vacancy(gradeConfiguration, position, world, characterFilter)
                {
                    BaseSalary = position.Salary
                });
               
            }
            for (var i = 0; i < Math.Min(prevVacancyCount, previousPositions.Count); i++)
            {
                var position = previousPositions[i];
                result.Add(new Vacancy(gradeConfiguration, position, world, characterFilter)
                {
                    BaseSalary = position.Salary

                });
            }
            for (var i = 0; i < Math.Min(nextVacancyCount, nextPositions.Count); i++)
            {
                var position = nextPositions[i];
                result.Add(new Vacancy(gradeConfiguration, position, world, characterFilter)
                {
                    BaseSalary = position.Salary
                });
            }

            return result;
        }
        public List<VacancyArmy> GenerateVacanciesArmy(Character character, GradeConfiguration gradeConfiguration,
         ArmySettings positionsSettings, EcsWorld world, EcsFilter<CharacterComponent> characterFilter, int vacancyCount)
        {
            var result = new List<VacancyArmy>();

            var availablePositions = positionsSettings.Configurations
                .Where(c => c.IsMatchVacancyRequirement(character, positionsSettings)).ToList();

            var previousPositions = new List<ArmyConfiguration>();
            var nextPositions = new List<ArmyConfiguration>();
            foreach (var position in availablePositions)
            {
                var currentPreviousPositions = positionsSettings.Configurations.Where(c =>
                    c.PromotionsDefault.Any(promConfig => ReferenceEquals(promConfig, position)) ||
                    c.SpecialPromotions.Any(specialProm =>
                        specialProm.Promotions.Any(promConfig => ReferenceEquals(promConfig, position))))
                    .Where(p => !availablePositions.Any(avPos => ReferenceEquals(p, avPos)));
                previousPositions.AddRange(currentPreviousPositions);

                var currentNextPositions = positionsSettings.Configurations.Concat(
                   position.SpecialPromotions.SelectMany(specialProm => specialProm.Promotions))
                    .Where(p => !availablePositions.Any(avPos => ReferenceEquals(p, avPos)));
                nextPositions.AddRange(currentNextPositions);
            }

            var availableVacancyCount = vacancyCount / 4;
            var prevVacancyCount = (vacancyCount - availableVacancyCount * 2) / 2;
            var nextVacancyCount = vacancyCount - (availableVacancyCount * 2) - prevVacancyCount;
            try
            {


                for (var i = 0; i < Math.Min(availableVacancyCount, availablePositions.Count); i++)
                {
                    var position = availablePositions[i];
                    result.Add(new VacancyArmy(gradeConfiguration, position, world, characterFilter, positionsSettings)
                    {
                       
                    }); ;

                }
                for (var i = 0; i < Math.Min(prevVacancyCount, previousPositions.Count); i++)
                {
                    var position = previousPositions[i];
                    result.Add(new VacancyArmy(gradeConfiguration, position, world, characterFilter, positionsSettings)
                    {
                     
                    });
                }
                for (var i = 0; i < Math.Min(nextVacancyCount, nextPositions.Count); i++)
                {
                    var position = nextPositions[i];
                    result.Add(new VacancyArmy(gradeConfiguration, position, world, characterFilter, positionsSettings)
                    {
                     
                    });
                }

            }
            catch
            {

            }
            return result;
        }

        public List<PartTimeVacancy> GeneratePartTimeVacancies(Character character, GradeConfiguration gradeConfiguration,
            PartTimePositionSettings partTimePositionSettings, EcsWorld world, int vacancyCount)
        {
            var result = new List<PartTimeVacancy>();

            var availablePositions = partTimePositionSettings.Configurations
                .Where(c => c.IsMatchVacancyRequirement(character)).ToList();
            Random rand = new Random();
            availablePositions = availablePositions.GroupBy(x => x.NameDefault).Select(x => x.FirstOrDefault()).Distinct().OrderBy(x=>rand.Next()).ToList();
            
            for (int i = availablePositions.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                PartTimePositionConfiguration tmp = availablePositions[j];
            availablePositions[j] = availablePositions[i];
            availablePositions[i] = tmp;
            }

            for (var i = 0; i < Math.Min(vacancyCount, availablePositions.Count); i++)
            {
                var position = availablePositions[i];
                result.Add(new PartTimeVacancy(gradeConfiguration, partTimePositionSettings, position, world)
                {
                    BaseSalary = position.HourlyRate,
                    HoursWeek = position.HoursPerWeek
                });
            }

            return result;
        }

        public EducationService GenerateEducationService(EducationType type)
        {
            return new EducationService(Guid.NewGuid().ToString())
            {
                Cost = 0,
                DurationMonths = type == EducationType.CommunityCollege
                    ? 24
                    : 48,
                Type = type
            };
        }

        private string GetFirstName(Genders gender)
        {
            switch (gender)
            {
                case Genders.Male:
                    return _firstNamesMale[Random.Next(0, _firstNamesMale.Count)];
                case Genders.Female:
                    return _firstNamesFemale[Random.Next(0, _firstNamesFemale.Count)];;
                default:
                    return "Noname";
            }
        }

        private void SetupNamesCollections()
        {
            var namesSets = _worldGenerationSettings.NameSetTable.text.Split('\n');
            _lastNames = new List<string>();
            _firstNamesFemale = new List<string>();
            _firstNamesMale = new List<string>();
            
            foreach (var nameSet in namesSets)
            {
                var splitData = nameSet.Split(',');
                if (splitData.Length < 3)
                    continue;
                
                _firstNamesMale.Add(splitData[1].Replace("\n", "").Replace("\r", ""));
                _firstNamesFemale.Add(splitData[3].Replace("\n", "").Replace("\r", ""));
                _lastNames.Add(splitData[5].Replace("\n", "").Replace("\r", ""));
            }
        }
        
        public Sprite GenerateAvatar(Genders gender, WorldDate age)
        {
            switch (gender)
            {
                case Genders.Male when age.TotalYears <= 10:
                {
                    return _worldGenerationSettings.Avatars.FirstOrDefault(s => s.name == "boy");
                }
                case Genders.Male when age.TotalYears <= 19:
                {
                    return _worldGenerationSettings.Avatars.FirstOrDefault(s => s.name == "teenboy");
                }
                case Genders.Male:
                {
                    return _worldGenerationSettings.Avatars.FirstOrDefault(s => s.name == "men");
                }
                
                case Genders.Female when age.TotalYears <= 10:
                {
                    return _worldGenerationSettings.Avatars.FirstOrDefault(s => s.name == "girl");
                }
                case Genders.Female when age.TotalYears <= 19:
                {
                    return _worldGenerationSettings.Avatars.FirstOrDefault(s => s.name == "teengirl");
                }
                case Genders.Female:
                {
                    return _worldGenerationSettings.Avatars.FirstOrDefault(s => s.name == "women");
                }
                
                default:
                {
                    return null;
                }
            }
        }

        public int GetRandom(int a, int b)
        {
            return Random.Next(a, b);
        }
    }
}