using System;
using System.Collections.Generic;
using Core.Job;
using UnityEngine;

namespace Save
{
    [CreateAssetMenu]
    public class OrganizationsSaveData : SaveData
    {
        public List<Organization> Organizations;
        
        public override void ResetSaveData()
        {
            Organizations = new List<Organization>();
        }
    }

    [Serializable]
    public class Organization
    {
        public string Id;
        public string Name;
        public OrganizationType Type;
        public ScopeType ScopeType;
        public string LocationId;
        public float DislikeFactor;
        public float TargetDislikeFactor;
    }
}