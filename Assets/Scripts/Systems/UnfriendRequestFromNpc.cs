using Components;
using Components.Events;
using Core;
using Extensions;
using Leopotam.Ecs;
using Modules;
using Popups;
using Settings.NpcCommunication;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Systems
{
    public class UnfriendRequestFromNpc : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsFilter<CharacterComponent> _characterFilter;

        private UnfriendRequestSettings _communicationSettings;

        public void Run()
        {

            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                foreach (var j in _npcFilter)
                {
                    var npc = _npcFilter.Get1(j).Npc;
                    var relation = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                    if (relation?.RelationshipType == RelationshipType.Friend)
                    {
                        var relationship = npc.Parameters.Get(ParameterType.Relationship.ToString());
                        var kindness = npc.Parameters.Get(ParameterType.Kindness.ToString());

                        if (relationship.Value < -15)
                        {
                            npc.Relationships.Remove(relation);
                            float chance;

                            if (relationship.Value < -25)
                            {
                                chance = 55 - kindness.Value / 2;
                            }
                            else
                            {
                                chance = 100 - kindness.Value / 3;
                            }

                            if (Random.Range(0, 100) <= chance)
                            {
                                npc.Relationships.Add(new Relationship
                                {
                                    Person = character,
                                    RelationshipType = RelationshipType.Enemy
                                });
                            }

                            ShowUnfriendPopup(character, npc);
                        } else if (npc.UnFriendYearsCount >= 3)
                        {
                            npc.Relationships.Remove(relation);
                            ShowUnfriendPopup(character, npc);
                        }
                    }
                }
            }
        }

        private void ShowUnfriendPopup(Core.Character character, Core.Npc npc)
        {
            int random = Random.Range(0, _communicationSettings.Communications.Count);
            var _choiceSettings = _communicationSettings.Communications[random];

            var ageLog = _choiceSettings.DiaryEntry.Text.Enrich(npc).Replace(_choiceSettings.DiaryEntry.ReplaceGenderText, npc, character);
            character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(ageLog));

            _world.NewEntity().Replace(new ShowPopup
            {
                PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                {
                    HeaderText = _communicationSettings.PopupTitle,
                    ContentText = _choiceSettings.Text.Enrich(npc).Replace(_choiceSettings.ReplaceGenderText, npc, character),
                    ActionsSettings = new List<ActionButtonSettings>
                                        {
                                            new ActionButtonSettings
                                            {
                                                Title = LocalizationDictionary.GetLocalizedString("ok"),
                                                Action = () =>
                                                {
                                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                                }
                                            }
                                        }
                })
            });
        }

    }
}

