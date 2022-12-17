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
    public class BefriendCommunication : Communication<BeFriendSettings, EmptyReactionsSettings>
    {

        public BefriendCommunication(BeFriendSettings communicationSettings, EmptyReactionsSettings reactionSettings) : base(communicationSettings, reactionSettings)
        {
        }

        public override string GetTopText(Npc npc)
        {
            return _communicationSettings.ScreenTitle.Enrich(npc);
        }

        public override List<CommunicationChoice> GenerateChoices(Npc npc)
        {
            return new List<CommunicationChoice> { new CommunicationChoice
            {
                Index = 0,
                Text = _communicationSettings.ChoiceText
            } };
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity, ref EcsEntity npcEntity)
        {
            var npc = npcEntity.Get<NpcComponent>().Npc;
            var character = characterEntity.Get<CharacterComponent>().Character;

            int random = Random.Range(0, _communicationSettings.Communications.Count);
            var _choiceSettings = _communicationSettings.Communications[random];

            CommunicationChoiceSettings diaryEntry;
            string ageLog = "";
            string communicationResult = "";
            string reaction = "";

            if (CanFriend(character, npc))
            {
                var relation =
                    npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                if (relation == null)
                {
                    npc.Relationships.Add(new Relationship
                    {
                        Person = character,
                        RelationshipType = RelationshipType.Friend
                    });
                }
                else
                {
                    relation.RelationshipType = RelationshipType.Friend;
                }

                npc.BefriendProgress.HadFriendStatus = true;
                var relationshipParam = npc.Parameters.Get(ParameterType.Relationship.ToString());
                if (relationshipParam.Value < 75)
                {
                    relationshipParam.Set(75);
                }
                character.Parameters.Get(ParameterType.Happiness.ToString()).Inc(10);
                diaryEntry = _choiceSettings.DiaryEntryPositive;
                
                communicationResult = _choiceSettings.Text
                    .Enrich(npc)
                    .Replace(_choiceSettings.ReplaceGenderText, npc, character);
                reaction =  _choiceSettings.ReactionPositive;
            }
            else
            {
                character.Parameters.Get(ParameterType.Happiness.ToString()).Dec(10);
                diaryEntry = _choiceSettings.DiaryEntryNegative;
                communicationResult = _choiceSettings.NegativeCommunication.Text
                    .Enrich(npc)
                    .Replace(_choiceSettings.NegativeCommunication.ReplaceGenderText, npc, character);
                reaction = _choiceSettings.ReactionNegative;
            }

            ageLog = diaryEntry.Text.Enrich(npc).Replace(diaryEntry.ReplaceGenderText, npc, character);
            character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(ageLog));
            SendCommunicationResult(communicationEntity, communicationResult);
            return reaction;
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
            return _communicationSettings.ChoiceText;
        }

        private bool CanFriend(Character character, Npc npc)
        {
            var characterWillpower = character.Parameters.Get(ParameterType.Willpower.ToString());
            var npcWillpower = npc.Parameters.Get(ParameterType.Willpower.ToString());
            var relationship = npc.Parameters.Get(ParameterType.Relationship.ToString());
            var willpowerDelta = characterWillpower.Value - npcWillpower.Value;

            return willpowerDelta switch
            {
                { } w when (w >= 75) => true,
                { } w when (w < 75 && w > 25) => Check7525(),
                { } w when (w <= 25) => Check25(),
                _ => false
            };
            
            bool Check7525()
            {
                return relationship.Value switch
                {
                    { } r when (r > 60) => true,
                    { } r when (r <= 60 && r >= 20) => Random.Range(0, 101) <= relationship.Value + 5,
                    { } r when (r < 20) => false,
                    _ => false
                };
            }
            
            bool Check25()
            {
                return relationship.Value switch
                {
                    { } r when (r > 75) => true,
                    { } r when (r <= 75 && r >= 35) => Random.Range(0, 101) <= relationship.Value - 10,
                    { } r when (r <= 35) => false,
                    _ => false
                };
            }
        }
    }
}