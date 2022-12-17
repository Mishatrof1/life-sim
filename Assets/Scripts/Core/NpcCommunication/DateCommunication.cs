using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Extensions;
using Leopotam.Ecs;
using Modules;
using Settings.NpcCommunication;
using UnityEngine;

namespace Core.NpcCommunication
{
    public class DateCommunication : Communication<DateSettings, ReactionsSettings>
    {   
        public DateCommunication(DateSettings communicationSettings, ReactionsSettings reactionSettings) : base(communicationSettings, reactionSettings)
        {
        }

        public override string GetTopText(Npc npc)
        {
            return npc.FlirtProgress.Dates.Count == npc.FlirtProgress.CompletedDates.Count
                ? _communicationSettings.ScreenTitleNoPlace
                : _communicationSettings.ScreenTitle.Enrich(npc);
        }

        public override List<CommunicationChoice> GenerateChoices(Npc npc)
        {
            var availableDates =
                npc.FlirtProgress.Dates.Where(d =>
                    npc.FlirtProgress.CompletedDates.All(cd => cd.Index != d.Index)).ToList();
            
            if (availableDates.Count <= 4)
            {
                return availableDates
                    .Select(d =>
                    {
                        var dateChoice = _communicationSettings.Communications[d.Index];
                        return new CommunicationChoice
                        {
                            Index = d.Index,
                            Text = dateChoice.Place
                        };
                    }).ToList();
            }

            var resultDatesIndexes = new List<int>();
            var cycleCount = 0;
            while (!(resultDatesIndexes.Count == 4 || cycleCount++ == 1000))
            {
                var dateIndex = availableDates[UnityEngine.Random.Range(0, availableDates.Count)].Index;
                if (!resultDatesIndexes.Contains(dateIndex))
                {
                    resultDatesIndexes.Add(dateIndex);
                }
            }
            return resultDatesIndexes.Select(ri =>
            {
                var dateChoice = _communicationSettings.Communications[ri];
                return new CommunicationChoice
                {
                    Index = ri,
                    Text = dateChoice.Place
                };
            }).ToList();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity)
        {
            var character = characterEntity.Get<CharacterComponent>().Character;
            var npc = npcEntity.Get<NpcComponent>().Npc;
            var date = npc.FlirtProgress.Dates.First(d => d.Index == choiceIndex);
            npc.FlirtProgress.CompletedDates.Add(new Date
            {
                Index = date.Index,
                IsSuccessful = date.IsSuccessful
            });

            if (date.IsSuccessful)
            {
                return _communicationSettings.RightChoiceBubble;
            }
            return _communicationSettings.WrongChoiceBubble;
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity,
            out string description)
        {
            throw new NotImplementedException();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity)
        {
            throw new NotImplementedException();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity, out string description)
        {
            throw new NotImplementedException();
        }

        public override string GetChoiceText(int choiceIndex, Npc npc)
        {
            return _communicationSettings.Communications[choiceIndex].GetActualText(npc);
        }
    }
}