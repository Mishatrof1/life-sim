using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.Appearance
{
    [CreateAssetMenu(fileName = "AppearanceGroup", menuName = "LifeSim/Animations/AppearanceGroup", order = 0)]
    public class AppearanceGroup : ScriptableObject
    {
        public List<SpineSlotList> SlotList;
    }
}