using System.Linq;
using Systems.NavigationElements;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.Education;
using Leopotam.Ecs;
using Modules.Navigation;

namespace Systems
{
    public class Navigation : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<Components.Events.NavigationPointClick> _pointClickFilter;
        private EcsFilter<NavigationBack> _backFilter;
        private EcsFilter<NavigationHome> _homeFilter;
        private EcsFilter<NavigationInstantChangePoint> _instantChangePointFilter;
        private EcsFilter<NavigationActivateBlock> _activateBlockFilter;
        private EcsFilter<Components.Events.NavigationPointChanged> _navPointChangedFilter;

        public void Init()
        {
            EventSystem.Subscribe<NavigationPointClick>(OnNavigationPointClick);
            EventSystem.Subscribe<NavigationBackClick>(OnNavigationBackClick);
            EventSystem.Subscribe<NavigationHomeClick>(OnNavigationHomeClick);
        }
        
        public void Destroy()
        {
            EventSystem.Unsubscribe<NavigationPointClick>(OnNavigationPointClick);
            EventSystem.Unsubscribe<NavigationBackClick>(OnNavigationBackClick);
            EventSystem.Unsubscribe<NavigationHomeClick>(OnNavigationHomeClick);
        }
        
        public void Run()
        {
            foreach (var i in _pointClickFilter)
            {
                ToNextPoint(_pointClickFilter.Get1(i).NavigationPoint);
                _pointClickFilter.GetEntity(i).Destroy();
            }
            
            foreach (var i in _backFilter)
            {
                Back();
                _backFilter.GetEntity(i).Destroy();
            }
            
            foreach (var i in _homeFilter)
            {
                ToHome();
                _homeFilter.GetEntity(i).Destroy();
            }
            
            foreach (var i in _instantChangePointFilter)
            {
                InstantChangePoint(_instantChangePointFilter.Get1(i).NavigationElementType);
                _instantChangePointFilter.GetEntity(i).Destroy();
            }

            foreach (var i in _activateBlockFilter)
            {
                ActivateNavigationBlock(_activateBlockFilter.Get1(i).BlockType);
                _activateBlockFilter.GetEntity(i).Destroy();
            }
        }

        private void OnNavigationPointClick(NavigationPointClick e)
        {
            ToNextPoint(e.Point);
        }
        
        private void OnNavigationBackClick(NavigationBackClick e)
        {
           Back();
        }
        
        private void OnNavigationHomeClick(NavigationHomeClick e)
        {
            ToHome();
        }

        private void ToHome()
        {
            NavigationPoint previousPoint = null;
            foreach (var i in _navigationActiveFilter)
            {
                var block = _navigationActiveFilter.Get1(i).Block;
                var activeComp = _navigationActiveFilter.Get2(i);
                if (activeComp.Order != _navigationActiveFilter.GetEntitiesCount() - 1)
                    continue;

                if (block.Type == NavigationBlockType.Main &&
                    block.CurrentPoint.Type == NavigationElementType.MainScreen)
                    continue;

                previousPoint = block.CurrentPoint;
            }
            
            if (previousPoint == null)
                return;
            
            foreach (var i in _navigationActiveFilter)
            {
                var block = _navigationActiveFilter.Get1(i).Block;
                block.ClearNavigationChain();
                _navigationActiveFilter.GetEntity(i).Del<Active>();
            }
            
            foreach (var i in _navigationFilter)
            {
                var block = _navigationFilter.Get1(i).Block;
                if (block.Type != NavigationBlockType.Main)
                    continue;
                
                block.ToRootPoint();
                GameProcessingEcs.Instance.CurrentNavigationBlock = block;
                _navigationFilter.GetEntity(i).Replace(new Active {Order = 0});
                
                _world.NewEntity().Replace(new Components.Events.NavigationPointChanged
                {
                    CurrentPoint = block.CurrentPoint,
                    PreviousPoint = previousPoint,
                    TransitionType = TransitionType.Out
                });
            }
        }
        
        private void ToNextPoint(NavigationPoint navigationPoint)
        {
            NavigationPoint previousPoint = null;
            foreach (var i in _navigationActiveFilter)
            {
                var block = _navigationActiveFilter.Get1(i).Block;
                var activeComp = _navigationActiveFilter.Get2(i);
                if (activeComp.Order != _navigationActiveFilter.GetEntitiesCount() - 1)
                    continue;

                previousPoint = block.CurrentPoint;
                block.HandlePointClick(navigationPoint);

                if (previousPoint != block.CurrentPoint)
                {
                    _world.NewEntity().Replace(new Components.Events.NavigationPointChanged
                    {
                        CurrentPoint = block.CurrentPoint,
                        PreviousPoint = previousPoint,
                        TransitionType = TransitionType.In
                    });
                }
            }
        }
        
