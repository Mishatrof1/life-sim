using System;
using System.Collections.Generic;
using Core;
using UnityEngine.Serialization;

namespace Save
{
    [Serializable]
    public class PersonSave
    {
        public string Id;
        public int AvatarSpriteIndex;
        public WorldDate BirthDate;
        public int Birthday;
        public string BirthLocationId;
        public string FirstName;
        public string LastName;
        public Genders Gender;
        public List<ParameterSaveData> ParametersSave;
        public AppearanceSave AppearanceV2Save;
        public AccessoriesSave AccessoriesSave;
    }
    
    [Serializable]
    public class ParameterSaveData
    {
        public string Id;
        public float Value;
        public float Min;
        public float Max;

        public ParameterSaveData(string id, Parameter parameter)
        {
            Id = id;
            Min = parameter.Min;
            Max = parameter.Max;
            Value = parameter.Value;
        }
    }
}