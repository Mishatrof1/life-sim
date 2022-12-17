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
    public class NpcCommunicationDate : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsFilter<Components.NpcCommunication> _communicationFilter;
        private EcsFilter<BlockComponent, Active> _navigationFilter;
        
        private ReactionsSettings _reactionsSettings;
        private DateSettings _dateSettings;

        private int _dateSettingsIndex = 0;

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

                if (!(communication.Communication is DateCommunication))
                    continue;
                
                if (_navigationFilter.GetCurrentPoint(NavigationBlockType.Main)?.Type != NavigationElementType.DateInteraction)
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
                    if (communication.Npc.FlirtProgress.Dates.Count == 0)
                    {
                        communication.Npc.FlirtProgress.SetAvailableDates(_dateSettings);
                    }
                        
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
                                        communication.Final = true;
                                        var choiceSettings = _dateSettings.Communications[_dateSettingsIndex];
                                        switch (selectedIndex)
                                        {
                                            case 0: //принять
                                                var relationship =
                                                    npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                                                if (relationship == null)
                                                {
                                                    npc.Relationships.Add(new Relationship
                                                    {
                                                        Person = character,
                                                        RelationshipType = RelationshipType.Lover
                                                    });
                                                }
                                                else
                                                {
                                                    relationship.RelationshipType = RelationshipType.Lover;
                                                }
                                                npc.FlirtProgress.AskOutResult = 1;

                                                var acceptMessage = choiceSettings.DiaryEntryAccept.Text
                                                                    .Enrich(npc)
                                                                    .Replace(choiceSettings.DiaryEntryAccept.ReplaceGenderText, npc, character);
                                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(acceptMessage));

                                                entity
                                                    .Replace(new ChoicesChanged
                                                    {
                                                        Message = _dateSettings.AskOutAcceptMessage.Text.Enrich(npc),
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
                                            case 1: //отклонить
                                                npc.FlirtProgress.Reset();
                                                npc.Parameters.Get(ParameterType.Sympathy.ToString())
                                                    .Dec(_dateSettings.SympathyDec);

                                                var refuseMessage = choiceSettings.DiaryEntryRefuse.Text
                                                                    .Enrich(npc)
                                                                    .Replace(choiceSettings.DiaryEntryRefuse.ReplaceGenderText, npc, character);
                                                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(refuseMessage));
                                                entity
                                                    .Replace(new ChoicesChanged
                                                    {
                                                        Message = _dateSettings.AskOutRefuseMessage.Text.Enrich(npc),
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
                                        _dateSettingsIndex = selectedIndex;
                                        EventSystem.Send(new BubbleTextComponent
                                        {
                                            BubbleTextValue = communication.Communication.HandleSelectedChoice(
                                            selectedIndex,
                                            ref _charactersFilter.GetEntity(charCompIndex),
                                            ref _npcFilter.GetEntity(npcComIndex))
                                        });

                                        var lastDate = npc.FlirtProgress.CompletedDates.Last();

                                        if (lastDate.IsSuccessful)
                                        {
                                            var smart = npc.Parameters.Get(ParameterType.Smarts.ToString());
                                            var looks = npc.Parameters.Get(ParameterType.Looks.ToString());
                                            var chancePercent = npc.FlirtProgress.PersistenceSum * 4 +
                                                                (smart.Value + looks.Value) * 0.1;
                                            var random = Random.Range(0f, 100f);
                                            var chance = random <= chancePercent;

                                            var choiceSettings = _dateSettings.Communications[_dateSettingsIndex];

                                            if (chance || true)
                                            {
                                                communication.AskOutFlag = true;
                                                entity
                                                    .Replace(new ChoicesChanged
                                                    {
                                                        Message = choiceSettings.Text
                                                                    .Enrich(npc)
                                                                    .Replace(choiceSettings.ReplaceGenderText, npc, character),
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
                                                communication.Final = true;
                                                entity
                                                    .Replace(new ChoicesChanged
                                                    {
                                                        Message = _dateSettings.GoodDateMessage,
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
                                        } else
                                        {
                                            communication.Final = true;
                                            entity
                                                .Replace(new ChoicesChanged
                                                {
                                                    Message = _dateSettings.BadDateMessage,
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
                    }
                }
                else
                {   
                    entity.Destroy();
                    _world.NewEntity().Replace(new NavigationBack());
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