        private void Back()
        {
            NavigationPoint previousPoint = null;
            NavigationPoint currentPoint = null;
            var blockChanged = false;
            foreach (var i in _navigationActiveFilter)
            {
                var block = _navigationActiveFilter.Get1(i).Block;
                var activeComp = _navigationActiveFilter.Get2(i);
                if (activeComp.Order != _navigationActiveFilter.GetEntitiesCount() - 1)
                    continue;

                previousPoint = block.CurrentPoint;
                block.ToPreviousPoint();
                if (block.IsEmptyChain)
                {
                    blockChanged = true;
                    _navigationActiveFilter.GetEntity(i).Del<Active>();
                }
                else
                {
                    currentPoint = block.CurrentPoint;
                }
            }

            if (blockChanged)
            {
                foreach (var i in _navigationActiveFilter)
                {
                    var block = _navigationActiveFilter.Get1(i).Block;
                    var activeComp = _navigationActiveFilter.Get2(i);
                    if (activeComp.Order != _navigationActiveFilter.GetEntitiesCount() - 1)
                        continue;
                    
                    currentPoint = block.CurrentPoint;
                    GameProcessingEcs.Instance.CurrentNavigationBlock = block;
                }
            }

            _world.NewEntity().Replace(new Components.Events.NavigationPointChanged
            {
                CurrentPoint = currentPoint,
                PreviousPoint = previousPoint,
                TransitionType = TransitionType.Out
            });
        }
        
        private void InstantChangePoint(NavigationElementType elementType)
        {
            NavigationPoint previousPoint = null;
            NavigationPoint currentPoint = null;
            foreach (var i in _navigationActiveFilter)
            {
                var block = _navigationActiveFilter.Get1(i).Block;
                var activeComp = _navigationActiveFilter.Get2(i);
                if (activeComp.Order != _navigationActiveFilter.GetEntitiesCount() - 1)
                    continue;

                previousPoint = block.CurrentPoint;
                switch (elementType)
                {
                    case NavigationElementType.CurrentOccupationScreen:
                    {
                        var currentOccupation = CurrentCharacterOccupation();
                        if (currentOccupation != null)
                        {
                            if (currentOccupation is EducationService educationService)
                            {
                                INavigationElement element = null;
                                switch (educationService.Type)
                                {
                                    case EducationType.CommunityCollege:
                                        element = block.GetElements(elementType)
                                            .First(e => e is CommunityCollege);
                                        break;
                                    case EducationType.University:
                                        element = block.GetElements(elementType)
                                            .First(e => e is University);
                                        break;
                                }
                                
                                block.ToPointInstant(new NavigationPoint
                                {
                                    Type = NavigationElementType.CurrentOccupationScreen,
                                    Element = element
                                });
                            }
                        }
                        break;
                    }
                    case NavigationElementType.FindJobScreen:
                    {
                        block.ToFirstPointOfType(NavigationElementType.FindJobScreen);
                        break;
                    }
                }

                if (block.CurrentPoint != null || previousPoint != null)
                {
                    _world.NewEntity().Replace(new Components.Events.NavigationPointChanged
                    {
                        CurrentPoint = block.CurrentPoint,
                        PreviousPoint = previousPoint,
                        TransitionType = TransitionType.In
                    });
                }
            }
        }

        private void ActivateNavigationBlock(NavigationBlockType blockType)
        {
            NavigationPoint previousPoint = null;
            NavigationPoint currentPoint = null;
            foreach (var i in _navigationActiveFilter)
            {
                var block = _navigationActiveFilter.Get1(i).Block;
                var active = _navigationActiveFilter.Get2(i);
                if (active.Order == _navigationActiveFilter.GetEntitiesCount() - 1)
                {
                    previousPoint = block.CurrentPoint;
                }
            }
            
            foreach (var i in _navigationFilter)
            {
                var block = _navigationFilter.Get1(i).Block;
                if (block.Type != blockType)
                    continue;
                
                var entity = _navigationFilter.GetEntity(i);
                if (entity.Has<Active>())
                {
                    continue;
                }

                entity.Replace(new Active
                {
                    Order = _navigationActiveFilter.GetEntitiesCount()
                });
                GameProcessingEcs.Instance.CurrentNavigationBlock = block;
                block.ToRootPoint();
                currentPoint = block.CurrentPoint;
            }
            
            _world.NewEntity().Replace(new Components.Events.NavigationPointChanged
            {
                CurrentPoint = currentPoint,
                PreviousPoint = previousPoint,
                TransitionType = TransitionType.In
            });
        }

        private MainOccupation CurrentCharacterOccupation()
        {
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                return character.CurrentOccupation;
            }
            
            return null;
        }
    }
}