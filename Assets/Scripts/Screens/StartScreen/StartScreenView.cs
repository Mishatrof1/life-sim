using System.Collections.Generic;
using Systems;
using Core;
using Save;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.StartScreen
{
    public class StartScreenView : ScreenView<StartScreen>
    {
        public Image SoundBtn;
        public Sprite SoundOnSprite;
        public Sprite SoundOffSprite;
        public StartScreenCharacterButton ButtonPrefab;
        public GameObject CharInfoParent;

        public override bool BlockPopups => true;

        public void OnNewCharacterButton()
        {
            EventSystem.Send<StartScreen_NewCharacterClick>();
        }

        public void OnSoundButton()
        {
            EventSystem.Send<StartScreen_SoundClick>();
        }
    }

    public class StartScreen : Screen
    {
        
    }
}