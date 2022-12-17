using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class LoadingScreenView : ScreenView<LoadingScreen>
    {
        public override bool BlockPopups => true;

        public void OnClick()
        {
            EventSystem.Send<LoadingScreen_Click>();
        }
    }

    public class LoadingScreen : Screen
    {
        
    }
}