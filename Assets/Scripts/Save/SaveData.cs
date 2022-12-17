using System;
using System.Linq;
using UnityEngine;

namespace Save
{
    public abstract class SaveData : ScriptableObject
    {
        public string InstanceId => GetType().FullName.Split('.').Last().Replace("SaveData", "");

        public abstract void ResetSaveData();

        public virtual void OnBeforeSerialize()
        {
            
        }

        public virtual void OnAfterDeserialize()
        {
            
        }
    }
}