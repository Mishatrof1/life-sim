using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core;
using Settings.NpcCommunication;
using UnityEngine;

namespace Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Заменяет в тексте служебные слова, экранированные знаком '%'
        /// </summary>
        /// <param name="person">Персонаж в тексте</param>
        public static string EnrichText(this string str, Person person)
        {
            return str.EnrichText(new Person[] { person });
        }

        /// <summary>
        /// Заменяет в тексте служебные слова, экранированные знаком '%'
        /// </summary>
        /// <param name="persons">Список персонажей в тексте. Главный герой в списке преоснажей всегда находится на позиции [0], остальные персонажи стоят по порядку, обозначенному историей.</param>
        public static string EnrichText(this string str, Person[] persons)
        {
            try
            {
                var text = str;
                var regex = new Regex(@"(%\S+%)");
                foreach (Match match in regex.Matches(text))
                {
                    var id = match.Value.Remove(match.Value.Length-1,1).Remove(0,1);
                    string[] keys = id.Split(':');
                    switch (keys[0])
                    {
                        case "Pron":
                            var personId = int.Parse(keys[1]);
                            if (personId >= persons.Length)
                            {
                                personId = persons.Length - 1;
                            }
                            var pronId = int.Parse(keys[2]);
                            text = text.Replace(match.Value, Pron(persons[personId], pronId));
                            break;
                        case "Class":
                            var npc = persons[int.Parse(keys[1])] as Npc;
                            var relation = npc.Relationships.FirstOrDefault(r =>
                                                r.Person.Id == persons[0].Id);
                            if (relation!=null)
                            {
                                text = text.Replace(match.Value, relation.RelationshipType.ToString());
                            } else
                            {
                                text = text.Replace(match.Value, npc.OccupationStatus);
                            }
                            break;
                        default:
                            if (keys[0].Contains("Name"))
                                text = text.Replace(match.Value, GetName(keys[0], persons[int.Parse(keys[2])]));
                            break;
                    }
                    
                }
                return text;
            }
            catch
            {
                return "";
            }
        }

        private static string GetName(string nameType, Person person)
        {
            switch (nameType)
            {
                case "FullName":
                    return person.FullName;
                case "FirstName":
                    return person.FirstName;
                case "LastName":
                    return person.LastName;
            }
            return "";
        }

        private static string Pron(Person person, int form)
        {
            string[][] pronTable = {
                new string[] { "he", "him", "his", "his", "himself" },
                new string[] { "she", "her", "her", "hers", "herself" }
            };
            return pronTable[person.Gender == Genders.Male ? 0 : 1][form];
        }

        public static string Enrich(this string str, Npc npc)
        {
            var text = str;
            var regex = new Regex(@"({\w+})");
            foreach (Match match in regex.Matches(text))
            {
                var id = match.Value.Replace("{", "").Replace("}", "");
                switch (id)
                {
                    case "NpcFullName":
                    {
                        text = text.Replace(match.Value, npc.FullName);
                        break;
                    }
                }
            }
            return text;
        }

        public static string Replace(this string str, List<ReplaceText> replaceTexts, Npc npc = null, Character character = null)
        {
            var text = str;
            var regex = new Regex(@"({\w+})");
            foreach (Match match in regex.Matches(text))
            {
                var id = match.Value.Replace("{", "").Replace("}", "");
                ReplaceText replaceText = null;
                switch (id)
                {
                    case "CharacterGender":
                    {
                        replaceText = replaceTexts.FirstOrDefault(rt =>
                            rt.Id == id && rt.Value == character.Gender.ToString());
                        break;
                    }
                    
                    case "NpcGender":
                    {
                        replaceText = replaceTexts.FirstOrDefault(rt =>
                            rt.Id == id && rt.Value == npc.Gender.ToString());
                        break;
                    }
                }
                
                if (replaceText != null)
                {
                    text = text.Replace(match.Value, replaceText.Text);
                }
            }
            return text;
        }

    }
}