using System;
using Components.Navigation;
using Components.Screen;
using Leopotam.Ecs;
using Modules.Navigation;
using Screens;
using UnityEngine;

namespace Systems
{
    public class ScreenTransitionAnimation : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<ScreenComponent> _screenFilter;
        private EcsFilter<ChangeScreenAnimation> _animationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;

        private Transform _blocker;
        private Transform _screenParent;
        
        public void Init()
        {
            _screenParent = GameObject.FindGameObjectWithTag("ScreenParent").transform;
            _blocker = GameObject.FindGameObjectWithTag("ScreenAnimationBlocker").transform;
            _blocker.gameObject.SetActive(false);
        }
        
        public void Run()
        {
            foreach (var i in _animationFilter)
            {
                ref var animComp = ref _animationFilter.Get1(i);
                if (animComp.InProgress)
                    return;
            }
            
            foreach (var i in _animationFilter)
            {
                ref var animComp = ref _animationFilter.Get1(i);
                if (!animComp.InProgress)
                {
                    animComp.InProgress = true;
                    _blocker.gameObject.SetActive(true);
                    
                    switch (animComp.TransitionType)
                    {
                        case TransitionType.In:
                            TransitionIn(ref animComp);
                            break;
                        case TransitionType.Out:
                            TransitionOut(ref animComp);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        private void TransitionIn(ref ChangeScreenAnimation changeScreenAnimation)
        {
            var currentPoint = _navigationActiveFilter.GetCurrentPoint();
            if (currentPoint != null)
            {
                switch (currentPoint.Type)
                {
                    case NavigationElementType.BeFriendInteraction:
                    case NavigationElementType.InsultInteraction:
                    case NavigationElementType.ChatInteraction:
                    case NavigationElementType.CommunicationInteraction:
                    case NavigationElementType.ComplimentInteraction:
                    case NavigationElementType.DateInteraction:
                    case NavigationElementType.FightInteraction:
                    case NavigationElementType.FlirtInteraction:
                    case NavigationElementType.GiftInteraction:
                    case NavigationElementType.SexInteraction:
                    case NavigationElementType.AskMoneyInteraction:
                    case NavigationElementType.AskOutInteraction:
                    case NavigationElementType.SpendTimeInteraction:
                    case NavigationElementType.UnFriendInteraction:
                    {
                        Clear();
                        return;
                    }
                }
            }

            var screenView = GameObject.Instantiate(changeScreenAnimation.PrefabToShow, _screenParent, false);
            _world.NewEntity().Replace(new ScreenComponent
            {
                ScreenView = screenView
            });

            if (screenView is LoadingScreenView)
            {
                OnShowAnimationComplete(screenView);
                return;
            }
            
            if (_screenFilter.HasScreenView<LoadingScreenView>())
            {
                OnShowAnimationComplete(screenView);
                return;
            }
            
            if (_screenFilter.HasScreenView<global::Screens.StartScreen.StartScreenView>())
            {
                screenView.transform.SetAsFirstSibling();
                foreach (var i in _screenFilter)
                {
                    var comp = _screenFilter.Get1(i);
                    if (comp.ScreenView.transform != screenView.transform)
                    {
                        comp.ScreenView.DoHideAnimation(Vector2.down, OnHideAnimationComplete);
                    }
                }
                return;
            }
            
            switch (screenView)
            {
                case global::Screens.ActionsScreen.ActionsScreenView asv:
                {
                    screenView.DoAppearAnimation(Vector2.up, OnShowAnimationComplete);
                    break;
                }
                default:
                {
                    screenView.DoAppearAnimation(Vector2.right, OnShowAnimationComplete);
                    break;
                }
            }
        }
        
        private void TransitionOut(ref ChangeScreenAnimation changeScreenAnimation)
        {
            var currentPoint = _navigationActiveFilter.GetCurrentPoint();
            if (currentPoint != null)
            {
                switch (currentPoint.Type)
                {
                    case NavigationElementType.NpcScreen:
                    {
                        Clear();
                        return;
                    }
                }
            }

            var screenView = GameObject.Instantiate(changeScreenAnimation.PrefabToShow, _screenParent, false);
            screenView.transform.SetAsFirstSibling();
            _world.NewEntity().Replace(new ScreenComponent
            {
                ScreenView = screenView
            });
            
            foreach (var i in _screenFilter)
            {
                var comp = _screenFilter.Get1(i);
                if (comp.ScreenView.transform != screenView.transform)
                {
                    comp.ScreenView.DoHideAnimation(Vector2.left, OnHideAnimationComplete);
                }
            }
        }
        
        private void OnShowAnimationComplete(ScreenViewBase sender)
        {
            foreach (var i in _screenFilter)
            {
                var comp = _screenFilter.Get1(i);
                if (comp.ScreenView.transform != sender.transform)
                {
                    _screenFilter.GetEntity(i).Destroy();
                    GameObject.Destroy(comp.ScreenView.gameObject);
                }
            }

            Clear();
        }
        
        private void OnHideAnimationComplete(ScreenViewBase sender)
        {
            foreach (var i in _screenFilter)
            {
                var comp = _screenFilter.Get1(i);
                if (comp.ScreenView.transform == sender.transform)
                {
                    _screenFilter.GetEntity(i).Destroy();
                    GameObject.Destroy(comp.ScreenView.gameObject);
                }
            }

            Clear();
        }

        private void Clear()
        {
            foreach (var i in _animationFilter)
            {
                _animationFilter.GetEntity(i).Destroy();
            }
            _blocker.gameObject.SetActive(false);
        }
    }
}