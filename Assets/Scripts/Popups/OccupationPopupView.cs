using System;
using System.Collections.Generic;
using Screens;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
    public class OccupationPopupView : PopupView<OccupationPopup>
    {
        [SerializeField] private TMP_Text HeaderText;
        [SerializeField] private TMP_Text OrganizationNameText;
        [SerializeField] private TMP_Text JobPositionText;
        [SerializeField] private TMP_Text JobYearsInCompanyText;
        [SerializeField] private TMP_Text JobYearsForPensionText;
        [SerializeField] private TMP_Text JobSalaryText;
        [SerializeField] private TMP_Text SchoolYearsLeftText;
        [SerializeField] private TMP_Text GradeSliderTitle;
        [SerializeField] private Transform SchoolFrame;
        [SerializeField] private Transform JobFrame;
        [SerializeField] private Slider GradesSlider;
        [SerializeField] private Slider PopularitySlider;
        [SerializeField] private Image OrganizationIcon;
        [SerializeField] private Sprite SchoolIcon;
        [SerializeField] private Sprite WorkIcon;
        [SerializeField] private Button CloseButton;
        
        private void Awake()
        {
            CloseButton.onClick.AddListener(Close);
        }
        
        public override void Setup(OccupationPopup settings)
        {
            if (settings.OrganizationIcon)
            {
                OrganizationIcon.sprite = settings.OrganizationIcon;
            }
            
            OrganizationNameText.text = settings.OrganizationNameText;

            GradesSlider.value = settings.GradesSliderValue;
            GradesSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(GradesSlider.value);
            PopularitySlider.value = settings.PopularitySliderValue;
            PopularitySlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(PopularitySlider.value);
            
            if (settings.IsSchool)
            {
                HeaderText.text = LocalizationDictionary.GetLocalizedString("occupation_school");
                SchoolFrame.gameObject.SetActive(true);
                JobFrame.gameObject.SetActive(false);
                GradeSliderTitle.text = LocalizationDictionary.GetLocalizedString("occupation_grades");
                SchoolYearsLeftText.text = settings.SchoolYearsLeftText;
                OrganizationIcon.sprite = SchoolIcon;
            }
            else
            {
                HeaderText.text = LocalizationDictionary.GetLocalizedString("occupation_job");
                SchoolFrame.gameObject.SetActive(false);
                JobFrame.gameObject.SetActive(true);
                GradeSliderTitle.text = LocalizationDictionary.GetLocalizedString("occupation_productivity");
                JobPositionText.text = settings.JobPositionText;
                JobYearsInCompanyText.text = settings.JobYearsInCompanyText;
                JobYearsForPensionText.text = settings.JobYearsForPensionText;
                JobSalaryText.text = settings.JobSalaryText;
                OrganizationIcon.sprite = WorkIcon;
            }
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
    
    public class OccupationPopup : Popup
    {
        public bool IsSchool;
        public string OrganizationNameText;
        public string SchoolYearsLeftText;
        public string JobPositionText;
        public string JobYearsInCompanyText;
        public string JobYearsForPensionText;
        public string JobSalaryText;
        public float GradesSliderValue;
        public float PopularitySliderValue;
        public Sprite OrganizationIcon;
    }
}