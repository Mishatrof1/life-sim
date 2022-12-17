using Core;
using Modules.Navigation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

namespace Screens.ActionsScreen
{
    public class ActivityButton : MonoBehaviour
    {
        public TMP_Text Title;
        public TMP_Text EasyName;
        public TMP_Text Description;
        public TMP_Text CompanyType;
        public Toggle Toggle;
        public GameObject Lock;
        [Space]
        public AnimatedIcon AnimatedIcon;
        public Slider ProgressFill;
        
        public NavigationPoint NavigationPoint;
        public void Setup(NavigationPoint navigationPoint)
        {
            if (navigationPoint.Type == NavigationElementType.NpcScreen)
            {
                if (navigationPoint.Element is Npc npc)
                {
                    AnimatedIcon.Setup(npc);
                }
            }
            
            NavigationPoint = navigationPoint;
            var buttonData = NavigationPoint.Element.GetButtonData(NavigationPoint.Type);
            if (navigationPoint.Type != NavigationElementType.NpcScreen)
            {
                AnimatedIcon.SetIcon(buttonData.Icon);
            }
            Title.text = buttonData.Title;
            CompanyType.text = buttonData.CompanyType;

            if (Description != null)
            {
                Description.gameObject.SetActive(!string.IsNullOrEmpty(buttonData.Description));
                Description.text = buttonData.Description;
            }
            if (buttonData.EnableState)
            {
                GetComponent<Button>().interactable = false;
                GetComponent<Button>().targetGraphic.color = Color.gray ;
                Lock.SetActive(true);
            }
            if (buttonData.Progress != null)
            {
                ProgressFill.gameObject.SetActive(buttonData.Progress.HasValue);
                ProgressFill.value = buttonData.Progress ?? 0f;
                if (!buttonData.SpecifyProgressColor)
                    ProgressFill.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(ProgressFill.value);
                else
                    ProgressFill.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(buttonData.ProgressFillColorValue);
            }
            
            Toggle.gameObject.SetActive(buttonData.ToggleActive);
            if (Toggle.gameObject.activeSelf)
            {
                Toggle.isOn = buttonData.ToggleState;
            }
        }
        
        public void Refresh()
        {
            Setup(NavigationPoint);
        }

        public void OnClick()
        {
            if (Toggle.gameObject.activeSelf)
            {
                Toggle.isOn = !Toggle.isOn;
            }
            
            EventSystem.Send(new NavigationPointClick
            {
                Point = new NavigationPoint
                {
                    Element = NavigationPoint.Element,
                    Type = NavigationPoint.Type
                } 
            });
        }

    }
}