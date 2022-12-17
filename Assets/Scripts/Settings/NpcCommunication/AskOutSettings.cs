using Core.NpcCommunication;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "AskOutSettings", menuName = "LifeSim/NpcCommunication/AskOut settings", order = 0)]
    public class AskOutSettings : CommunicationSettings<AskOutChoiceSettings>
    {
        [SerializeField] private string _screenTitle;
        [SerializeField] private List<string> _places;
        [SerializeField] private List<AskOutChoiceSettings> _communicationsPositive;
        [SerializeField] private List<AskOutChoiceSettings> _communicationsNegative;
        
        public override List<AskOutChoiceSettings> Communications => _communicationsPositive;
        public List<AskOutChoiceSettings> CommunicationsNegative => _communicationsNegative;
        public List<string> Places => _places;
        public string ScreenTitle => _screenTitle;

        public List<CommunicationChoice> SelectRandomPlaces(int count)
        {
            var result = new List<CommunicationChoice>();
            var selectedIndexes = new HashSet<int>();
            var random = new System.Random(DateTime.Now.Millisecond);
            while (result.Count < count)
            {
                var index = random.Next(0, _places.Count);
                if (selectedIndexes.Contains(index))
                    continue;

                selectedIndexes.Add(index);
                result.Add(new CommunicationChoice
                {
                    Index = index,
                    Text = _places[index]
                });
            }
            return result;
        }

    }

    [Serializable]
    public class AskOutChoiceSettings : CommunicationChoiceSettings
    {
        [SerializeField] private CommunicationChoiceSettings bubble;
        [SerializeField] private CommunicationChoiceSettings diaryEntry;

        public CommunicationChoiceSettings BubbleText => bubble;
        public CommunicationChoiceSettings DiaryEntry => diaryEntry;

    }

}