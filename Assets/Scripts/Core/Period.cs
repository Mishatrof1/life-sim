using Modules;

namespace Core
{
    public class Period
    {
        public WorldDate StartDate;
        public WorldDate EndDate;
        
        public WorldDate Duration => StartDate.TotalMonths < EndDate.TotalMonths
            ? EndDate - StartDate
            : WorldDateModule.CurrentDate - StartDate;
    }
}