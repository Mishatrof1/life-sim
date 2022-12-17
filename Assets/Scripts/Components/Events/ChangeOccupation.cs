using Core;

namespace Components.Events
{
    public struct ChangeOccupation
    {
        public MainOccupation Service;
    }
    
    public struct ChangePartTimeOccupation
    {
        public PartTimeOccupations Service;
    }
}