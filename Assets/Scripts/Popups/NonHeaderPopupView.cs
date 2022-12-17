using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
    public class NonHeaderPopupView : PopupView<NonHeaderPopup>
    {
        [SerializeField] private GameObject ActionsParent;
        [SerializeField] private GameObject BackParent;
        [SerializeField] private GameObject _dropdown;
        [SerializeField] private TMP_Dropdown _dropdownComp;
        [SerializeField] private TMP_Text HeaderText;
        [SerializeField] private TMP_Text ContentText;

        public string CurrentDropdownValue { get; private set; }

        private void Awake()
        {
            _dropdownComp.onValueChanged.AddListener(OnDropdownValueChanged);
        }

        public override void Setup(NonHeaderPopup settings)
        {
            HeaderText.text = settings.HeaderText;
            ContentText.text = settings.ContentText;
            if (settings.ActionsSettings != null)
            {
                foreach (var actionsSetting in settings.ActionsSettings)
                {
                    InstantiateActionButton(actionsSetting);
                }
            }
            _dropdown.SetActive(settings.DropdownSettings?.Count > 0);
            if (settings.DropdownSettings != null)
            {
                _dropdownComp.options.Clear();
                foreach (var setting in settings.DropdownSettings)
                {
                    _dropdownComp.options.Add(new TMP_Dropdown.OptionData(setting));
                }
                CurrentDropdownValue = _dropdownComp.options[0].text;
            }
        }

        private void InstantiateActionButton(ActionButtonSettings actionsSetting)
        {
            var actionButton = Instantiate(GameProcessingEcs.Instance.PrefabSet.ActionButtonPrefab, ActionsParent.transform, false);
            actionButton.GetComponent<ActionButton>().Title.text = actionsSetting.Title;
            actionButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                actionsSetting.Action?.Invoke();
                actionsSetting.ActionWithInstance?.Invoke(this);
            });
        }

        private void Close()
        {
            EventSystem.Send<Popup_Close>();
        }

        private void OnDropdownValueChanged(int value)
        {
            CurrentDropdownValue = _dropdownComp.options[value].text;
        }

    }
    
    public class NonHeaderPopup : Popup
    {
        public string HeaderText;
        public string ContentText;
        public List<ActionButtonSettings> ActionsSettings;
        public List<string> DropdownSettings;
    }

    public class ActionButtonSettings
    {
        public string Title;
        public Action Action;
        public Action<PopupViewBase> ActionWithInstance;
    }
}