using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Components.Screen;
using Leopotam.Ecs;
using Modules.Navigation;
using Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class MainScreenView : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem, INavigationElement
    {
        private EcsWorld _world;
        private EcsFilter<ScreenComponent> _screenFilter;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navBlockFilter;
        private EcsFilter<BlockComponent, Active> _navActiveBlockFilter;
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
        private EcsFilter<OccupationChanged> _occupationChangedFilter;

        private NavigationPoint _occupationNavPoint;
        private NavigationPoint _assetsNavPoint;
        private NavigationPoint _relationshipNavPoint;
        private NavigationPoint _activityNavPoint;

        private EcsFilter<AppearanceChanged> _appearanceChangingFilter;

        public void Init()
        {
            _navBlockFilter.RegisterElement(NavigationBlockType.Main, this);
            
            EventSystem.Subscribe<MainScreen_OccupationButtonCLick>(OnMainScreenOccupationButtonCLick);
            EventSystem.Subscribe<MainScreen_ActivityButtonClick>(OnMainScreenActivityButtonClick);
            EventSystem.Subscribe<MainScreen_ProfileButtonClick>(OnMainScreenProfileButtonClick);
            EventSystem.Subscribe<MainScreen_AgeButtonClick>(OnMainScreenAgeButtonClick);
            EventSystem.Subscribe<MainScreen_AssetsButtonClick>(OnMainScreenAssetsButtonClick);
            EventSystem.Subscribe<MainScreen_SocialButtonClick>(OnMainScreenSocialButtonClick);
            EventSystem.Subscribe<MainScreen_MenuButtonClick>(OnMainScreenMenuButtonClick);
        }

        public void Destroy()
        {
            EventSystem.Unsubscribe<MainScreen_OccupationButtonCLick>(OnMainScreenOccupationButtonCLick);
            EventSystem.Unsubscribe<MainScreen_ActivityButtonClick>(OnMainScreenActivityButtonClick);
            EventSystem.Unsubscribe<MainScreen_ProfileButtonClick>(OnMainScreenProfileButtonClick);
            EventSystem.Unsubscribe<MainScreen_AgeButtonClick>(OnMainScreenAgeButtonClick);
            EventSystem.Unsubscribe<MainScreen_AssetsButtonClick>(OnMainScreenAssetsButtonClick);
            EventSystem.Unsubscribe<MainScreen_SocialButtonClick>(OnMainScreenSocialButtonClick);
            EventSystem.Unsubscribe<MainScreen_MenuButtonClick>(OnMainScreenMenuButtonClick);
        }
        
        public void Run()
        {
            if (_characterFilter.IsEmpty())
                return;
            
            foreach (var i in _screenFilter)
            {
                ref var screenViewComp = ref _screenFilter.Get1(i);
                if (!(screenViewComp.ScreenView is global::Screens.MainScreenView mainScreenView))
                    continue;

                if (!screenViewComp.Initialized)
                {
                    screenViewComp.Initialized = true;
                
                    UpdateView(mainScreenView);

                    foreach (var j in _characterFilter)
                    {
                        var character = _characterFilter.Get1(j).Character;
                        mainScreenView.FaceIcon.Setup(character);
                    }
                    
                    var height = UnityEngine.Screen.height - UnityEngine.Screen.safeArea.y - UnityEngine.Screen.safeArea.height;
                    mainScreenView.InactivePanel.GetComponent<LayoutElement>().minHeight = height;
                }
                
                if (!_nextIterationFilter.IsEmpty() || !_occupationChangedFilter.IsEmpty())
                {
                    UpdateView(mainScreenView);
                }

                foreach (var j in _appearanceChangingFilter)
                {
                    var person = _appearanceChangingFilter.Get1(j).Person;

                    if (person is Core.Character)
                    {
                        mainScreenView.FaceIcon.Setup(person);
                        break;
                    }

                }

            }

        }

        private void UpdateView(global::Screens.MainScreenView mainScreenView)
        {
            var navPoints = _navActiveBlockFilter.GetPointsToDisplay();
            _occupationNavPoint = navPoints.FirstOrDefault(p => p.Type == NavigationElementType.OccupationScreen) ??
                                  navPoints.FirstOrDefault(p => p.Type == NavigationElementType.CurrentOccupationScreen);
            _assetsNavPoint = navPoints.FirstOrDefault(p => p.Type == NavigationElementType.AssetsScreen);
            _relationshipNavPoint = navPoints.FirstOrDefault(p => p.Type == NavigationElementType.RelationshipsScreen);
            _activityNavPoint = navPoints.FirstOrDefault(p => p.Type == NavigationElementType.ActivitiesScreen);

            mainScreenView.OccupationButton.interactable = _occupationNavPoint != null;
            mainScreenView.AssetsButton.interactable = _assetsNavPoint != null;
            mainScreenView.RelationshipButton.interactable = _relationshipNavPoint != null;
            mainScreenView.ActivityButton.interactable = _activityNavPoint != null;
            
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;

                mainScreenView.FullNameTxt.text = character.FullName;
                mainScreenView.AgeTxt.text = $"{LocalizationDictionary.GetLocalizedString("parametr_age")}: {character.Age.TotalYears.ToString()}";
                mainScreenView.BankBalanceTxt.text = character.Parameters
                    .Get(ParameterType.Balance.ToString()).Value.ToMoneyString();
                mainScreenView.LocationTxt.text = character.CurrentLocation.ToString();
                mainScreenView.FullStoryLogTxt.text = character.AgeLog?.AsString(character);

                mainScreenView.HappinessFill.value = character.Parameters.Get(ParameterType.Happiness.ToString()).NormalizedValue;
                mainScreenView.HappinessFill.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(mainScreenView.HappinessFill.value);
                mainScreenView.LooksFill.value = character.Parameters.Get(ParameterType.Looks.ToString()).NormalizedValue;
                mainScreenView.LooksFill.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(mainScreenView.LooksFill.value);
                mainScreenView.SmartFill.value = character.Parameters.Get(ParameterType.Smarts.ToString()).NormalizedValue;
                mainScreenView.SmartFill.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(mainScreenView.SmartFill.value);
                mainScreenView.HealthFill.value = character.Parameters.Get(ParameterType.Health.ToString()).NormalizedValue;
                mainScreenView.HealthFill.fillRect.GetComponent<Image>().color = ScreenUtils.SetSliderColor(mainScreenView.HealthFill.value);
                
                if (character.Age.TotalYears > 4 &&
                    character.Age.TotalYears < 18 &&
                    mainScreenView.OccupationButtonImage.sprite != mainScreenView.OccupationSchool)
                {
                    mainScreenView.OccupationButtonImage.sprite = mainScreenView.OccupationSchool;
                }

                if (character.Age.TotalYears >= 18 &&
                    mainScreenView.OccupationButtonImage.sprite != mainScreenView.OccupationWork)
                {
                    mainScreenView.OccupationButtonImage.sprite = mainScreenView.OccupationWork;
                }

                
            }
        }
        
        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.MainScreen,
            NavigationElementType.OccupationScreen,
            NavigationElementType.AssetsScreen,
            NavigationElementType.RelationshipsScreen,
            NavigationElementType.ActivitiesScreen
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return Types.Contains(elementType);
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
            switch (elementType)
            {
                case NavigationElementType.OccupationScreen:
                {
                    var currentPoint = _navActiveBlockFilter.GetCurrentPoint(NavigationBlockType.Main);
                    if (currentPoint.Type != NavigationElementType.MainScreen)
                        return false;
                    
                    foreach (var i in _characterFilter)
                    {
                        var character = _characterFilter.Get1(i).Character;
                        if (character.CurrentOccupation == null)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                case NavigationElementType.MainScreen:
                case NavigationElementType.AssetsScreen:
                case NavigationElementType.RelationshipsScreen:
                case NavigationElementType.ActivitiesScreen:
                    return true;
                default:
                    return false;
            }
        }

        public bool OnClick(NavigationElementType elementType)
        {
            return true;
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            return _navBlockFilter.GetDefaultButtonData(NavigationBlockType.Main, elementType);
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            return _navBlockFilter.GetDefaultScreenData(NavigationBlockType.Main, elementType);
        }
        
        private void OnMainScreenOccupationButtonCLick(MainScreen_OccupationButtonCLick e)
        {
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                if (character.Age.TotalYears < 5)
                {
                    _characterFilter.GetEntity(i).Replace(new ShowProfile());
                }
                else
                {
                    _world.NewEntity().Replace(new Components.Events.NavigationPointClick
                    {
                        NavigationPoint = new NavigationPoint
                        {
                            Type = _occupationNavPoint.Type,
                            Element = _occupationNavPoint.Element
                        }
                    });
                }
            }
        }
        
        private void OnMainScreenActivityButtonClick(MainScreen_ActivityButtonClick e)
        {
            _world.NewEntity().Replace(new Components.Events.NavigationPointClick
            {
                NavigationPoint = new NavigationPoint
                {
                    Type = _activityNavPoint.Type,
                    Element = _activityNavPoint.Element
                }
            });
        }
        
        private void OnMainScreenAssetsButtonClick(MainScreen_AssetsButtonClick e)
        {
            _world.NewEntity().Replace(new Components.Events.NavigationPointClick
            {
                NavigationPoint = new NavigationPoint
                {
                    Type = _assetsNavPoint.Type,
                    Element = _assetsNavPoint.Element
                }
            });
        }
        
        private void OnMainScreenSocialButtonClick(MainScreen_SocialButtonClick e)
        {
            _world.NewEntity().Replace(new Components.Events.NavigationPointClick
            {
                NavigationPoint = new NavigationPoint
                {
                    Type = _relationshipNavPoint.Type,
                    Element = _relationshipNavPoint.Element
                }
            });
        }
        
        private void OnMainScreenMenuButtonClick(MainScreen_MenuButtonClick e)
        {
            _world.NewEntity().Replace(new NavigationActivateBlock
            {
                BlockType = NavigationBlockType.Menu
            });
        }
        
        private void OnMainScreenProfileButtonClick(MainScreen_ProfileButtonClick e)
        {
            foreach (var i in _characterFilter)
            {
                _characterFilter.GetEntity(i).Replace(new ShowProfile());
            }
        }
        
        private void OnMainScreenAgeButtonClick(MainScreen_AgeButtonClick e)
        {
            _world.NewEntity().Replace(new NextWorldDateIteration());
        }
    }
}