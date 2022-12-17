using Modules.Navigation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.CharacterScreen
{
    public class CharacterButton : MonoBehaviour
    {
        public TMP_Text Name;
        public TMP_Text Description;
        public Image Icon;
        
        public NavigationPoint NavigationPoint;
        
        public void Setup(NavigationPoint navigationPoint)
        {
            NavigationPoint = navigationPoint;
            var buttonData = NavigationPoint.Element.GetButtonData(NavigationPoint.Type);
            
            Icon.overrideSprite = buttonData.Icon;
            Name.text = buttonData.Title;

            if (Description != null)
            {
                Description.gameObject.SetActive(!string.IsNullOrEmpty(buttonData.Description));
                Description.text = buttonData.Description;
            }
        }
        
        public void OnClick()
        {
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