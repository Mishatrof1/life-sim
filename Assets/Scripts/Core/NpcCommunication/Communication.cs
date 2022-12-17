using System.Collections.Generic;
using Leopotam.Ecs;
using Settings.NpcCommunication;

namespace Core.NpcCommunication
{
    public abstract class Communication<TCommunicationSettings, TReactionSettings> : Communication
        where TCommunicationSettings : CommunicationSettings
        where TReactionSettings : ReactionsSettings
    {
        public const int ChoiceCount = 4;
        
        protected TCommunicationSettings _communicationSettings;
        protected TReactionSettings _reactionSettings;

        protected Communication(TCommunicationSettings communicationSettings, TReactionSettings reactionSettings)
        {
            _communicationSettings = communicationSettings;
            _reactionSettings = reactionSettings;
        }
    }

    public abstract class Communication
    {
        public abstract string GetTopText(Npc npc);
        public abstract List<CommunicationChoice> GenerateChoices(Npc npc);
        public abstract string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity);
        public abstract string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity, out string description);
        public abstract string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity, ref EcsEntity npcEntity);
        public abstract string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity, ref EcsEntity npcEntity, out string description);
        public abstract string GetChoiceText(int choiceIndex, Npc npc);
    }

    public struct CommunicationChoice
    {
        public int Index { get; set; }
        public string Text { get; set; }
    }
}