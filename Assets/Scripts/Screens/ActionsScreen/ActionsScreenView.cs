using System;
using System.Collections.Generic;
using System.Linq;
using Modules.Navigation;
using Settings;
using Settings.Job;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.ActionsScreen
{
    public class ActionsScreenView : ScreenView<ActionsScreen>
    {
        public Transform ActivityButtonsParent;
        public TMP_Text Title;
        public TMP_Text TitleDescription;
        public RectTransform InactivePanel;

        public void OnBackButton()
        {
            EventSystem.Send<ActionsScreen_BackButtonClick>();
        }
        public void OnHomeButton()
        {
            EventSystem.Send<ActionsScreen_HomeButtonClick>();
        }
    }
    
    public class ActionsScreen : Screen
    {
        
    }
}