using Modules.Navigation;

namespace Components.Events
{
    public struct NavigationPointChanged
    {
        public NavigationPoint PreviousPoint { get; set; }
        public NavigationPoint CurrentPoint { get; set; }
        public TransitionType TransitionType { get; set; }
    }
}