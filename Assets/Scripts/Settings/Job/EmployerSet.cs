using System;
using System.Collections.Generic;
using Core;
using Core.Job;
using UnityEngine;

namespace Settings.Job
{
    [CreateAssetMenu(fileName = "EmployerSet", menuName = "LifeSim/Job/Employer set")]
    public class EmployerSet : ScriptableObject
    {
        public List<Employer> Employers;
    }

    [Serializable]
    public class Employer
    {
        public string Title;
        public OrganizationType EmployerType;
        public Range WealthIndexRange;
        public Range StabilityIndexRange;
        public int MinCountForLocation;
    }
}