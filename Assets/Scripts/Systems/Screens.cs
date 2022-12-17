using System;
using System.Linq;
using Components;
using Components.Events;
using Components.Screen;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Screens;
using Screens.CharacterScreen;
using Screens.StartScreen;
using Settings;
using UnityEngine;
using Object = System.Object;
using Screen = Screens.Screen;

namespace Systems
{
    public class Screens : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<ChangeScreenAnimation> _animationFilter;
        private EcsFilter<ScreenComponent> _screenFilter;
        private EcsFilter<Components.Events.NavigationPointChanged> _navChangingFilter;
        private EcsFilter<ChoicesChanged>.Exclude<Components.NpcCommunication> _dialogChangesFilter;

        private PrefabSet _prefabSet;

        public void Init()
        {
            EventSystem.Subscribe<LoadingScreen_Click>(OnLoadingScreenClick);
            EventSystem.Subscribe<StartScreen_NewCharacterClick>(OnStartScreenNewCharacterClick);
            EventSystem.Subscribe<StartScreen_CharacterChoose>(OnStartScreenCharacterChooseClick);
            
            _world.NewEntity().Replace(new ChangeScreenAnimation
            {
                PrefabToShow = GetScreenPrefab<LoadingScreen>(),
                TransitionType = TransitionType.In
            });
        }
        
        public void Destroy()
        {
            EventSystem.Unsubscribe<LoadingScreen_Click>(OnLoadingScreenClick);
            EventSystem.Unsubscribe<StartScreen_NewCharacterClick>(OnStartScreenNewCharacterClick);
            EventSystem.Unsubscribe<StartScreen_CharacterChoose>(OnStartScreenCharacterChooseClick);
        }
        
        public void Run()
        {
            if (!_animationFilter.IsEmpty())
                return;
            
            if (_navChangingFilter.GetEntitiesCount() > 1)
            {
                Debug.LogWarning("Multiple navigation changing in one frame.");
            }
            
            foreach (var i in _navChangingFilter)
            {
                if (_screenFilter.GetEntitiesCount() > 1)
                {
                    Debug.LogWarning("Multiple active screens on navigation changing");
                }
                
                ScreenViewBase targetScreen;
                var e = _navChangingFilter.Get1(i);
                switch (e.TransitionType)
                {
                    case TransitionType.In:
                    {
                        targetScreen = GetInTransitionScreen(e.CurrentPoint.Type);
                        break;
                    }
                    case TransitionType.Out:
                    {
                        targetScreen = GetOutTransitionScreen(e.CurrentPoint.Type);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                _world.NewEntity().Replace(new ChangeScreenAnimation
                {
                    PrefabToShow = targetScreen,
                    TransitionType = e.TransitionType
                });
            }

            
            //todo нужно выпилить вместе с диалогами
            foreach (var i in _dialogChangesFilter)
            {
                var changes = _dialogChangesFilter.Get1(i);
                EventSystem.Send(new DialogCurrentChoices_Changed
                {
                    Message = changes.Message,
                    CurrentChoices = changes.ButtonChoices
                });
            }
        }

        private ScreenViewBase GetInTransitionScreen(NavigationElementType type)
        {
            switch (type)
            {
                case NavigationElementType.MainScreen:
                    return GetScreenPrefab<MainScreen>();
                case NavigationElementType.NpcScreen:
                case NavigationElementType.BeFriendInteraction:
                case NavigationElementType.AskMoneyInteraction:
                case NavigationElementType.ChatInteraction:
                case NavigationElementType.InsultInteraction:
                case NavigationElementType.CommunicationInteraction:
                case NavigationElementType.FightInteraction:
                case NavigationElementType.FlirtInteraction:
                case NavigationElementType.GiftInteraction:
                case NavigationElementType.UnFriendInteraction:
                case NavigationElementType.ComplimentInteraction:
                case NavigationElementType.DateInteraction:
                case NavigationElementType.AskOutInteraction:
                case NavigationElementType.SpendTimeInteraction:
                    return GetScreenPrefab<CharacterScreen>();
                default:
                    return GetScreenPrefab<global::Screens.ActionsScreen.ActionsScreen>();
            }
        }
        
        private ScreenViewBase GetOutTransitionScreen(NavigationElementType type)
        {
            switch (type)
            {
                case NavigationElementType.MainScreen:
                    return GetScreenPrefab<MainScreen>();
                case NavigationElementType.NpcScreen:
                    return GetScreenPrefab<CharacterScreen>();
                default:
                    return GetScreenPrefab<global::Screens.ActionsScreen.ActionsScreen>();
            }
        }
        
        private void OnLoadingScreenClick(LoadingScreen_Click e)
        {
            _world.NewEntity().Replace(new ChangeScreenAnimation
            {
                PrefabToShow = GetScreenPrefab<StartScreen>(),
                TransitionType = TransitionType.In
            });
        }
        
        private void OnStartScreenNewCharacterClick(StartScreen_NewCharacterClick e)
        {
            _world.NewEntity().Replace(new NavigationActivateBlock
            {
                BlockType = NavigationBlockType.Main
            });
        }
        
        private void OnStartScreenCharacterChooseClick(StartScreen_CharacterChoose e)
        {
            _world.NewEntity().Replace(new NavigationActivateBlock
            {
                BlockType = NavigationBlockType.Main
            });
        }
        
        private ScreenViewBase GetScreenPrefab<T>() where T : Screen
        {
            return _prefabSet.ScreenPrefabs
                .First(prefab => prefab.GetComponent<ScreenView<T>>() != null).GetComponent<ScreenView<T>>();
        }
    }
}