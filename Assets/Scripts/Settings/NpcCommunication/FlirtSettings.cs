using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "FlirtSettings", menuName = "LifeSim/NpcCommunication/Flirt settings", order = 0)]
    public class FlirtSettings : CommunicationSettings<FlirtChoiceSettings>
    {
        [SerializeField] private string _screenTitle;

        [SerializeField] private int _flirtCountMin;
        [SerializeField] private int _flirtCountMax;
        [SerializeField] private int _sympathyIncMin;
        [SerializeField] private int _sympathyIncMax;
        [SerializeField] private int _sympathyThreshold;
        
        [Header("Failed flirt")]
        [SerializeField] private int _relationshipYearDec;
        [SerializeField] private int _relationshipInstantDec;
        [SerializeField] private int _sympathyDecMin;
        [SerializeField] private int _sympathyDecMax;
        
        [Space]
        [SerializeField] private List<FlirtChoiceSettings> _communications;
        [SerializeField] private List<FlirtResponseSettings> _responses;
        [SerializeField] private List<FlirtResponseLogSettings> _responseLogs;
        [SerializeField] private List<FlirtResultSettings> _resultSettings;
        [SerializeField] private List<FlirtOverdoseSettings> _overdoseSettings;

        public int FlirtCountMin => _flirtCountMin;
        public int FlirtCountMax => _flirtCountMax;
        public int SympathyIncMin => _sympathyIncMin;
        public int SympathyIncMax => _sympathyIncMax;
        public int SympathyThreshold => _sympathyThreshold;
        public int RelationshipYearDec => _relationshipYearDec;
        public int RelationshipInstantDec => _relationshipInstantDec;
        public int SympathyDecMin => _sympathyDecMin;
        public int SympathyDecMax => _sympathyDecMax;
        
        public override List<FlirtChoiceSettings> Communications => _communications;
        public List<FlirtResponseSettings> Responses => _responses;
        public List<FlirtResultSettings> ResultSettings => _resultSettings;
        public List<FlirtOverdoseSettings> FlirtOverdoseSettings => _overdoseSettings;
        public List<FlirtResponseLogSettings> FlirtResponseLogSettings => _responseLogs;

        public string ScreenTitle => _screenTitle;

    }

    [Serializable]
    public class FlirtChoiceSettings : CommunicationChoiceSettings
    {
        [SerializeField] private bool _persistence;
        public bool Persistence => _persistence;
        public string SuccessBubleText;
        public List<ReplaceText> ReplaceSuccessBubleText;
        public string FailBubleText;
        public List<ReplaceText> ReplaceFailBubleText;
    }
    
    [Serializable]
    public class FlirtResponseSettings
    {
        public string Text;
        public List<ReplaceText> ReplaceText;
        public bool IsSuccess;
    }
    
    [Serializable]
    public class FlirtResponseLogSettings
    {
        public string Text;
        public List<ReplaceText> ReplaceText;
        public bool IsSuccess;
    }
    
    [Serializable]
    public class FlirtResultSettings
    {
        public string LogText;
        public List<ReplaceText> ReplaceLogText;
        public bool IsSuccess;
    }
    
    [Serializable]
    public class FlirtOverdoseSettings
    {
        public string BubleText;
        public List<ReplaceText> ReplaceBubleText;
        public string LogText;
        public List<ReplaceText> ReplaceLogText;
    }
}