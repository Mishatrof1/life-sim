using System;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    [CreateAssetMenu()]
    public class LocationsSaveData : SaveData
    {
        public List<Location> Locations;

        public override void ResetSaveData()
        {
            Locations = new List<Location>();
        }
    }

    [Serializable]
    public class Location
    {
        public string Id;
        public string Country;
        public string City;
        public float TrafficJamFactor;
        public float PublicTransport;
    }
}