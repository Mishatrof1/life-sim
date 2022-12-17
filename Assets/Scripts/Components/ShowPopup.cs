using Modules;
using Popups;

namespace Components
{
    public struct ShowPopup
    {
        public PopupToShow PopupToShow;
        public int Priority;

        public ShowPopup(PopupToShow popupToShow, int priority)
        {
            PopupToShow = popupToShow;
            Priority = priority;
        }
    }
    
    public abstract class PopupToShow
    {
        public abstract void Show(PopupViewManager popupViewManager);
    }
    
    public class PopupToShow<T> : PopupToShow where T : Popup
    {
        private T _settings;
        
        public PopupToShow(T settings)
        {
            _settings = settings;
        }
        
        public override void Show(PopupViewManager popupViewManager)
        {
            popupViewManager.ShowPopup(_settings);
        }
    }
}