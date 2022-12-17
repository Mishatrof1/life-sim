using System;
using System.Collections.Generic;
using Core;
using Core.Education;
using UnityEditor;
using UnityEngine;


    [CreateAssetMenu(fileName = "PositionsSettings", menuName = "LifeSim/PartTime/Positions Settings", order = 0)]
    public class PartTimePositionSettings : ScriptableObject
    {
        public List<PartTimePositionConfiguration> Configurations;

#if UNITY_EDITOR
        [ContextMenu("Setup")]
        public void Setup()
        {
            Configurations = new List<PartTimePositionConfiguration>();

            var guids = AssetDatabase.FindAssets("t:PartTimePositionConfiguration", new[] { "Assets/Settings/PartTimeSettings/PartTimeVacancy/Vacancy" });
            foreach (var guid in guids)
            {
                Configurations.Add(AssetDatabase.LoadAssetAtPath<PartTimePositionConfiguration>(AssetDatabase.GUIDToAssetPath(guid)));
            }

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }