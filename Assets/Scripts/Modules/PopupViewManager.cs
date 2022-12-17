using System.Linq;
using Popups;
using UnityEngine;

namespace Modules
{
    public class PopupViewManager
    {
        private PopupViewBase _currentPopup;
        
        private readonly Transform _popupParent;

        public bool HasOpened => _currentPopup != null;

        private DarkBack _darkBack;
        
        public PopupViewManager(Transform popupParent)
        {
            _popupParent = popupParent;
        }

        public void ShowPopup<T>() where T : Popup
        {
            ShowPopup<T>(null);
        }
        
        public void ShowPopup<T>(T settings) where T : Popup
        {
            var popupPrefabs = GameProcessingEcs.Instance.PrefabSet.PopupPrefabs;
            var popupPrefab = popupPrefabs
                .First(prefab => prefab.GetComponent<PopupView<T>>() != null).GetComponent<PopupView<T>>();
            var instance = Object.Instantiate(popupPrefab, _popupParent, false);
            instance.Setup(settings);
            instance.Show();

            if (_darkBack == null)
            {
                _darkBack = Object.Instantiate(GameProcessingEcs.Instance.PrefabSet.PopupsDarkBack, _popupParent, false).GetComponent<DarkBack>();
                _darkBack.transform.SetSiblingIndex(0);
                _darkBack.Show();
            }
            if (_currentPopup != null)
            {
                _currentPopup.Hide();
                Object.Destroy(_currentPopup.gameObject);
            }
            

            _currentPopup = instance;
        }

        public void HideDarkBack()
        {
            if (_darkBack == null) return;

            var back = _darkBack;

            back.Hide(delegate {
                back.Destroy();
            });

            _darkBack = null;
        }

        public void HideCurrent()
        {
            if (_currentPopup != null)
            {
                _currentPopup.Hide();
                Object.Destroy(_currentPopup.gameObject);
            }
        }
    }
}