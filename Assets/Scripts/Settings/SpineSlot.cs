using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings
{
    [Serializable]
    public class SpineSlot
    {
        public string Name;
        public string Attachment;
        public string Region;
        public ColorGroup ColorGroup;

        [FormerlySerializedAs("UseChanges")] [Header("Region changes")]
        public bool IgnoreChanges;
        public Vector2 Offset = Vector2.zero;
        public float Scale = 1;
    }
}