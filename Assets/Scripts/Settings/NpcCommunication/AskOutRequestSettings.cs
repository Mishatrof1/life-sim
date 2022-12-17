using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "AskOutRequestSettings", menuName = "LifeSim/NpcCommunication/AskOutRequest settings", order = 0)]
    public class AskOutRequestSettings : CommunicationSettings<AskOutRequestChoiceSettings>
    {
        [SerializeField] private string _popupTitle;
        [SerializeField] private string _acceptMesage;
        [SerializeField] private string _refuseMesage;
        [SerializeField] private List<AskOutRequestChoiceSettings> _communications;
        public override List<AskOutRequestChoiceSettings> Communications => _communications;
        public string PopupTitle => _popupTitle;
        public string AcceptMessage => _acceptMesage;
        public string RefuseMessage => _refuseMesage;
    }

    [Serializable]
    public class AskOutRequestChoiceSettings : CommunicationChoiceSettings
    {
        [SerializeField] private CommunicationChoiceSettings _diaryEntryPositive;
        [SerializeField] private CommunicationChoiceSettings _diaryEntryNegatie;
        public CommunicationChoiceSettings DiaryEntryPositive => _diaryEntryPositive;
        public CommunicationChoiceSettings DiaryEntryNegatie => _diaryEntryNegatie;
    }

}




