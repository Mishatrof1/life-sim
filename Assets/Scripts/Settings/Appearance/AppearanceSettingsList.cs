using System.Collections.Generic;
using UnityEngine;

namespace Settings.Appearance
{
    [CreateAssetMenu(fileName = "AppearanceSettingsList", menuName = "LifeSim/Animations/AppearanceSettingsList", order = 0)]
    public class AppearanceSettingsList : ScriptableObject
    {
        public List<AppearanceSettings> AppearanceSettings;
    }
}