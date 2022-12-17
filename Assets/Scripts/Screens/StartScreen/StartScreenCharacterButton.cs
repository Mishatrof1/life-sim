using System;
using System.Linq;
using Modules;
using Save;
using TMPro;
using UnityEngine;

namespace Systems
{
    public class StartScreenCharacterButton : MonoBehaviour
    {
        public TMP_Text Name;
        public TMP_Text Description;
        public TMP_Text DateOfCreation;

        [Space]
        public AnimatedIcon FaceIcon;

        public void Setup(Core.Character character)
        {
            FaceIcon.Setup(character);
            
            Name.text = $"{character.FirstName} {character.LastName}";
            Description.text = $"{character.Gender.ToString()}, {(WorldDateModule.CurrentDate - character.BirthDate).TotalYears} {LocalizationDictionary.GetLocalizedString("years_old")}";
        }

        public void OnClick()
        {
            EventSystem.Send<StartScreen_CharacterChoose>();
        }
    }
}

