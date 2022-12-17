using System;
using System.IO;
using Settings.NpcCommunication;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Editor
{
    public class MaxFunTools : EditorWindow
    {
        [MenuItem("MaxFunTools/Parse gifts to settings")]
        private static void ParseGiftsToSettings()
        {
            var guids = AssetDatabase.FindAssets("t:GiftSettings", new[] { "Assets" });
            var settings = AssetDatabase.LoadAssetAtPath<GiftSettings>(AssetDatabase.GUIDToAssetPath(guids[0]));
            settings.Clear();
            
            using (var sr = new StreamReader(Path.Combine(Application.dataPath, "TextResources", "Gifts.txt")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    settings.Add(line, Random.Range(5f, 1000f), Random.Range(-5f, 10f));
                }
            }
            
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
        }
    }
}