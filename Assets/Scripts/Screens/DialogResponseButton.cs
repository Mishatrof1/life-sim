using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class DialogResponseButton : MonoBehaviour
    {
        public int ChoiceIndex { get; private set; }
        
        public Button Button;
        public TMP_Text Title;
        
        private void Awake()
        {
            Button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            EventSystem.Send(new DialogChoiceButton_Click {ChoiceIndex = ChoiceIndex});
        }

        public void Setup(string title, int index)
        {
            Title.text = title;
            ChoiceIndex = index;
        }
    }
}