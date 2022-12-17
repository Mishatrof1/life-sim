using Components;
using Extensions;
using Leopotam.Ecs;
using Modules;
using Settings.NpcCommunication;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.NpcCommunication
{
    public class UnFriendCommunication : Communication<UnfriendSettings, EmptyReactionsSettings>
    {
        public UnFriendCommunication(UnfriendSettings communicationSettings, EmptyReactionsSettings reactionSettings) : base(communicationSettings, reactionSettings)
        {
        }

        public override string GetTopText(Npc npc)
        {
            return _communicationSettings.ScreenTitle;
        }

        public override List<CommunicationChoice> GenerateChoices(Npc npc)
        {
            return new List<CommunicationChoice> { new CommunicationChoice
            {
                Index = 0,
                Text = _communicationSettings.ChoiceTitle
            } };
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity)
        
        {
            var npc = npcEntity.Get<NpcComponent>().Npc;
            var character = characterEntity.Get<CharacterComponent>().Character;
            var relationship = Utils.NormalDistribution(-15, 35, 10, 25);

            int random = Random.Range(0, _communicationSettings.Communications.Count);
            var _choiceSettings = _communicationSettings.Communications[random];

            npc.Parameters.Get(ParameterType.Relationship.ToString()).Set(relationship);
            npc.BefriendProgress.HadFriendStatus = false;

            if (relationship >= 0)
            {
                character.Parameters.Get(ParameterType.Happiness.ToString()).Dec(7);
                character.Parameters.Get(ParameterType.Conformity.ToString()).Dec(5);
                character.Parameters.Get(ParameterType.Kindness.ToString()).Dec(5);
                npc.Parameters.Get(ParameterType.Happiness.ToString()).Dec(20);
                var r =  npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                if (r != null)
                    npc.Relationships.Remove(r);
            }
            else
            {
                character.Parameters.Get(ParameterType.Happiness.ToString()).Dec(15);
                character.Parameters.Get(ParameterType.Conformity.ToString()).Dec(5);
                character.Parameters.Get(ParameterType.Kindness.ToString()).Dec(5);
                npc.Parameters.Get(ParameterType.Happiness.ToString()).Dec(25);
                npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id).RelationshipType = RelationshipType.Enemy;
            }
            var communicationResult = _choiceSettings.Text.Enrich(npc).Replace(_choiceSettings.ReplaceGenderText, npc, character);
            var ageLog = _choiceSettings.DiaryEntry.Text.Enrich(npc).Replace(_choiceSettings.DiaryEntry.ReplaceGenderText, npc, character);

            character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(ageLog));
            SendCommunicationResult(communicationEntity, communicationResult);
            return _choiceSettings.BubbleText;
        }

        private void SendCommunicationResult(EcsEntity communicationEntity, string message)
        {
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
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity,
            out string description)
        {
            throw new System.NotImplementedException();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity)
        {
            return "";
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity, out string description)
        {
            throw new System.NotImplementedException();
        }

        public override string GetChoiceText(int choiceIndex, Npc npc)
        {
            return _communicationSettings.ChoiceTitle;
        }

    }
}
