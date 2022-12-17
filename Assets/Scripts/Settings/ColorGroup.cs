using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "ColorGroup", menuName = "LifeSim/Color group", order = 0)]
    public class ColorGroup : ScriptableObject
    {
        public static string DefaultGroupName = "Default";
        
        public List<Color> Colors;
    }
}