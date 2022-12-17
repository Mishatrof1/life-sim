using System.Collections.Generic;
using DialogSystem;
using UnityEditor;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu]
    public class DialogsSet : ScriptableObject
    {
        public List<DialogNodeGraph> DialogNodeGraphs;

#if UNITY_EDITOR
        [ContextMenu("SetupSet")]
        public void SetupSet()
        {
            DialogNodeGraphs = new List<DialogNodeGraph>();

            var guids = AssetDatabase.FindAssets("t:DialogNodeGraph", new[] { "Assets" });
            foreach (var guid in guids)
            {
                DialogNodeGraphs.Add(AssetDatabase.LoadAssetAtPath<DialogNodeGraph>(AssetDatabase.GUIDToAssetPath(guid)));
            }

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}