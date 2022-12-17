using Components;
using Components.Events;
using Components.NpcRequests;
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
    public class AskOutRequestFromNpc : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsFilter<NpcComponent, AskOutRequest> _askOutRequestFilter;
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
        private AskOutRequestSettings _askOutRequestSettings;

        public void Run()
        {

            foreach (var i in _askOutRequestFilter)
            {
                var npc = _askOutRequestFilter.Get1(i).Npc;
                var settings = _askOutRequestFilter.Get2(i).AskOutRequestChoiceSettings;

                foreach (var charIndex in _characterFilter)
                {
                    var character = _characterFilter.Get1(charIndex).Character;
                    var relation = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                    if (relation == null)
                    {
                        npc.Relationships.Add(new Relationship
                        { Person = character, RelationshipType = RelationshipType.Lover });
                    }
                    else
                    {
                        relation.RelationshipType = RelationshipType.Lover;
                    }
                    character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(
                                        settings.DiaryEntryPositive.Text
                                        .Enrich(npc)
                                        .Replace(settings.DiaryEntryPositive.ReplaceGenderText, npc, character))
                                        );
                    ShowReactionPopup(_askOutRequestSettings.AcceptMessage.Enrich(npc));

                }
                _askOutRequestFilter.GetEntity(i).Del<AskOutRequest>();
            }

            if (_nextIterationFilter.IsEmpty())
                return;

            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                DetermineBedfellowApplicant(character);
            }

        }

        private void DetermineBedfellowApplicant(Core.Character character)
        {
            EcsEntity bedFellowApplicantEntity = default;
            Npc condidate = null;
            int condidateIdx = 0;
            foreach (var i in _npcFilter)
            {
                var npc = _npcFilter.Get1(i).Npc;
                var relation = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);

                if (relation != null)
                {
                    if (relation.RelationshipType == RelationshipType.Lover)
                        return;
                    continue;
                }
                if (npc.Gender == character.Gender) continue; //todo проверка совместимости
                if (npc.Age.TotalYears < 12) continue;
                if (npc.Parameters.Get(ParameterType.Relationship.ToString()).Value < 35) continue;

                if (condidate == null)
                {
                    condidate = npc;
                    condidateIdx = i;
                    continue;
                }

                var condidateSympathy = condidate.Parameters.Get(ParameterType.Sympathy.ToString()).Value;
                var npcSympathy = npc.Parameters.Get(ParameterType.Sympathy.ToString()).Value;

                if (condidateSympathy < npcSympathy)
                {
                    condidate = npc;
                    condidateIdx = i;
                }
            }

            if (condidate != null)
            {
                bedFellowApplicantEntity = _npcFilter.GetEntity(condidateIdx);
                var looks = character.Parameters.Get(ParameterType.Looks.ToString()).Value * 0.01f;
                var smarts = character.Parameters.Get(ParameterType.Smarts.ToString()).Value * 0.01f;
                var chance = Random.Range(0, 101) <= Mathf.Min(7.5f, 25 * looks * smarts);
                if (chance)
                {
                    var random = Random.Range(0, _askOutRequestSettings.Communications.Count);
                    var settings = _askOutRequestSettings.Communications[random];
                    var invite = settings.Text
                        .Enrich(condidate)
                        .Replace(settings.ReplaceGenderText, condidate, character);

                    _world.NewEntity().Replace(new ShowPopup
                    {
                        PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                        {
                            HeaderText = _askOutRequestSettings.PopupTitle,
                            ContentText = invite,
                            ActionsSettings = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = LocalizationDictionary.GetLocalizedString("communication_accept"),
                                Action = () =>
                                {
                                    bedFellowApplicantEntity.Replace(new AskOutRequest() { AskOutRequestChoiceSettings = settings });
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            },
                            new ActionButtonSettings
                            {
                                Title = LocalizationDictionary.GetLocalizedString("communication_refuse"),
                                Action = () =>
                                {
                                    character.AgeLog.AddRecord(WorldDateModule.CurrentDate,new Record(
                                        settings.DiaryEntryNegatie.Text
                                        .Enrich(condidate)
                                        .Replace(settings.DiaryEntryNegatie.ReplaceGenderText, condidate, character))
                                        );
                                    ShowReactionPopup(_askOutRequestSettings.RefuseMessage.Enrich(condidate));
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            }
                        }
                        })
                    });
                }
            }
        }

        private void ShowReactionPopup(string reaction)
        {
            _world.NewEntity().Replace(new ShowPopup
            {
                PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                {
                    HeaderText = _askOutRequestSettings.PopupTitle,
                    ContentText = reaction,
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