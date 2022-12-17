using Components;
using Components.Events;
using Core.Education;
using Leopotam.Ecs;
using Modules;
using Settings.NpcCommunication;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;

namespace Core.NpcCommunication
{
    public class AskMoneyCommunication : Communication<AskMoneySettings, ReactionsSettings>
    {
        public int DefaultAskingMoney => _communicationSettings.DefaultAskingMoney;
        public int DefaultSliderMaxValue => _communicationSettings.DefaultSliderValue;

        public int AskingMoney { get; set; }

        public AskMoneyCommunication(AskMoneySettings communicationSettings, ReactionsSettings reactionSettings) : base(communicationSettings, reactionSettings)
        {
        }

        public override string GetTopText(Npc npc)
        {
            return _communicationSettings.ScreenTitle;
        }

        public override List<CommunicationChoice> GenerateChoices(Npc npc)
        {
            return new List<CommunicationChoice>()
            {
                new CommunicationChoice { Index = 0, Text = LocalizationDictionary.GetLocalizedString("communication_ask_money")}
            };
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity)
        {

            var communication = communicationEntity.Get<Components.NpcCommunication>();
            var npc = communication.Npc;
            var character = communication.Character;

            string message = "";
            string diaryEntry = "";

            var relation = npc.Relationships.FirstOrDefault(r =>
                                            r.Person.Id == character.Id);
            var relationship = npc.Parameters.Get(ParameterType.Relationship.ToString()).Value;
            float npcBallance = npc.Parameters.Get(ParameterType.Balance.ToString()).Value;
            float npcGenerosity = npc.Parameters.Get(ParameterType.Generosity.ToString()).Value;
            float npcKindness = npc.Parameters.Get(ParameterType.Kindness.ToString()).Value;
            float npcWillpower = npc.Parameters.Get(ParameterType.Willpower.ToString()).Value;

            var productivity = character.CurrentOccupation is SimpleWorkService ?
                ((SimpleWorkService)character.CurrentOccupation).Productivity : 0; //todo популярность в коллективе

            bool isParent = 
                relation?.RelationshipType == RelationshipType.Mother || 
                relation?.RelationshipType == RelationshipType.Father;
            bool isParthner = 
                relation?.RelationshipType == RelationshipType.Wife || 
                relation?.RelationshipType == RelationshipType.Husband;
            bool isRelative =
                relation?.RelationshipType == RelationshipType.Brother ||
                relation?.RelationshipType == RelationshipType.Sister; //todo проверка гениологического древа
            bool isLover =
                relation?.RelationshipType == RelationshipType.Lover;
            bool isFriend =
                relation?.RelationshipType == RelationshipType.Friend;
            bool isCollegue = character.CurrentOccupation is SimpleWorkService && npc.CurrentOccupation == character.CurrentOccupation;

            bool moneyCheck = (npcBallance * npcGenerosity * 0.75f) >= AskingMoney;
            bool debtCheck = true; //todo система долгов
            bool probabilityCheck = Random.Range(0, 101) <= (npcKindness / 2 + npcGenerosity / 2);

            bool isReady = false;

            isReady |= isParthner; 
            isReady |= isParent && relationship > 90 && AskingMoney < 100;

            isReady |= probabilityCheck && (
                (relation?.RelationshipType != RelationshipType.Enemy && relationship > 50 && (isCollegue ? (productivity >= 75) : true)) ||
                (isRelative && (npc.Age.TotalYears > 18 || npc.Age.TotalYears > character.Age.TotalYears)) ||
                isFriend ||
                isLover
                );

            isReady &= debtCheck;
            if (isReady && moneyCheck)
            {
                float money = AskingMoney;
                var randGenerosity = npcGenerosity + Random.Range(-12, 12);
                if (randGenerosity < 25)
                {
                    money = (int)(Random.Range(0.5f, 0.95f) * money);
                    money = Mathf.Max(1, money);
                } else if (npcGenerosity >= 75)
                {
                    money = (int)(Random.Range(1.1f, 2.95f) * money);
                    money = Mathf.Min(npcBallance, money);
                }
                message = $"{_communicationSettings.NpcAcceptText.GetActualText(npc).Enrich(npc)} {money}";
                diaryEntry = $"{_communicationSettings.DiaryEntryPositive.GetActualText(npc).Enrich(npc)} {money}";
                character.Parameters.Get(ParameterType.Balance.ToString()).Inc(money);
                npc.Parameters.Get(ParameterType.Balance.ToString()).Dec(money);
            } else
            {
                message = $"{_communicationSettings.NpcRefuseText.GetActualText(npc).Enrich(npc)}";
                diaryEntry = $"{_communicationSettings.DiaryEntryNegative.GetActualText(npc).Enrich(npc)}";
                if (!isRelative && !isParent && !isParthner && npcGenerosity < 75 && npcWillpower < 75)
                {
                    //todo ухудшение отношений. ГДД еще не готов
                }
            }
            character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(diaryEntry));
            communicationEntity.Replace(new ChoicesChanged
            {
                Message = message,
                ButtonChoices = new List<CommunicationChoice>
                {
                    new CommunicationChoice
                    {
                        Index = choiceIndex,
                        Text = LocalizationDictionary.GetLocalizedString("ok")
                    }
                }
            });
            return "";
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
            return "";
        }
    }
}
