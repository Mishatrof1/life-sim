using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings.Accessories
{
    [CreateAssetMenu(fileName = "AccessorySettings", menuName = "LifeSim/AccessorySettings", order = 0)]
    public class AccessorySettings : ScriptableObject
    {
        public int MinAge;
        public int MaxAge;
        public List<SpineSlotList> SlotLists;
    }
}