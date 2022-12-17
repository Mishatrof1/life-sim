using System;
using System.Collections.Generic;
using Core;
using Screens;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

namespace Popups
{
    public class ProfilePopupView : PopupView<ProfilePopup>
    {
        [SerializeField] private TMP_Text NameText;
        [SerializeField] private TMP_Text StatusText;
        [SerializeField] private TMP_Text OccupationText;
        [SerializeField] private TMP_Text PartTimeJobText;
        [SerializeField] private TMP_Text MaterialStatusText;
        [SerializeField] private Slider HappinessSlider;
        [SerializeField] private Slider LooksSlider;
        [SerializeField] private Slider SmartSlider;
        [SerializeField] private Slider HealthSlider;
        [SerializeField] private Button CloseButton;
        [SerializeField] private AnimatedIcon FaceIcon;

        private void Awake()
        {
            CloseButton.onClick.AddListener(Close);
        }
        
        public override void Setup(ProfilePopup settings)
        {
            NameText.text = settings.NameText;
            StatusText.text = settings.StatusText;
            OccupationText.text = settings.OccupationText;
            PartTimeJobText.text = settings.PartTimeJobText;
            MaterialStatusText.text = settings.MaterialStatusText;

            HappinessSlider.value = settings.HappinessSliderValue;
            HappinessSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(HappinessSlider.value);
            LooksSlider.value = settings.LooksSliderValue;
            LooksSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(LooksSlider.value);
            SmartSlider.value = settings.SmartSliderValue;
            SmartSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(SmartSlider.value);
            HealthSlider.value = settings.HealthSliderValue;
            HealthSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(HealthSlider.value);

            FaceIcon.Setup(settings.Person);
        }
        private void Close()
        {
            EventSystem.Send<Popup_Close>();
        }
        
        private void OnDestroy()
        {
            CloseButton.onClick.RemoveListener(Close);
        }
    }
    
    public class ProfilePopup : Popup
    {
        public Person Person;
        public Genders Gender;
        public string NameText;
        public string StatusText;
        public string OccupationText;
        public string PartTimeJobText;
        public string MaterialStatusText;
        public float HappinessSliderValue;
        public float LooksSliderValue;
        public float SmartSliderValue;
        public float HealthSliderValue;
    }
}