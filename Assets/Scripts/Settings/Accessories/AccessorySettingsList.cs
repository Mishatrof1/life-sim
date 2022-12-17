using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Settings.Accessories
{
    [CreateAssetMenu(fileName = "AccessorySettingsList", menuName = "LifeSim/AccessorySettingsList", order = 0)]
    public class AccessorySettingsList : ScriptableObject
    {
        public List<AccessorySettings> AccessorySettings;

        
        public List<ColorGroup> GetUsedColorGroups()
        {
            return AccessorySettings.SelectMany(settings =>
                settings.SlotLists.SelectMany(sl => sl.Slots.Select(s => s.ColorGroup))).Distinct().ToList();
        }
    }
}