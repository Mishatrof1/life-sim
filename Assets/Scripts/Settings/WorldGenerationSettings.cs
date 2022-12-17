using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "WorldGenerationSettings", menuName = "WorldGenerationSettings", order = 0)]
    public class WorldGenerationSettings : ScriptableObject
    {
        public TextAsset NameSetTable;
        public List<Sprite> Avatars;
    }
}