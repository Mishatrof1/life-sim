using System;
using System.Collections.Generic;
using Core;
using Core.Education;
using UnityEditor;
using UnityEngine;

namespace Settings.Job.Simple
{
    [CreateAssetMenu(fileName = "PositionsSettings", menuName = "LifeSim/Job/Simple/PositionsSettings", order = 0)]
    public class PositionsSettings : ScriptableObject
    {
        public List<PositionConfiguration> Configurations;
        
#if UNITY_EDITOR
        [ContextMenu("Setup")]
        public void Setup()
        {
            Configurations = new List<PositionConfiguration>();
            
            var guids = AssetDatabase.FindAssets("t:PositionConfiguration", new[] {"Assets/Settings/Job/Simple/Positions"});
            foreach (var guid in guids)
            {
                Configurations.Add(AssetDatabase.LoadAssetAtPath<PositionConfiguration>(AssetDatabase.GUIDToAssetPath(guid)));
            }
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}