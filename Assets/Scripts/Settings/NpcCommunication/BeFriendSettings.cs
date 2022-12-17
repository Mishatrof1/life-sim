using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "BeFriendSettings", menuName = "LifeSim/NpcCommunication/BeFriend settings", order = 0)]
    public class BeFriendSettings : CommunicationSettings<BeFriendChoiceSettings>
    {
        [SerializeField] private string _screenTitle;
        [SerializeField] private string _choiceText;
        [SerializeField] private List<BeFriendChoiceSettings> _communications;
        public override List<BeFriendChoiceSettings> Communications => _communications;
        public string ScreenTitle => _screenTitle;
        public string ChoiceText => _choiceText;
    }

    [Serializable]
    public class BeFriendChoiceSettings : CommunicationChoiceSettings
    {
        [SerializeField] private CommunicationChoiceSettings _diaryEntryPositive;
        [SerializeField] private CommunicationChoiceSettings _diaryEntryNegative;
        [SerializeField] private CommunicationChoiceSettings _negativeCommunication;
        [SerializeField] private string _reactionPositive;
        [SerializeField] private string _reactionNegative;
        public CommunicationChoiceSettings NegativeCommunication => _negativeCommunication;
        public CommunicationChoiceSettings DiaryEntryPositive => _diaryEntryPositive;
        public CommunicationChoiceSettings DiaryEntryNegative => _diaryEntryNegative;
        public string ReactionPositive => _reactionPositive;
        public string ReactionNegative => _reactionNegative;
    }

}
