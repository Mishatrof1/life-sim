using System.Collections.Generic;
using Settings.Job.Simple;
using UnityEditor;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "OrganizationsSettings", menuName = "LifeSim/OrganizationsSettings", order = 0)]
    public class OrganizationsSettings : ScriptableObject
    {
        public List<OrganizationConfiguration> Configurations;
        
#if UNITY_EDITOR
        [ContextMenu("Setup")]
        public void Setup()
        {
            Configurations = new List<OrganizationConfiguration>();
            
            var guids = AssetDatabase.FindAssets("t:OrganizationConfiguration", new[] {"Assets/Settings/Organizations"});
            foreach (var guid in guids)
            {
                Configurations.Add(AssetDatabase.LoadAssetAtPath<OrganizationConfiguration>(AssetDatabase.GUIDToAssetPath(guid)));
            }
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}