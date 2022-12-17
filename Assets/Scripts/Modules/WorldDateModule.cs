using System;
using Save;
using Systems.Job.Simple;

namespace Modules
{
    public class WorldDateModule
    {
        public static WorldDate CurrentDate { get; private set; }
        public static WorldDateMode Mode { get; private set; }

        public WorldDateModule() : this(WorldDate.FromMonths(0))
        { }
        
        public WorldDateModule(WorldDate startDate)
        {
            CurrentDate = startDate;
            Mode = WorldDateMode.FullYear;
        }
        
        public void NextIteration()
        {
            CurrentDate += Mode switch
            {
               
                WorldDateMode.FullYear => WorldDate.FromYears(1),
                WorldDateMode.HalfYear => WorldDate.FromMonths(WorldDate.MonthsInYear / 2),
                _ => throw new ArgumentOutOfRangeException()
            };
                  Military.instance.Upgrade();
          
        }

        public void Reset()
        {
            CurrentDate = WorldDate.FromMonths(0);
        }

        public void Restore(GlobalSaveData saveData)
        {
            CurrentDate = saveData.CurrentDate;
        }
    }

    public enum WorldDateMode
    {
        FullYear,
        HalfYear
    }
}