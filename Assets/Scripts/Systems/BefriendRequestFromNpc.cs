using System.Collections.Generic;
using System.Data;
using System.Linq;
using Components;
using Components.Events;
using Components.NpcRequests;
using Core;
using Extensions;
using Leopotam.Ecs;
using Modules;
using Popups;
using Settings.NpcCommunication;
using UnityEngine;

namespace Systems
{
    public class BefriendRequestFromNpc : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterComponent;
        private EcsFilter<CharacterComponent, MainOccupationChanged> _mainOccupationChangedFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsFilter<NpcComponent, BefriendRequest> _befriendRequestFilter;
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
        private BeFriendRequestSettings _beFriendRequestSettings;

        public void Run()
        {
            foreach (var i in _characterComponent)
            {
                var character = _characterComponent.Get1(i).Character;
                if (character.CurrentOccupation != null && character.CurrentOccupation.BefriendProbability > 0)
                {
                    character.CurrentOccupation.BefriendProbability =
                        Mathf.Max(0, character.CurrentOccupation.BefriendProbability - 20);
                }
            }
            
            foreach (var i in _befriendRequestFilter)
            {
                var npc = _befriendRequestFilter.Get1(i).Npc;
                var settings = _befriendRequestFilter.Get2(i).BeFriendRequestChoiceSettings;

                foreach (var charIndex in _characterComponent)
                {
                    var character = _characterComponent.Get1(charIndex).Character;
                    var relation = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                    if (relation == null)
                    {
                        npc.Relationships.Add(new Relationship
                            {Person = character, RelationshipType = RelationshipType.Friend});
                    }
                    else
                    {
                        relation.RelationshipType = RelationshipType.Friend;
                    }
                    var happiness = character.Parameters.Get(ParameterType.Happiness.ToString());
                    happiness.Inc(happiness.Value * 0.2f);
                    var kindness = character.Parameters.Get(ParameterType.Kindness.ToString());
                    kindness.Inc(kindness.Value * 0.025f);
                    character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(
                                        settings.DiaryEntryPositive.Text
                                        .Enrich(npc)
                                        .Replace(settings.DiaryEntryPositive.ReplaceGenderText, npc, character))
                                        );
                    ShowReactionPopup(settings.Text
                                        .Enrich(npc)
                                        .Replace(settings.ReplaceGenderText, npc, character)
                                        );

                }
                _befriendRequestFilter.GetEntity(i).Del<BefriendRequest>();
            }

            var maxRelationshipValue = float.MinValue;
            foreach (var i in _mainOccupationChangedFilter)
            {
                var character = _mainOccupationChangedFilter.Get1(i).Character;
                DetermineFriendApplicant(character, ref maxRelationshipValue);
            }
            
            if (_nextIterationFilter.IsEmpty())
                return;

            foreach (var i in _characterComponent)
            {
                var character = _characterComponent.Get1(i).Character;
                DetermineFriendApplicant(character, ref maxRelationshipValue);
            }
        }

        private void DetermineFriendApplicant(Core.Character character, ref float maxRelationshipValue)
        {
            if (character.CurrentOccupation == null)
                return;
            
            var chance = Random.Range(0, 101);
            if (chance > character.CurrentOccupation.BefriendProbability)
                return;

            EcsEntity friendApplicantEntity = default;
            foreach (var i in _npcFilter)
            {
                var npc = _npcFilter.Get1(i).Npc;
                var relation = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                if (character.CurrentOccupation.Id == npc.CurrentOccupation?.Id && relation?.RelationshipType != RelationshipType.Friend)
                {
                    var relationship = npc.Parameters.Get(ParameterType.Relationship.ToString());
                    if (maxRelationshipValue < relationship.Value)
                    {
                        maxRelationshipValue = relationship.Value;
                        friendApplicantEntity = _npcFilter.GetEntity(i);
                    }
                }
            }
            
            if (!friendApplicantEntity.IsNull())
            {
                var random = Random.Range(0, _beFriendRequestSettings.Communications.Count);
                var settings = _beFriendRequestSettings.Communications[random];
                var npc = friendApplicantEntity.Get<NpcComponent>().Npc;

                string invite = 
                    settings.Invite.Text
                    .Enrich(npc)
                    .Replace(settings.Invite.ReplaceGenderText, npc, character);
                string answerPositive = settings.ReactionPositive;
                string answerNegative = settings.ReactionNegative;

                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                    {
                        HeaderText = _beFriendRequestSettings.PopupTitle,
                        ContentText = invite,
                        ActionsSettings = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = answerPositive,
                                Action = () =>
                                {
                                    friendApplicantEntity.Replace(new BefriendRequest() { BeFriendRequestChoiceSettings = settings });
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            },
                            new ActionButtonSettings
                            {
                                Title = answerNegative,
                                Action = () =>
                                {
                                    character.AgeLog.AddRecord(WorldDateModule.CurrentDate,new Record(
                                        settings.DiaryEntryNegatie.Text
                                        .Enrich(npc)
                                        .Replace(settings.DiaryEntryNegatie.ReplaceGenderText, npc, character))
                                        );
                                    ShowReactionPopup(settings.NegativeCommunication.Text
                                        .Enrich(npc)
                                        .Replace(settings.NegativeCommunication.ReplaceGenderText, npc, character)
                                        );
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            }
                        }
                    })
                });
            }
        }

        private void ShowReactionPopup(string reaction)
        {
            _world.NewEntity().Replace(new ShowPopup
            {
                PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                {
                    HeaderText = _beFriendRequestSettings.PopupTitle,
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