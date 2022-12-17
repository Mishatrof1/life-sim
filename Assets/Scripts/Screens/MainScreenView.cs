using Save;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Screens.MainScreenView;

namespace Screens
{
    public class MainScreenView : ScreenView<MainScreen>
    {
        [SerializeField] private SaveDataProvider _saveDataProvider;

        public TMP_Text FullStoryLogTxt;
        public TMP_Text FullNameTxt;
        public TMP_Text AgeTxt;
        public TMP_Text LocationTxt;
        public TMP_Text BankBalanceTxt;

        public Image OccupationButtonImage;
        public Slider HappinessFill;
        public Slider LooksFill;
        public Slider SmartFill;
        public Slider HealthFill;
        public RectTransform InactivePanel;

        public Sprite OccupationSchool;
        public Sprite OccupationWork;

        public Button OccupationButton;
        public Button AssetsButton;
        public Button RelationshipButton;
        public Button ActivityButton;

        public AnimatedIcon FaceIcon;

        public void OnOccupationButtonCLick()
        {
            EventSystem.Send<MainScreen_OccupationButtonCLick>();
        }

        public void OnActivityButtonClick()
        {
            EventSystem.Send<MainScreen_ActivityButtonClick>();
        }

        public void OnProfileButtonClick()
        {
            EventSystem.Send<MainScreen_ProfileButtonClick>();
        }

        public void OnAgeButtonClick()
        {
            EventSystem.Send<MainScreen_AgeButtonClick>();
        }

        public void OnAssetsButtonClick()
        {
            EventSystem.Send<MainScreen_AssetsButtonClick>();
        }

        public void OnSocialButtonClick()
        {
            EventSystem.Send<MainScreen_SocialButtonClick>();
        }

        public void OnMenuButtonClick()
        {
            EventSystem.Send<MainScreen_MenuButtonClick>();
        }
    }
    
    public class MainScreen : Screen
    {
    }
}