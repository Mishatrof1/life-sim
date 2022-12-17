using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "DateSettings", menuName = "LifeSim/NpcCommunication/Date settings", order = 0)]
    public class DateSettings : CommunicationSettings<DateChoiceSettings>
    {
        [SerializeField] private string _screenTitle;
        [SerializeField] private string _screenTitleNoPlace;
        [SerializeField] private string _rightChoiceBubble;
        [SerializeField] private string _wrongChoiceBubble;
        [SerializeField] private int _intermediatePoolSize;
        [SerializeField] private int _sympathyDec;
        [SerializeField] private string _goodDateMessage;
        [SerializeField] private string _badDateMessage;
        [SerializeField] private CommunicationChoiceSettings _askOutAcceptMessage;
        [SerializeField] private CommunicationChoiceSettings _askOutRefuseMessage;
        [SerializeField] private List<DateChoiceSettings> _communications;

        public int SympathyDec => _sympathyDec;
        public int IntermediatePoolSize => _intermediatePoolSize;
        public override List<DateChoiceSettings> Communications => _communications;

        public string ScreenTitle => _screenTitle;
        public string ScreenTitleNoPlace => _screenTitleNoPlace;
        public string RightChoiceBubble => _rightChoiceBubble;
        public string WrongChoiceBubble => _wrongChoiceBubble;
        public string GoodDateMessage => _goodDateMessage;
        public string BadDateMessage => _badDateMessage;
        public CommunicationChoiceSettings AskOutAcceptMessage => _askOutAcceptMessage;
        public CommunicationChoiceSettings AskOutRefuseMessage => _askOutRefuseMessage;

    }

    [Serializable]
    public class DateChoiceSettings : CommunicationChoiceSettings
    {
        [SerializeField] private string place;
        [SerializeField] private CommunicationChoiceSettings diaryEntryAccept;
        [SerializeField] private CommunicationChoiceSettings diaryEntryRefuse;

        public string Place => place;
        public CommunicationChoiceSettings DiaryEntryAccept => diaryEntryAccept;
        public CommunicationChoiceSettings DiaryEntryRefuse => diaryEntryRefuse;

    }
}