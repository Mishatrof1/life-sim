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
    public class AskOutCommunication : Communication<AskOutSettings, ReactionsSettings>
    {
        private int _rightChoice;

        public AskOutCommunication(AskOutSettings communicationSettings, ReactionsSettings reactionSettings) : base(communicationSettings, reactionSettings)
        {
        }

        public override string GetTopText(Npc npc)
        {
            return _communicationSettings.ScreenTitle.Enrich(npc);
        }

        public override List<CommunicationChoice> GenerateChoices(Npc npc)
        {
            var choices = _communicationSettings.SelectRandomPlaces(ChoiceCount);
            _rightChoice = choices[Random.Range(0, choices.Count)].Index;
            return choices;
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity)
        {
            string message;
            string bubbleTxt;
            var npc = npcEntity.Get<NpcComponent>().Npc;
            var character = characterEntity.Get<CharacterComponent>().Character;

            var looks = character.Parameters.Get(ParameterType.Looks.ToString());
            var smarts = character.Parameters.Get(ParameterType.Smarts.ToString());
            var sympathy = npc.Parameters.Get(ParameterType.Sympathy.ToString());
            var willpower = npc.Parameters.Get(ParameterType.Willpower.ToString());
            var relationship = npc.Parameters.Get(ParameterType.Relationship.ToString());
            var datesCount = npc.FlirtProgress.CompletedDates.Count;
            var result = _rightChoice == choiceIndex ? 10 : -10;

            npc.FlirtProgress.AskOutResult =
                (looks.Value * smarts.Value / 200) + sympathy.Value + result -
                (willpower.Value * relationship.Value + 10 * datesCount) > 50
                    ? 1
                    : -1;

            if (npc.FlirtProgress.AskOutResult > 0)
            {
                var relationshipNpcToChar =
                    npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                if (relationshipNpcToChar == null)
                {
                    npc.Relationships.Add(new Relationship
                    {
                        Person = character,
                        RelationshipType = RelationshipType.Lover
                    });
                }
                else
                {
                    relationshipNpcToChar.RelationshipType = RelationshipType.Lover;
                }
                var record = _communicationSettings.Communications[choiceIndex].DiaryEntry.Text
                    .Enrich(npc)
                    .Replace(_communicationSettings.Communications[choiceIndex].DiaryEntry.ReplaceGenderText, npc, character);
                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(record));
                bubbleTxt = _communicationSettings.Communications[choiceIndex].BubbleText.Text
                                .Enrich(npc)
                                .Replace(_communicationSettings.Communications[choiceIndex].ReplaceGenderText, npc, character);
                message = _communicationSettings.Communications[choiceIndex].Text
                                .Enrich(npc)
                                .Replace(_communicationSettings.Communications[choiceIndex].ReplaceGenderText, npc, character);
            }
            else
            {
                var record = _communicationSettings.CommunicationsNegative[choiceIndex].DiaryEntry.Text
                    .Enrich(npc)
                    .Replace(_communicationSettings.CommunicationsNegative[choiceIndex].DiaryEntry.ReplaceGenderText, npc, character);
                character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(record));
                bubbleTxt = _communicationSettings.CommunicationsNegative[choiceIndex].BubbleText.Text
                                .Enrich(npc)
                                .Replace(_communicationSettings.CommunicationsNegative[choiceIndex].ReplaceGenderText, npc, character);
                message = _communicationSettings.CommunicationsNegative[choiceIndex].Text
                                .Enrich(npc)
                                .Replace(_communicationSettings.CommunicationsNegative[choiceIndex].ReplaceGenderText, npc, character);
            }

            communicationEntity.Replace(new ChoicesChanged
            {
                Message = message,
                ButtonChoices = new List<CommunicationChoice>
                {
                    new CommunicationChoice
                    {
                        Index = 0,
                        Text = LocalizationDictionary.GetLocalizedString("ok")
                    }
                }
            });

            return bubbleTxt;
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity)
        {
            throw new System.NotImplementedException();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity,
            out string description)
        {
            throw new System.NotImplementedException();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity, out string description)
        {
            throw new System.NotImplementedException();
        }

        public override string GetChoiceText(int choiceIndex, Npc npc)
        {
            return _communicationSettings.Communications[choiceIndex].GetActualText(npc);
        }
    }
}