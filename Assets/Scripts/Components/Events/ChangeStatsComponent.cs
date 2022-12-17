using System.Collections.Generic;

namespace Components.Events
{
    public struct ChangeStatsComponent
    {
        public List<ChangeStats> ChangeStats;
    }

    public class ChangeStats
    {
        public string ParameterId;
        public float Value;
    }
}