using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "SpendTimeSettings", menuName = "LifeSim/NpcCommunication/SpendTime settings", order = 0)]
    public class SpendTimeSettings : CommunicationSettings<SpendTimeChoiceSettings>
    {
        [SerializeField] private string _screenTitle;
        [SerializeField] private string _askOutAcceptMessage;
        [SerializeField] private string _askOutRefuseMessage;
        [SerializeField] private List<SpendTimeChoiceSettings> _communications;
        [SerializeField] private List<SpendTimeStory> _spendTimeStories;

        public override List<SpendTimeChoiceSettings> Communications => _communications;
        public List<SpendTimeStory> SpendTimeStories => _spendTimeStories;

        public string ScreenTitle => _screenTitle;
        public string AskOutAcceptMessage => _askOutAcceptMessage;
        public string AskOutRefuseMessage => _askOutRefuseMessage;

    }

    [Serializable]
    public class SpendTimeChoiceSettings : CommunicationChoiceSettings
    {
        [SerializeField] private CommunicationChoiceSettings diaryEntryAccept;
        [SerializeField] private CommunicationChoiceSettings diaryEntryRefuse;

        public CommunicationChoiceSettings DiaryEntryAccept => diaryEntryAccept;
        public CommunicationChoiceSettings DiaryEntryRefuse => diaryEntryRefuse;
    }

    [Serializable]
    public class SpendTimeStory
    {
        public string Text;
        public string LogText;
        public string BubbleText;
        public bool IsSuccess;
    }
}