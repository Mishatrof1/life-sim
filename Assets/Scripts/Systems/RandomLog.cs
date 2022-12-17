using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Components;
using Components.Events;
using Core;
using Leopotam.Ecs;
using Modules;
using Settings;
using CharacterComponent = Components.CharacterComponent;

namespace Systems
{
    public class RandomLog : IEcsRunSystem
    {
        private EcsFilter<NextWorldDateIteration> _nextCycleFilter;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<Created, CharacterComponent> _newCharactersFilter;
        private EcsFilter<NpcComponent> _npcFilter;

        private GlobalSettings _globalSettings;

        public void Run()
        {
            foreach (var i in _newCharactersFilter)
            {
                BirthLog(_newCharactersFilter.Get2(i).Character);
            }

            if (_nextCycleFilter.IsEmpty())
                return;

            var character = GetCurrentCharacter();
            if (character == null)
                return;
            
            var logs = GetLogs(character.Age.TotalYears);
            
            if (logs.Count <= 0)
                return;
          

            character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(logs[UnityEngine.Random.Range(0, logs.Count)]));
        }

        public void BirthLog(Core.Character character)
        {
            character.AgeLog.AddRecord(character.BirthDate, new Record($"Я роди{ (character.Gender.Equals(Genders.Female) ? "лась" : "лся")} {character.Gender} в городе {character.BirthLocation.City}, {character.BirthLocation.Country}"));
            character.AgeLog.AddRecord(character.BirthDate, new Record($"Мой день рождения {new DateTime().AddDays(character.Birthday).ToString("M")}. Я {character.Zodiac}"));
            character.AgeLog.AddRecord(character.BirthDate, new Record($"Меня зовут {character.FullName}"));

            foreach (var i in _npcFilter)
            {
                string relStatus = _npcFilter.Get1(i).Npc.RelationshipStatus;
                Npc npc = _npcFilter.Get1(i).Npc;

                if (relStatus == RelationshipType.Mother.ToString())
                    character.AgeLog.AddRecord(character.BirthDate, new Record($"Моя мама {npc.FirstName}, ей {npc.Age.TotalYears}"));
                if (relStatus == RelationshipType.Father.ToString())
                    character.AgeLog.AddRecord(character.BirthDate, new Record($"Мой отец {npc.FirstName}, ему {npc.Age.TotalYears}"));

                if (relStatus == RelationshipType.Brother.ToString())
                {
                    string ageCompare = "";
                    if (npc.Age.TotalYears > 0) ageCompare += "старший ";
                    character.AgeLog.AddRecord(character.BirthDate, new Record($"У меня есть {ageCompare}{relStatus} по имени {npc.FirstName}"));
                }
                if (relStatus == RelationshipType.Sister.ToString())
                {
                    string ageCompare = "";
                    if (npc.Age.TotalYears > 0) ageCompare += "старшая ";
                    character.AgeLog.AddRecord(character.BirthDate, new Record($"У меня есть {ageCompare}{relStatus} по имени {npc.FirstName}"));
                }
            }
        }

        private List<string> GetLogs(int _age)
        {
            var result = new List<string>();
            int minAge;
            int maxAge; 
            var regex = new Regex(@"(?<min>\d{1,2}).+(?<max>\d\d)");
        
            foreach (var aLogs in _globalSettings.LogSets)
            { 
                var match = regex.Match(aLogs.name);     
                if (!(Int32.TryParse(match.Groups["min"].Value, out minAge))) minAge = 0; 
                if (!(Int32.TryParse(match.Groups["max"].Value, out maxAge))) maxAge = 0;    
             
                aLogs.text.Replace("ID	AGE Log (text)", ""); 
                var mmText =  aLogs.text.Split('\t','\n');
           
                bool isSecond = false;
                if (_age >= minAge && _age <= maxAge)
                {
                    foreach (var text in mmText)
                    {
                        if (isSecond)
                        {
                            isSecond = false;
                            result.Add(text);
                        }
                        else
                        {
                            isSecond = true;
                        }
                    }
                } 
            }
            return result;
        }
        
        private Core.Character GetCurrentCharacter()
        {
            foreach (var i in _charactersFilter)
            {
                return _charactersFilter.Get1(i).Character;
            }

            return null;
        }
    }
}