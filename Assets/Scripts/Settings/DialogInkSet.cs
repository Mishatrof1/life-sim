using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(fileName = "DialogInkSet", menuName = "DialogInkSet")]
    public class DialogInkSet : ScriptableObject
    {
        public List<TextAsset> InkSets;
        public List<TextAsset> NotRequiredInkSets;
#if UNITY_EDITOR
        [ContextMenu("SetupSet")]
        public void SetupSet()
        {
            InkSets = new List<TextAsset>();

            var guids = AssetDatabase.FindAssets("t:TextAsset InkStory", new[] { "Assets/InkStories/InkSets" });
            foreach (var guid in guids)
            {
                InkSets.Add(AssetDatabase.LoadAssetAtPath<TextAsset>(AssetDatabase.GUIDToAssetPath(guid)));
            }

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
        [ContextMenu("SetupNotRequiredStories")]
        public void SetupSetRequiredInkSets()
        {
            NotRequiredInkSets = new List<TextAsset>();

            var guids = AssetDatabase.FindAssets("t:TextAsset", new[] {"Assets/InkStories/StoriesFromJSON"});
            foreach (var guid in guids)
            {
                NotRequiredInkSets.Add(AssetDatabase.LoadAssetAtPath<TextAsset>(AssetDatabase.GUIDToAssetPath(guid)));
            }

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }
} 