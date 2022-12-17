using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "NavigationElementsSet", menuName = "LifeSim/Navigation/Navigation elements set", order = 0)]
    public class NavigationElementsSet : ScriptableObject
    {
        public List<NavigationElementSettings> NavigationElementsSettings;
        
#if UNITY_EDITOR
        [ContextMenu("SetupSet")]
        public void SetupSet()
        {
            NavigationElementsSettings = new List<NavigationElementSettings>();
            
            var guids = AssetDatabase.FindAssets("t:NavigationElementSettings", new[] {"Assets"});
            foreach (var guid in guids)
            {
                NavigationElementsSettings.Add(AssetDatabase.LoadAssetAtPath<NavigationElementSettings>(AssetDatabase.GUIDToAssetPath(guid)));
            }
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}