using System;
using System.Collections.Generic;
using System.Linq;
using Settings.NpcCommunication;

namespace Core
{
    [Serializable]
    public class FlirtProgress
    {
        public int PersistenceSum;
        public int Count;
        public int FlirtResult;
        public WorldDate? LastFlirtWorldDate;
        public WorldDate FlirtResultWorldDate;
        public List<Date> CompletedDates;
        public List<Date> Dates;
        public int AskOutResult;

        public FlirtProgress()
        {
            Reset();
        }
        
        public void Reset()
        {
            PersistenceSum = 0;
            Count = 0;
            FlirtResult = 0;
            FlirtResultWorldDate = default;
            LastFlirtWorldDate = default;
            CompletedDates = new List<Date>();
            Dates = new List<Date>();
            AskOutResult = 0;
        }

        public void SetAvailableDates(DateSettings settings)
        {
            var allDates = settings.Communications;
            var cycleCount = 0;
            while (!(Dates.Count == settings.IntermediatePoolSize || cycleCount++ == 1000))
            {
                var dateIndex = UnityEngine.Random.Range(0, allDates.Count);
                if (Dates.All(d => d.Index != dateIndex))
                {
                    Dates.Add(new Date
                    {
                        Index = dateIndex
                    });
                }
            }

            var successfulIndex = UnityEngine.Random.Range(0, Dates.Count);
            Dates[successfulIndex].IsSuccessful = true;
        }
    }

    [Serializable]
    public class Date
    {
        public int Index;
        public bool IsSuccessful;
    }
}