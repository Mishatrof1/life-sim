using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "EmptySettings", menuName = "LifeSim/NpcCommunication/Empty settings", order = 0)]
    public class EmptySettings : CommunicationSettings<CommunicationChoiceSettings>
    {
        public override List<CommunicationChoiceSettings> Communications => new List<CommunicationChoiceSettings>();
    }
}