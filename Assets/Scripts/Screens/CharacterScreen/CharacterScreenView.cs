using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.CharacterScreen
{
    public class CharacterScreenView : ScreenView<CharacterScreen> 
    {  
        public Npc Npc;
        public Transform DialogPanel;
        public Transform ButtonParent;
        public Transform Bubble;
        public Transform DialogButtonParent;
        public RectTransform InactivePanel;
        public GameObject DropDownListGo;
        public GameObject InputFieldGo;
        public GameObject SliderGo;
        public Slider RelationshipSlider;
        public Slider LooksSlider;
        public Slider SmartSlider;
        public Slider HappinessSlider;
        public Slider SympathySlider;
        public Slider MoneySlider;
        public TMP_Text NameTxt;
        public TMP_Text StatusTxt;
        public TMP_Text InfoTxt;
        public TMP_Text BubbleTxt;
        public TMP_Text DialogButtonsTitle;
        public TMP_Dropdown DropDownComp;
        public TMP_InputField InputFieldComp;
        public Slider InputSliderComp;
        public Sprite IconNotAvailable;

        public AnimatedIcon AnimatedIcon;

        private void Awake()
        {
            DropDownComp.onValueChanged.AddListener(OnDropdownValueChanged);
            InputFieldComp.onValueChanged.AddListener(OnInputValueChanged);
            InputSliderComp.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnDestroy()
        {
            DropDownComp.onValueChanged.RemoveListener(OnDropdownValueChanged);
            InputFieldComp.onValueChanged.RemoveListener(OnInputValueChanged);
            InputSliderComp.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        public void OnEmotionButton()
        {
            EventSystem.Send<CharacterScreen_EmptionButtonClick>();
        }
        
        private void OnDropdownValueChanged(int value)
        {
            EventSystem.Send(new CharacterScreen_DropDownValueChanged
            {
                Value = value
            });
        }

        private void OnInputValueChanged(string value)
        {
            int numValue = 0;
            if (!int.TryParse(value, out numValue)) return;

            if (numValue > InputSliderComp.maxValue) InputSliderComp.maxValue = numValue;
            InputSliderComp.value = numValue;
        }

        private void OnSliderValueChanged(float value)
        {
            int numValue = (int)value;
            InputFieldComp.text = numValue.ToString();
            EventSystem.Send(new CharacterScreen_InputValueChanged
            {
                Value = numValue
            });
        }
        
        public void OnBackButton()
        {
            EventSystem.Send<CharacterScreen_BackButtonClick>();
        }
        
        public void OnHomeButton()
        {
            EventSystem.Send<CharacterScreen_HomeButtonClick>();
        }
    }

    public class CharacterScreen : Screen
    {
    }
}