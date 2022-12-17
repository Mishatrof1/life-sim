using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.NpcCommunication;
using DialogSystem;
using Extensions;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;
using Settings.NpcCommunication;
using UnityEngine;

namespace Systems
{
    public class NpcCommunicationSpendTime : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsFilter<Components.NpcCommunication> _communicationFilter;
        private EcsFilter<BlockComponent, Active> _navigationFilter;
        
        private SpendTimeSettings _spendTimeSettings;

        private int _spendTimeSettingsIndex = 0;

        public void Init()
        {
            EventSystem.Subscribe<DialogChoiceButton_Click>(OnDialogResponse_Click);
        }

        public void Destroy()
        {
            EventSystem.Unsubscribe<DialogChoiceButton_Click>(OnDialogResponse_Click);
        }

        public void Run()
        {
            foreach (var i in _communicationFilter)
            {
                ref var communication = ref _communicationFilter.Get1(i);
                var entity = _communicationFilter.GetEntity(i);

                if (!(communication.Communication is SpendTimeCommunication))
                    continue;

                if (_navigationFilter.GetCurrentPoint(NavigationBlockType.Main)?.Type != NavigationElementType.SpendTimeInteraction)
                {
                    entity.Destroy();
                    continue;
                }

                if (entity.Has<ChoicesChanged>())
                {
                    entity.Del<ChoicesChanged>();
                }
                
                if (entity.Has<New>())
                {
                    entity.Replace(new ChoicesChanged
                    {
                        Message = communication.Communication.GetTopText(communication.Npc),
                        ButtonChoices = communication.Communication.GenerateChoices(communication.Npc)
                    });
                }

                if (!entity.Has<ChoiceSelected>())
                    continue;

                if (!communication.Final)
                {
                    var selectedIndex = entity.Get<ChoiceSelected>().ChoiceIndex;

                    foreach (var charCompIndex in _charactersFilter)
                    {
                        var character = _charactersFilter.Get1(charCompIndex).Character;
                        if (character.Id == communication.Character.Id)
                        {
                            foreach (var npcComIndex in _npcFilter)
                            {
                                var npc = _npcFilter.Get1(npcComIndex).Npc;
                                if (npc.Id == communication.Npc.Id)
                                {

                                    if (communication.AskOutFlag)
                                    {
                                        var relation = npc.Relationships.FirstOrDefault(r =>
                                            r.Person.Id == character.Id);
                                        var choiceSettings = _spendTimeSettings.Communications[_spendTimeSettingsIndex];
                                        communication.Final = true;
                                        switch (selectedIndex)
                                        {
                                            case 0:
                                                if (relation == null)
                                                {
                                                    npc.Relationships.Add(new Relationship
                                                    {
                                                        Person = character,
                                                        RelationshipType = RelationshipType.Lover
                                                    });
                                                }
                                                else
                                                {
                                                    relation.RelationshipType = RelationshipType.Lover;
                                                }
                                                var acceptMessage = choiceSettings.DiaryEntryAccept.Text
                                                                    .Enrich(npc)
                                                                    .Replace(choiceSettings.DiaryEntryAccept.ReplaceGenderText, npc, character);
                                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(acceptMessage));
                                                entity
                                                    .Replace(new ChoicesChanged
                                                    {
                                                        Message = _spendTimeSettings.AskOutAcceptMessage.Enrich(npc),
                                                        ButtonChoices = new List<CommunicationChoice>
                                                        {
                                                            new CommunicationChoice
                                                            {
                                                                Index = 0,
                                                                Text = LocalizationDictionary.GetLocalizedString("ok")
                                                            }
                                                        }
                                                    });
                                                break;
                                            case 1:
                                                var refuseMessage = choiceSettings.DiaryEntryRefuse.Text
                                                                    .Enrich(npc)
                                                                    .Replace(choiceSettings.DiaryEntryRefuse.ReplaceGenderText, npc, character);
                                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(refuseMessage));
                                                entity
                                                    .Replace(new ChoicesChanged
                                                    {
                                                        Message = _spendTimeSettings.AskOutRefuseMessage.Enrich(npc),
                                                        ButtonChoices = new List<CommunicationChoice>
                                                        {
                                                            new CommunicationChoice
                                                            {
                                                                Index = 0,
                                                                Text = LocalizationDictionary.GetLocalizedString("ok")
                                                            }
                                                        }
                                                    });
                                                break;
                                        }
                                    } else
                                    {
                                        var relationship = npc.Parameters.Get(ParameterType.Relationship.ToString());
                                        var sympathy = npc.Parameters.Get(ParameterType.Sympathy.ToString());
                                        var relation = npc.Relationships.FirstOrDefault(r =>
                                            r.Person.Id == character.Id);


                                        var chance = relationship.Value > 50 && sympathy.Value > 70 && Random.Range(0, 101) <= 15;
                                        var canAskOut = (relation == null ||
                                                         (relation.RelationshipType != RelationshipType.Mother &&
                                                          relation.RelationshipType != RelationshipType.Father &&
                                                          relation.RelationshipType != RelationshipType.Brother &&
                                                          relation.RelationshipType != RelationshipType.Lover &&
                                                          relation.RelationshipType != RelationshipType.Sister))
                                                        && (character.Age.TotalYears > 12 && npc.Age.TotalYears > 12);
                                        if (chance && canAskOut)
                                        {
                                            communication.AskOutFlag = true;
                                            _spendTimeSettingsIndex = Random.Range(0, _spendTimeSettings.Communications.Count);
                                            var communicationChoice = _spendTimeSettings.Communications[_spendTimeSettingsIndex];
                                            _communicationFilter.GetEntity(i)
                                                        .Replace(new ChoicesChanged
                                                        {
                                                            Message = communicationChoice.Text
                                                                        .Enrich(npc)
                                                                        .Replace(communicationChoice.ReplaceGenderText, npc, character),
                                                            ButtonChoices = new List<CommunicationChoice>
                                                            {
                                                                    new CommunicationChoice
                                                                    {
                                                                        Index = 0,
                                                                        Text = LocalizationDictionary.GetLocalizedString("communication_accept")
                                                                    },
                                                                    new CommunicationChoice
                                                                    {
                                                                        Index = 1,
                                                                        Text = LocalizationDictionary.GetLocalizedString("communication_refuse")
                                                                    }
                                                            }
                                                        });
                                        }
                                        else
                                        {
                                            var bubbleText = 
                                            communication.Final = true;
                                            EventSystem.Send(new BubbleTextComponent
                                            {
                                                BubbleTextValue = communication.Communication.HandleSelectedChoice(
                                                                        selectedIndex,
                                                                        ref _communicationFilter.GetEntity(i),
                                                                        ref _charactersFilter.GetEntity(charCompIndex),
                                                                        ref _npcFilter.GetEntity(npcComIndex), out var description)
                                            });

                                            _communicationFilter.GetEntity(i)
                                                .Replace(new ChoicesChanged
                                                {
                                                    Message = description,
                                                    ButtonChoices = new List<CommunicationChoice>
                                                    {
                                                    new CommunicationChoice
                                                    {
                                                        Index = 0,
                                                        Text = LocalizationDictionary.GetLocalizedString("ok")
                                                    }
                                                    }
                                                });
                                        }
                                    }
                                }
                            }
                        }
                        _world.NewEntity().Replace(new NavigationBack());
                    }
                }
                else
                {
                    
                    entity.Destroy();
                }
            }
        }
    

        private void OnDialogResponse_Click(DialogChoiceButton_Click e)
        {
            foreach (var i in _communicationFilter)
            {
                _communicationFilter.GetEntity(i).Replace(new ChoiceSelected {ChoiceIndex = e.ChoiceIndex});
            }
        }
    }
}