using System.Collections.Generic;
using Core.NpcCommunication;
using Modules.Navigation;

namespace Components
{
    public struct ChoicesChanged
    {
        public string Message;
        public List<CommunicationChoice> ButtonChoices;
        public List<CommunicationChoice> DropListChoices;
    }
}