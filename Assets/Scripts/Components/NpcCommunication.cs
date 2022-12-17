using System.Collections.Generic;
using Core;
using Core.NpcCommunication;
using Modules.Navigation;
using Settings.NpcCommunication;

namespace Components
{
    public struct NpcCommunication
    {
        public Character Character { get; set; }
        public Npc Npc { get; set; }
        public Core.NpcCommunication.Communication Communication { get; set; }
        public List<CommunicationChoice> ButtonChoices;
        public List<CommunicationChoice> DropListChoices;
        public bool Final { get; set; }
        public bool AskOutFlag { get; set; }
        public bool GiftFlag { get; set; }
        public bool SpendTimeResult { get; set; }
    }
}