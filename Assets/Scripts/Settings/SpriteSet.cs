using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "SpriteSet", menuName = "SpriteSet", order = 0)]
    public class SpriteSet : ScriptableObject
    {
        private Dictionary<string, Sprite> SpriteDict;
        public List<Sprite> SpriteList;
        
    #if UNITY_EDITOR
        [ContextMenu("SetupSet")]
        public void SetupSet()
        {
            SpriteList = new List<Sprite>();
            
            var guids = AssetDatabase.FindAssets("t:Sprite", new[] {"Assets"});
            foreach (var guid in guids)
            {
                SpriteList.Add(AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GUIDToAssetPath(guid)));
            }
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
    #endif

        public int GetSpriteIndex(Sprite sprite)
        {
            for (var i = 0; i < SpriteList.Count; i++)
            {
                if (SpriteList[i] == sprite)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}