using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "BeFriendRequestSettings", menuName = "LifeSim/NpcCommunication/BeFriendRequest settings", order = 0)]
    public class BeFriendRequestSettings : CommunicationSettings<BeFriendRequestChoiceSettings>
    {
        [SerializeField] private string _popupTitle;
        [SerializeField] private List<BeFriendRequestChoiceSettings> _communications;
        public override List<BeFriendRequestChoiceSettings> Communications => _communications;
        public string PopupTitle => _popupTitle;
    }

    [Serializable]
    public class BeFriendRequestChoiceSettings : CommunicationChoiceSettings
    {
        [SerializeField] private CommunicationChoiceSettings _invite;
        [SerializeField] private CommunicationChoiceSettings _diaryEntryPositive;
        [SerializeField] private CommunicationChoiceSettings _diaryEntryNegatie;
        [SerializeField] private CommunicationChoiceSettings _negativeCommunication;
        [SerializeField] private string _reactionPositive;
        [SerializeField] private string _reactionNegative;
        public CommunicationChoiceSettings Invite => _invite;
        public CommunicationChoiceSettings NegativeCommunication => _negativeCommunication;
        public CommunicationChoiceSettings DiaryEntryPositive => _diaryEntryPositive;
        public CommunicationChoiceSettings DiaryEntryNegatie => _diaryEntryNegatie;
        public string ReactionPositive => _reactionPositive;
        public string ReactionNegative => _reactionNegative;

    }

}
