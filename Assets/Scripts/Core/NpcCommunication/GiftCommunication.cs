using System.Collections.Generic;
using System.Linq;
using Components;
using Extensions;
using Leopotam.Ecs;
using Settings.NpcCommunication;
using UnityEngine;

namespace Core.NpcCommunication
{
    public class GiftCommunication : Communication<GiftSettings, GiftReactionsSettings>
    {
        public GiftCommunication(GiftSettings communicationSettings, GiftReactionsSettings reactionSettings) : base(communicationSettings, reactionSettings)
        {
        }

        public override string GetTopText(Npc npc)
        {
            return _communicationSettings.ScreenTitle.Enrich(npc);
        }

        public override List<CommunicationChoice> GenerateChoices(Npc npc)
        {
            return _communicationSettings.SelectRandomChoices(10, npc).Select(choice => new CommunicationChoice
            {
                Index = choice.Index,
                Text = $"{choice.Text} (${_communicationSettings.Communications[choice.Index].Cost:N2})"
            }).ToList();
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
            ref EcsEntity npcEntity)
        {
            var character = characterEntity.Get<CharacterComponent>().Character;
            var npc = npcEntity.Get<NpcComponent>().Npc;
            ref var communicationComponent = ref communicationEntity.Get<Components.NpcCommunication>();
            var choice = _communicationSettings.Communications[choiceIndex];
            var balance = character.Parameters.Get(ParameterType.Balance.ToString());

            var bubbleText = "";
            var messageText = _communicationSettings.NotEnoughMoneyMessage;
            
            if (balance.Value >= choice.Cost)
            {
                balance.Dec(choice.Cost);
                communicationComponent.GiftFlag = true;
                npc.Parameters.Get(ParameterType.Relationship.ToString()).Inc(choice.RelationshipDeltaDefault);
                var randomReactionPool =
                    _reactionSettings.ReactionsPools[Random.Range(0, _reactionSettings.ReactionsPools.Count)];
                bubbleText = randomReactionPool.Reactions[Random.Range(0, randomReactionPool.Reactions.Count)];
                messageText = _communicationSettings.GiftDonatedMessage;
            }

            communicationComponent.Final = true;
            communicationEntity
                .Replace(new ChoicesChanged
                {
                    Message = messageText,
                    ButtonChoices = new List<CommunicationChoice>
                    {
                        new CommunicationChoice
                        {
                            Index = 0,
                            Text = LocalizationDictionary.GetLocalizedString("ok")
                        }
                    }
                });
            
            return bubbleText;
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