using Modules.Navigation;
using Screens;

namespace Components.Screen
{
    public struct ChangeScreenAnimation
    {
        public ScreenViewBase PrefabToShow { get; set; }
        public TransitionType TransitionType { get; set; }
        public bool InProgress { get; set; }
    }
}