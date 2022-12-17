using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu(fileName = "GiftSettings", menuName = "LifeSim/NpcCommunication/Gift settings", order = 0)]
    public class GiftSettings : CommunicationSettings<GiftChoiceSettings>
    {

        [SerializeField] private string _screenTitle;
        [SerializeField] private string _giftDonatedMessage;
        [SerializeField] private string _notEnoughMoneyMessage;

        [SerializeField] private List<GiftChoiceSettings> _communications;

        public override List<GiftChoiceSettings> Communications => _communications;

        public string ScreenTitle => _screenTitle;
        public string GiftDonatedMessage => _giftDonatedMessage;
        public string NotEnoughMoneyMessage => _notEnoughMoneyMessage;


#if UNITY_EDITOR
        public void Clear()
        {
            _communications.Clear();
        }

        public void Add(string text, float cost, float relationshipDelta)
        {
            _communications.Add(new GiftChoiceSettings
            {
                Text = text,
                Cost = cost,
                RelationshipDeltaDefault = relationshipDelta
            });
        }
#endif
    }

    [Serializable]
    public class GiftChoiceSettings : CommunicationChoiceSettings
    {
        public float Cost;
        public float RelationshipDeltaDefault;
    }
}