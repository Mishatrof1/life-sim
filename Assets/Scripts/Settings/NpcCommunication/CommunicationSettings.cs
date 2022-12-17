using System;
using System.Collections.Generic;
using Components;
using Core;
using Core.NpcCommunication;
using UnityEngine;

namespace Settings.NpcCommunication
{
    [Serializable]
    public abstract class CommunicationSettings<T> : CommunicationSettings where T : CommunicationChoiceSettings
    {
        public abstract List<T> Communications { get; }

        public List<CommunicationChoice> SelectRandomChoices(int count, Npc npc)
        {
            var result = new List<CommunicationChoice>();
            var selectedIndexes = new HashSet<int>();
            var random = new System.Random(DateTime.Now.Millisecond);
            while (result.Count < count)
            {
                var index = random.Next(0, Communications.Count);
                if (selectedIndexes.Contains(index))
                    continue;

                selectedIndexes.Add(index);
                result.Add(new CommunicationChoice
                {
                    Index = index,
                    Text = Communications[index].GetActualText(npc)
                });
            }
            return result;
        }
    }
    
    public abstract class CommunicationSettings: ScriptableObject
    {
    }
}