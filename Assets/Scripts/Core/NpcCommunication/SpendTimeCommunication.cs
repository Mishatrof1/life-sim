using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Extensions;
using Leopotam.Ecs;
using Modules;
using Settings.NpcCommunication;
using Random = UnityEngine.Random;

namespace Core.NpcCommunication
{
    public class SpendTimeCommunication : Communication<SpendTimeSettings, EmptyReactionsSettings>
    {
        public SpendTimeCommunication(SpendTimeSettings communicationSettings, EmptyReactionsSettings reactionSettings) : base(communicationSettings, reactionSettings)
        {
        }

        public override string GetTopText(Npc npc)
        {
            return _communicationSettings.ScreenTitle.Enrich(npc);
        }

        public override List<CommunicationChoice> GenerateChoices(Npc npc)
        {
            return new List<CommunicationChoice>
            {
                new CommunicationChoice
                {
                    Index = 0,
                    Text = LocalizationDictionary.GetLocalizedString("ok")
                }
            };
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity)
        {
            throw new NotImplementedException();
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
            var npc = npcEntity.Get<NpcComponent>().Npc;
            var character = characterEntity.Get<CharacterComponent>().Character;
            ref var communication = ref communicationEntity.Get<Components.NpcCommunication>();
            var willpower = npc.Parameters.Get(ParameterType.Willpower.ToString());
            var relationship = npc.Parameters.Get(ParameterType.Relationship.ToString());
            communication.SpendTimeResult = willpower.Value / 100 * relationship.Value > 15;

            if (communication.SpendTimeResult)
            {
                character.Parameters.Get(ParameterType.Happiness.ToString()).Inc(Random.Range(7.5f, 15f));
                relationship.Inc(Random.Range(5f, 15f));
            }
            else
            {
                character.Parameters.Get(ParameterType.Happiness.ToString()).Dec(Random.Range(7.5f, 15f));
            }

            var spendTimeResult = communication.SpendTimeResult;
            var storyPool = _communicationSettings
                .SpendTimeStories.Where(s => s.IsSuccess == spendTimeResult).ToList();
            var story = storyPool[Random.Range(0, storyPool.Count)];
            
            character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(story.LogText.Enrich(npc)));

            description = story.Text.Enrich(npc);
            return story.BubbleText.Enrich(npc);
        }

        public override string GetChoiceText(int choiceIndex, Npc npc)
        {
            return LocalizationDictionary.GetLocalizedString("ok");
        }
    }
}