using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Components.Screen;
using Leopotam.Ecs;
using Modules.Navigation;
using Screens.ActionsScreen;
using Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class ActionsScreenView : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<ScreenComponent> _screenFilter;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<RefreshActionScreenButtons> _refreshActionScreenButtonsFilter;
        private EcsFilter<BlockComponent, Active> _navActiveBlockFilter;

        private PrefabSet _prefabSet;
        
        private List<ActivityButton> _activityButtonInstances;
        private List<ActivitySplitter> _activitySplitterInstances;
        
        public void Init()
        {
            EventSystem.Subscribe<ActionsScreen_BackButtonClick>(OnActionsScreenBackButton);
            EventSystem.Subscribe<ActionsScreen_HomeButtonClick>(OnActionsScreenHomeButton);
        }

        public void Run()
        {
            if (_characterFilter.IsEmpty())
                return;
            
            foreach (var i in _screenFilter)
            {
                ref var screenViewComp = ref _screenFilter.Get1(i);
                if (!(screenViewComp.ScreenView is global::Screens.ActionsScreen.ActionsScreenView actionsScreenView))
                    continue;

                if (!screenViewComp.Initialized)
                {
                    screenViewComp.Initialized = true;
                
                    UpdateView(actionsScreenView);
                    var height = UnityEngine.Screen.height - UnityEngine.Screen.safeArea.y - UnityEngine.Screen.safeArea.height;
                    actionsScreenView.InactivePanel.GetComponent<LayoutElement>().minHeight = height;
                }
            }

            if (!_refreshActionScreenButtonsFilter.IsEmpty())
                RefreshButtons();

        }

        public void Destroy()
        {
            EventSystem.Unsubscribe<ActionsScreen_BackButtonClick>(OnActionsScreenBackButton);
            EventSystem.Unsubscribe<ActionsScreen_HomeButtonClick>(OnActionsScreenHomeButton);
        }
        
        private void UpdateView(global::Screens.ActionsScreen.ActionsScreenView actionsScreenView)
        {
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                _activityButtonInstances = new List<ActivityButton>();
                _activitySplitterInstances = new List<ActivitySplitter>();

                var currentPoint = _navActiveBlockFilter.GetCurrentPoint();
                var screenData = currentPoint.GetScreenData();
                actionsScreenView.Title.text = screenData.Title;
                actionsScreenView.TitleDescription.text = "";
                
                var pointsGroups =  GetPointsGroups(_navActiveBlockFilter.GetPointsToDisplay(), currentPoint, character);
                if (currentPoint.Type == NavigationElementType.FullTimeJobs)
                {
                    pointsGroups.ForEach(pg => pg.NavigationPoints = pg.NavigationPoints.OrderBy(a => Guid.NewGuid()).ToList());
                }
                foreach (var pointGroup in pointsGroups)
                {
                    if (pointGroup.IsVisible && !string.IsNullOrEmpty(pointGroup.Name))
                    {
                        InstantiateSplitter(pointGroup.Name, actionsScreenView.ActivityButtonsParent);
                    }

                    foreach (var navigationPoint in pointGroup.NavigationPoints)
                    {
                        InstantiateActivityButton(navigationPoint, actionsScreenView.ActivityButtonsParent);
                    }
                }
            }
        }

        private void RefreshButtons()
        {
            foreach (var instance in _activityButtonInstances)
                instance.Refresh();
        }
        
        private List<NavigationPointsGroup> GetPointsGroups(List<NavigationPoint> navPoints, NavigationPoint currentPoint, Core.Character character)
        {
            List<NavigationPointsGroup> result = null;
            result = currentPoint.Type switch
            {
                NavigationElementType.AssetsScreen => navPoints.Select(np =>
                {
                    if (np.Type == NavigationElementType.FinancesProfile)
                    {
                        return (Point: np, Group: "", OrderInGroup: -1);
                    }

                    if (np.Type == NavigationElementType.Shopping)
                    {
                        return (Point: np, Group: "zzz", OrderInGroup: 0);
                    }
                
                    return (Point: np, Group: "", OrderInGroup: 0);
                }).GroupBy(data => data.Group).Select(g =>
                {
                    var pointsGroup = new NavigationPointsGroup
                    {
                        Name = g.Key,
                        NavigationPoints = g.OrderBy(x => x.OrderInGroup).Select(x => x.Point).ToList()
                    };
                    if (g.Key == "zzz")
                    {
                        pointsGroup.IsVisible = false;
                    }
                    return pointsGroup;
                }).OrderBy(ng => ng.Name).ToList(),
                
                NavigationElementType.RelationshipsScreen => navPoints.Select(np =>
                {
                    if (np.Type != NavigationElementType.NpcScreen)
                        return (Point: np, Group: LocalizationDictionary.GetLocalizedString("action_screen_relationship_collegues"), OrderInGroup: 2);

                    var npc = (Core.Npc)np.Element;
                    var relationship = npc.Relationships.FirstOrDefault(r =>
                        r.Person.Id == character.Id);

                    if (relationship == null)
                        return (Point: np, Group: "", OrderInGroup: 0);

                    var group = relationship.RelationshipType switch
                    {
                        RelationshipType.Mother => LocalizationDictionary.GetLocalizedString("action_screen_relationship_parents"),
                        RelationshipType.Father => LocalizationDictionary.GetLocalizedString("action_screen_relationship_parents"),
                        RelationshipType.Friend => LocalizationDictionary.GetLocalizedString("action_screen_relationship_friends"),
                        RelationshipType.Lover => LocalizationDictionary.GetLocalizedString("action_screen_relationship_lovers"),
                        RelationshipType.Enemy => LocalizationDictionary.GetLocalizedString("action_screen_relationship_enemies"),
                        _ => throw new ArgumentOutOfRangeException()
                    };

                    return (Point: np, Group: group, OrderInGroup: 0);
                }).Where(x => !string.IsNullOrEmpty(x.Group))
                .GroupBy(data => data.Group).Select(g => new NavigationPointsGroup
                {
                    Name = g.Key,
                    NavigationPoints = g.OrderBy(x => x.OrderInGroup).Select(x => x.Point).ToList(),
                    Order = g.Key == LocalizationDictionary.GetLocalizedString("action_screen_relationship_parents") ? 0 : 1
                }).OrderBy(ng => ng.Order).ToList(),
                
                _ => new List<NavigationPointsGroup>
                {
                    new NavigationPointsGroup
                    {
                        NavigationPoints = navPoints
                    }
                }
            };

            return result;
        }

        private void InstantiateActivityButton(NavigationPoint navPoint, Transform parent)
        {
            var buttonPrefabType = navPoint.Type == NavigationElementType.Shopping
                ? ActivityButtonType.Shopping
                : ActivityButtonType.Default;
            var activityButtonPrefab = _prefabSet.ActivityButtonPrefabs
                .First(x => x.ButtonType == buttonPrefabType)
                .Prefab;
            var button = GameObject.Instantiate(
                activityButtonPrefab, parent, false).GetComponentInChildren<ActivityButton>();
            button.Setup(navPoint);
            _activityButtonInstances.Add(button);
        }

        private void InstantiateSplitter(string groupName, Transform parent)
        {
            var splitterPrefab = _prefabSet.GroupSplitterPrefab;
            var splitter = GameObject.Instantiate(splitterPrefab, parent, false).GetComponent<ActivitySplitter>();
            splitter.Title.text = groupName;
            _activitySplitterInstances.Add(splitter);
        }

        private void OnActionsScreenBackButton(ActionsScreen_BackButtonClick e)
        {
            _world.NewEntity().Replace(new NavigationBack());
        }
        
        private void OnActionsScreenHomeButton(ActionsScreen_HomeButtonClick e)
        {
            _world.NewEntity().Replace(new NavigationHome());
        }
    }
    
    public class NavigationPointsGroup
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsVisible { get; set; }
        public List<NavigationPoint> NavigationPoints { get; set; }

        public NavigationPointsGroup()
        {
            Name = "";
            IsVisible = true;
            NavigationPoints = new List<NavigationPoint>();
            Order = 0;
        }
    }
}