using System;

namespace Core
{
    [Serializable]
    public class Snapshot
    {
        public WorldDate WorldDate;
        public float Value;

        public Snapshot(WorldDate worldDate, float value)
        {
            WorldDate = worldDate;
            Value = value;
        }
    }
}