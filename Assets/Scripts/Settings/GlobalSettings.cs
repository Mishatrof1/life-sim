using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings
{
    [CreateAssetMenu(fileName = "GlobalSettings", menuName = "GlobalSettings", order = 0)]
    public class GlobalSettings : ScriptableObject
    {
        [Serializable]
        public class Localization
        {
            public SystemLanguage language;
            public TextAsset jSon;
        }

        public List<TextAsset> LogSets;

        [Space]

        public List<Localization> localizations;
        
#if UNITY_EDITOR
        [Space]
        [Header("Editor only")]
        public bool DisableStories;
        public bool MaxCharacterParameters;
        public bool ResetSaveOnStart;
        public float StartBalance;
#endif
    }
}