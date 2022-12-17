using Components;
using Components.Events;
using Components.Screen;
using Leopotam.Ecs;
using Modules;
using Screens;
using UnityEngine;

namespace Systems
{
    public class Popups : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private EcsFilter<HideCurrentPopup> _closePopupRequestFilter;
        private EcsFilter<ShowPopup> _showPopupRequestFilter;
        private EcsFilter<ScreenComponent> _screenFilter;
        private EcsFilter<HideDarkBack> _hideDarkBackRequestFilter;
        private EcsFilter<Created, CharacterComponent> _characterCreatedFilter;

        private EcsFilter<Focus> _focusFilter;
        private EcsFilter<Pause> _pauseFilter;
        
        private PopupViewManager _popupViewManager;

        public void Run()
        {
            foreach (var i in _screenFilter)
            {
                if (_screenFilter.Get1(i).ScreenView.BlockPopups)
                    return;
            }

            if (!_closePopupRequestFilter.IsEmpty())
            {
                _popupViewManager.HideCurrent();
                if (_showPopupRequestFilter.IsEmpty())
                {
                    _world.NewEntity().Replace(new HideDarkBack());
                }
            }

            if (_popupViewManager.HasOpened)
                return;
            
            if (_showPopupRequestFilter.IsEmpty())
            {
                foreach (var i in _hideDarkBackRequestFilter)
                {
                    _popupViewManager.HideDarkBack();
                    _hideDarkBackRequestFilter.Destroy();
                    break;
                }
                return;
            }
                

            var showPopupRequest = new ShowPopup();
            foreach (var i in _showPopupRequestFilter)
            {
                var currentShowRequest = _showPopupRequestFilter.Get1(i);
                if (showPopupRequest.PopupToShow == null || currentShowRequest.Priority > showPopupRequest.Priority)
                {
                    showPopupRequest = currentShowRequest;
                }
            }
            showPopupRequest.PopupToShow.Show(_popupViewManager);
            foreach (var i in _showPopupRequestFilter)
            {
                if (ReferenceEquals(showPopupRequest.PopupToShow, _showPopupRequestFilter.Get1(i).PopupToShow))
                {
                    _showPopupRequestFilter.GetEntity(i).Destroy();
                }
            }
        }
    }
}