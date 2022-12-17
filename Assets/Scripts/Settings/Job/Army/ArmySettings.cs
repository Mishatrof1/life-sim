using System;
using System.Collections.Generic;
using Core;
using Core.Education;
using UnityEditor;
using UnityEngine;

namespace Settings.Job.Simple
{
    [CreateAssetMenu(fileName = "ArmySettings", menuName = "LifeSim/Army/ArmySettings", order = 1)]
    public class ArmySettings : ScriptableObject
    {
        public List<ArmyConfiguration> Configurations;

        public SalaryEditor salary;
        
#if UNITY_EDITOR
        [ContextMenu("Setup")]
        public void Setup()
        {
            Configurations = new List<ArmyConfiguration>();
            
            var guids = AssetDatabase.FindAssets("t:PositionConfiguration", new[] {"Assets/Settings/Job/Simple/Positions"});
            foreach (var guid in guids)
            {
                Configurations.Add(AssetDatabase.LoadAssetAtPath<ArmyConfiguration>(AssetDatabase.GUIDToAssetPath(guid)));
            }
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}