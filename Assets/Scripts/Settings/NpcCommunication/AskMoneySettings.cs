using Core.NpcCommunication;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "AskMoneySettings", menuName = "LifeSim/NpcCommunication/AskMoney settings", order = 0)]
    public class AskMoneySettings : CommunicationSettings
    {
        [SerializeField] private string _screenTitle;
        [SerializeField] private CommunicationChoiceSettings _diaryEntryPositive;
        [SerializeField] private CommunicationChoiceSettings _diaryEntryNegative;
        [SerializeField] private CommunicationChoiceSettings _npcAcceptText;
        [SerializeField] private CommunicationChoiceSettings _npcRefuseText;
        [SerializeField] private int _defaultAskingMoney = 100;
        [SerializeField] private int _defaultSliderMaxValue = 10000;


        public string ScreenTitle => _screenTitle;
        public CommunicationChoiceSettings DiaryEntryPositive => _diaryEntryPositive;
        public CommunicationChoiceSettings DiaryEntryNegative => _diaryEntryNegative;
        public CommunicationChoiceSettings NpcAcceptText => _npcAcceptText;
        public CommunicationChoiceSettings NpcRefuseText => _npcRefuseText;

        public int DefaultAskingMoney => _defaultAskingMoney;
        public int DefaultSliderValue => _defaultSliderMaxValue;

    }

}
