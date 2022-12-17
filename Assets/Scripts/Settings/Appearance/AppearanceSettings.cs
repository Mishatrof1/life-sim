using System;
using System.Collections.Generic;

namespace Settings.Appearance
{
    [Serializable]
    public class AppearanceSettings
    {
        public Genders Gender;
        public int MinAge;
        public int MaxAge;
        public List<AppearanceGroup> AppearanceGroups;
    }
}