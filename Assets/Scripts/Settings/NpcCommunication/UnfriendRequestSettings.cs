using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{

    [CreateAssetMenu(fileName = "UnfriendRequestSettings", menuName = "LifeSim/NpcCommunication/UnfriendRequest settings", order = 0)]
    public class UnfriendRequestSettings : CommunicationSettings<UnfriendRequestChoiceSettings>
    {
        [SerializeField] private string _popupTitle;
        [SerializeField] private List<UnfriendRequestChoiceSettings> _communications;
        public override List<UnfriendRequestChoiceSettings> Communications => _communications;
        public string PopupTitle => _popupTitle;
    }

    [Serializable]
    public class UnfriendRequestChoiceSettings : CommunicationChoiceSettings
    {
        [SerializeField] private CommunicationChoiceSettings _diaryEntry;
        public CommunicationChoiceSettings DiaryEntry => _diaryEntry;
    }

}
