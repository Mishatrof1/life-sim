using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Components.Screen;
using Core;
using Core.NpcCommunication;
using DialogSystem;
using Leopotam.Ecs;
using Modules.Navigation;
using Screens;
using Screens.CharacterScreen;
using Settings;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace Systems
{
    public class CharacterScreenView : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<ScreenComponent> _screenFilter;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent, Active> _navActiveBlockFilter;
        private EcsFilter<Components.NpcCommunication, ChoicesChanged> _communicationFilter;
        private EcsFilter<Components.Events.NavigationPointChanged> _navChangingFilter;

        private PrefabSet _prefabSet;
        
        private CharacterScreenMode _mode;
        private List<GameObject> _activityButtonInstances;
        private List<GameObject> _dialogButtonInstances;
        private List<CommunicationChoice> _dropListValues;
        
        public void Init()
        {
            EventSystem.Subscribe<CharacterScreen_BackButtonClick>(OnCharacterScreenBackButton);
            EventSystem.Subscribe<CharacterScreen_HomeButtonClick>(OnCharacterScreenHomeButton);
            EventSystem.Subscribe<CharacterScreen_HomeButtonClick>(OnCharacterScreenHomeButton);
            EventSystem.Subscribe<ParametersChanged>(OnParametersChanged);
            EventSystem.Subscribe<BubbleTextComponent>(ChangeBubbleText);
            EventSystem.Subscribe<CharacterScreen_EmptionButtonClick>(OnEmotionButton);
        }

        public void Destroy()
        {
            EventSystem.Unsubscribe<CharacterScreen_BackButtonClick>(OnCharacterScreenBackButton);
            EventSystem.Unsubscribe<CharacterScreen_HomeButtonClick>(OnCharacterScreenHomeButton);
            EventSystem.Unsubscribe<CharacterScreen_HomeButtonClick>(OnCharacterScreenHomeButton);
            EventSystem.Unsubscribe<ParametersChanged>(OnParametersChanged);
            EventSystem.Unsubscribe<BubbleTextComponent>(ChangeBubbleText);
            EventSystem.Unsubscribe<CharacterScreen_EmptionButtonClick>(OnEmotionButton);
        }
        
        public void Run()
        {
            if (_characterFilter.IsEmpty())
                return;

            var currentPoint = _navActiveBlockFilter.GetCurrentPoint();
            var npc = _navActiveBlockFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            if (npc == null)
                return;
            
            foreach (var i in _screenFilter)
            {
                ref var screenViewComp = ref _screenFilter.Get1(i);
                if (!(screenViewComp.ScreenView is global::Screens.CharacterScreen.CharacterScreenView characterScreenView))
                    continue;

                _mode = currentPoint.Type == NavigationElementType.NpcScreen
                    ? CharacterScreenMode.Activities
                    : CharacterScreenMode.Dialog;
                
                CheckDialogChoicesChanged(characterScreenView);

                if (!screenViewComp.Initialized)
                {
                    screenViewComp.Initialized = true;

                    var height = UnityEngine.Screen.height - UnityEngine.Screen.safeArea.y - UnityEngine.Screen.safeArea.height;
                    characterScreenView.InactivePanel.GetComponent<LayoutElement>().minHeight = height;

                    UpdateView(characterScreenView, currentPoint, npc);
                }
                
                foreach (var navChangingIndex in _navChangingFilter)
                {
                    UpdateView(characterScreenView, currentPoint, npc);
                }
            }
        }

        private void UpdateView(global::Screens.CharacterScreen.CharacterScreenView characterScreenView, NavigationPoint currentPoint, Npc npc)
        {
            characterScreenView.ButtonParent.gameObject.SetActive(_mode == CharacterScreenMode.Activities);
            characterScreenView.DialogPanel.gameObject.SetActive(_mode == CharacterScreenMode.Dialog);
            
            if (currentPoint.Type == NavigationElementType.NpcScreen)
            {
                characterScreenView.BubbleTxt.text = RandomBubbleMessage();
            }
            
            var data = currentPoint.GetScreenData();
            characterScreenView.NameTxt.text = data.Title;
            characterScreenView.StatusTxt.text = data.Description;
            characterScreenView.InfoTxt.text = $"{npc.Age.TotalYears.ToString()} {LocalizationDictionary.GetLocalizedString("years_old")}, {npc.Gender.ToString()}";
            characterScreenView.RelationshipSlider.value = npc.Parameters.Get(ParameterType.Relationship.ToString()).NormalizedValue;
            characterScreenView.RelationshipSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(characterScreenView.RelationshipSlider.value);
            characterScreenView.LooksSlider.value = npc.Parameters.Get(ParameterType.Looks.ToString()).NormalizedValue;
            characterScreenView.LooksSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(characterScreenView.LooksSlider.value);
            characterScreenView.SmartSlider.value = npc.Parameters.Get(ParameterType.Smarts.ToString()).NormalizedValue;
            characterScreenView.SmartSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(characterScreenView.SmartSlider.value);
            characterScreenView.HappinessSlider.value = npc.Parameters.Get(ParameterType.Happiness.ToString()).NormalizedValue;
            characterScreenView.HappinessSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(characterScreenView.HappinessSlider.value);
            characterScreenView.SympathySlider.value = npc.Parameters.Get(ParameterType.Sympathy.ToString()).NormalizedValue;
            characterScreenView.SympathySlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(characterScreenView.SympathySlider.value);
            
            if (npc != null)
            {
                characterScreenView.AnimatedIcon.Setup(npc);
            }

            if (characterScreenView.ButtonParent.gameObject.activeSelf)
            {
                _activityButtonInstances ??= new List<GameObject>();
                _activityButtonInstances.ForEach(GameObject.Destroy);
                _activityButtonInstances.Clear();
                
                var points = _navActiveBlockFilter.GetPointsToDisplay();
                foreach (var point in points)
                {
                    if (npc.GrayButtons.Contains(point.Type))
                    {
                        InstantiateActivityButtonGray(point, characterScreenView.ButtonParent, characterScreenView.IconNotAvailable);
                    }
                    else
                    {
                        InstantiateActivityButton(point, characterScreenView.ButtonParent);
                    }
                }
            }
        }
        
        private string RandomBubbleMessage()
        {
            string text;
            switch (Random.Range(0,4))
            {
                case 0:
                    text = LocalizationDictionary.GetLocalizedString("communication_bubble_npc_0");
                    break;
                case 1:
                    text = LocalizationDictionary.GetLocalizedString("communication_bubble_npc_1");
                    break;
                case 2:
                    text = LocalizationDictionary.GetLocalizedString("communication_bubble_npc_2");
                    break;
                case 3:
                    text = LocalizationDictionary.GetLocalizedString("communication_bubble_npc_3");
                    break;
                default:
                    text = LocalizationDictionary.GetLocalizedString("communication_bubble_npc_4");
                    break;
            }

            return text;
        }
        
        private void InstantiateActivityButton(NavigationPoint navPoint, Transform parent)
        {
            var buttonPrefabType = ActivityButtonType.CharacterButton;
            var activityButtonPrefab = _prefabSet.ActivityButtonPrefabs
                .First(x => x.ButtonType == buttonPrefabType)
                .Prefab;
            var button = GameObject.Instantiate(activityButtonPrefab, parent, false).GetComponent<CharacterButton>();
            button.Setup(navPoint);
            _activityButtonInstances.Add(button.gameObject);
        }
        
        private void InstantiateActivityButtonGray(NavigationPoint navPoint, Transform parent, Sprite iconNotAvailable)
        {
            var buttonPrefabType = ActivityButtonType.CharacterButtonGray;
            var activityButtonPrefab = _prefabSet.ActivityButtonPrefabs
                .First(x => x.ButtonType == buttonPrefabType)
                .Prefab;
            var button = GameObject.Instantiate(activityButtonPrefab, parent, false).GetComponent<CharacterButton>();
            button.Icon.overrideSprite = iconNotAvailable;
            button.Setup(navPoint);
            _activityButtonInstances.Add(button.gameObject);
        }
        
        private void InstantiateDialogChoiceButton(string title, int index, Transform parent)
        {
            var dialogResponseButtonPrefab = _prefabSet.DialogResponseButton;
            var button = GameObject.Instantiate(dialogResponseButtonPrefab, parent, false).GetComponent<DialogResponseButton>();
            button.Setup(title, index);
            _dialogButtonInstances.Add(button.gameObject);
        }
        
        private void SetupDialogTitle(TMP_Text dialogButtonsTitle, string text)
        {
            dialogButtonsTitle.gameObject.SetActive(!string.IsNullOrEmpty(text));
            dialogButtonsTitle.text = text;
        }
        
        private void SetupDialogChoices(List<CommunicationChoice> choices, Transform parent)
        {
            _dialogButtonInstances ??= new List<GameObject>();
            _dialogButtonInstances.ForEach(GameObject.Destroy);
            _dialogButtonInstances.Clear();

            foreach (var choice in choices)
            {
                InstantiateDialogChoiceButton(choice.Text, choice.Index, parent);
            }
        }
        
        private void SetupDropListChoices(List<CommunicationChoice> choices, GameObject _dropDownListGo, TMP_Dropdown _dropDownComp)
        {
            _dropListValues ??= new List<CommunicationChoice>();
            _dropListValues.Clear();
            _dropListValues = choices;
            
            _dropDownListGo.SetActive(choices.Count > 0);
            if (_dropDownListGo.activeSelf)
            {
                _dropDownComp.ClearOptions();
                _dropDownComp.AddOptions(choices.Select(value => value.Text).ToList());
            }
        }
        
        private void SetupInputField(Components.NpcCommunication communication, GameObject _inputFieldGo, GameObject _sliderGo, TMP_InputField _inputFieldComp, Slider _sliderComp)
        {
            bool setupInputField = communication.Communication is AskMoneyCommunication && !communication.Final;
            _inputFieldGo.SetActive(setupInputField);
            _sliderGo.SetActive(setupInputField);

            if (setupInputField)
            {
                int maxSliderValue = ((AskMoneyCommunication)(communication.Communication)).DefaultSliderMaxValue;
                int value = ((AskMoneyCommunication)(communication.Communication)).DefaultAskingMoney;
                ((AskMoneyCommunication)(communication.Communication)).AskingMoney = value;
                _sliderComp.maxValue = maxSliderValue;
                _sliderComp.minValue = 1;
                _sliderComp.value = value;
            }
        }

        public void OnParametersChanged(ParametersChanged e)
        {
            if (e.Person is Npc npc)
            {
                foreach (var i in _screenFilter)
                {
                    ref var screenViewComp = ref _screenFilter.Get1(i);
                    if (!(screenViewComp.ScreenView is global::Screens.CharacterScreen.CharacterScreenView characterScreenView))
                        continue;

                    characterScreenView.RelationshipSlider.value = npc.Parameters.Get(ParameterType.Relationship.ToString()).NormalizedValue;
                    characterScreenView.RelationshipSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(characterScreenView.RelationshipSlider.value);
                    characterScreenView.LooksSlider.value = npc.Parameters.Get(ParameterType.Looks.ToString()).NormalizedValue;
                    characterScreenView.LooksSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(characterScreenView.LooksSlider.value);
                    characterScreenView.SmartSlider.value = npc.Parameters.Get(ParameterType.Smarts.ToString()).NormalizedValue;
                    characterScreenView.SmartSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(characterScreenView.SmartSlider.value);
                    characterScreenView.HappinessSlider.value = npc.Parameters.Get(ParameterType.Happiness.ToString()).NormalizedValue;
                    characterScreenView.HappinessSlider.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(characterScreenView.HappinessSlider.value);
                }
            }
        }
        
        private void ChangeBubbleText(BubbleTextComponent e)
        {
            if (e.BubbleTextValue == null) 
                return;

            foreach (var i in _screenFilter)
            {
                ref var screenViewComp = ref _screenFilter.Get1(i);
                if (!(screenViewComp.ScreenView is global::Screens.CharacterScreen.CharacterScreenView characterScreenView))
                    continue;

                characterScreenView.BubbleTxt.text = e.BubbleTextValue;
            }
        }

        private void CheckDialogChoicesChanged(global::Screens.CharacterScreen.CharacterScreenView characterScreenView)
        {
            foreach (var i in _communicationFilter)
            {
                var changes = _communicationFilter.Get2(i);
                var communication = _communicationFilter.Get1(i);
                SetupDialogTitle(characterScreenView.DialogButtonsTitle, changes.Message);
                SetupDialogChoices(changes.ButtonChoices ??= new List<CommunicationChoice>(), characterScreenView.DialogButtonParent);
                SetupDropListChoices(changes.DropListChoices ??= new List<CommunicationChoice>(), characterScreenView.DropDownListGo, characterScreenView.DropDownComp);
                SetupInputField(communication, characterScreenView.InputFieldGo, characterScreenView.SliderGo, characterScreenView.InputFieldComp, characterScreenView.InputSliderComp);
            }
        }

        private void OnCharacterScreenBackButton(CharacterScreen_BackButtonClick e)
        {
            _world.NewEntity().Replace(new NavigationBack());
        }
        
        private void OnCharacterScreenHomeButton(CharacterScreen_HomeButtonClick e)
        {
            _world.NewEntity().Replace(new NavigationHome());
        }

        public void OnEmotionButton(CharacterScreen_EmptionButtonClick e)
        {
            var npc = _navActiveBlockFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            foreach (var i in _screenFilter)
            {
                ref var screenViewComp = ref _screenFilter.Get1(i);
                if (!(screenViewComp.ScreenView is global::Screens.CharacterScreen.CharacterScreenView characterScreenView))
                    continue;

                characterScreenView.AnimatedIcon.FaceAnim.Setup(npc);
                characterScreenView.AnimatedIcon.FaceAnim.PlayNextAnimation();
            }
        }

    }
    
    public enum CharacterScreenMode
    {
        Activities,
        Dialog
    }
}