using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu]
    public class ReactionsSettings : ScriptableObject
    {
        public List<ReactionsPool> ReactionsPools;
    }

    [Serializable]
    public class ReactionsPool
    {
        public double Min;
        public double Max;
        public List<string> Reactions;
    }
}