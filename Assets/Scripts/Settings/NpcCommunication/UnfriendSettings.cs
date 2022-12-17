using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "UnfriendSettings", menuName = "LifeSim/NpcCommunication/Unfriend settings", order = 0)]
    public class UnfriendSettings : CommunicationSettings<UnfriendChoiceSettings>
    {
        [SerializeField] private string _screenTitle;
        [SerializeField] private string _choiceTitle;
        [SerializeField] private List<UnfriendChoiceSettings> _communications;
        public override List<UnfriendChoiceSettings> Communications => _communications;
        public string ScreenTitle => _screenTitle;
        public string ChoiceTitle => _choiceTitle;
    }

    [Serializable]
    public class UnfriendChoiceSettings : CommunicationChoiceSettings
    {
        [SerializeField] private string _bubbleText;
        [SerializeField] private CommunicationChoiceSettings _diaryEntry;

        public string BubbleText => _bubbleText;
        public CommunicationChoiceSettings DiaryEntry => _diaryEntry;
    }

}

