using System;
using System.Collections.Generic;
using Modules.Navigation;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "NavigationSettings", menuName = "LifeSim/Navigation/Navigation settings", order = 0)]
    public class NavigationSettings : ScriptableObject
    {
        public List<NavigationSet> Sets;
    }

    [Serializable]
    public class NavigationSet
    {
        public NavigationBlockType BlockType;
        public NavigationElementsSet Set;
    }
}