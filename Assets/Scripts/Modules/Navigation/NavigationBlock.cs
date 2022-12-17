using System;
using System.Collections.Generic;
using System.Linq;
using Settings;
using UnityEngine;

namespace Modules.Navigation
{
    public class NavigationBlock
    {
        private readonly List<INavigationElement> _elements;
        private readonly Stack<NavigationPoint> _navigationChain;
        private readonly NavigationElementsSet _navigationElementsSet;
        private readonly NavigationElementType _main;

        public NavigationBlockType Type { get; }

        public NavigationBlock(NavigationBlockType type, NavigationElementType main, NavigationElementsSet navigationElementsSet)
        {
            Type = type;
            _navigationElementsSet = navigationElementsSet;
            _navigationChain = new Stack<NavigationPoint>();
            _elements = new List<INavigationElement>();
            _main = main;

            CurrentPoint = null;
        }

        public NavigationPoint CurrentPoint { get; private set; }
        public bool IsEmptyChain => _navigationChain.Count == 0;

        public void RegisterElement(INavigationElement element)
        {
            _elements.Add(element);
        }

        public void RemoveElement(INavigationElement element)
        {
            _elements.Remove(element);
        }
        
        public List<NavigationPoint> GetPointsOfType(NavigationElementType type)
        {
            return _elements.Where(e => e.CanDisplay(type)).Select(e => new NavigationPoint
            {
                Type = type,
                Element = e
            }).ToList();
        }

        public List<NavigationPoint> GetChildPointsOf(NavigationElementType type)
        {
            var points = new List<NavigationPoint>();
            var settings = _navigationElementsSet.NavigationElementsSettings.First(s => s.Type == type);
            foreach (var possibleChildType in settings.PossibleChilds)
            {
                points.AddRange(GetPointsOfType(possibleChildType));
            }
            return points;
        }
        
        public List<NavigationPoint> GetPointsToDisplay()
        {
            return GetChildPointsOf(CurrentPoint.Type);
        }

        private void ToPoint(NavigationPoint point, TransitionType transitionType)
        {
            var previousPoint = CurrentPoint;
            CurrentPoint = point;

            switch (transitionType)
            {
                case TransitionType.In:
                {
                    if (point == null)
                    {
                        throw new ArgumentException($"Null NavigationPoint for {nameof(TransitionType.In)}");
                    }
                    _navigationChain.Push(CurrentPoint);
                    break;
                }
                case TransitionType.Out:
                {
                    if (point == null)
                    {
                        throw new ArgumentException($"Null NavigationPoint for {nameof(TransitionType.Out)}");
                    }
                    _navigationChain.Push(CurrentPoint);
                    break;
                }
            }
        }

        public List<INavigationElement> GetElements(NavigationElementType type)
        {
            return _elements.Where(el => el.Types.Any(t => t == type)).ToList();
        }
        
        public void ToPointInstant(NavigationPoint point)
        {
            ClearNavigationChain();
            _navigationChain.Push(new NavigationPoint{Type = _main, Element = _elements.First(el => el.CanDisplay(_main))});
            ToPoint(point, TransitionType.In);
        }
        
        public void ToFirstPointOfType(NavigationElementType type)
        {
            var navElement = _elements.FirstOrDefault(el => el.Types.Any(t => t == type));
            if (navElement == null)
                return;
            
            ClearNavigationChain();
            _navigationChain.Push(new NavigationPoint{Type = _main, Element = _elements.First(el => el.CanDisplay(_main))});
            ToPoint(new NavigationPoint { Type = type, Element = navElement}, TransitionType.In);
        }

        public void HandlePointClick(NavigationPoint navPoint)
        {
            if (!navPoint.Element.OnClick(navPoint.Type))
            {
                return;
            }

            if (!navPoint.Element.IgnoreChildrenDisplayCheck(navPoint.Type) && GetChildPointsOf(navPoint.Type).Count == 0)
            { 
                return;
            }
            
            ToPoint(navPoint, TransitionType.In);
        }

        public void ToPreviousPoint()
        {
            if (_navigationChain.Count == 0)
                return;
            
            _navigationChain.Pop();
            if (_navigationChain.Count == 0)
                return;
            
            ToPoint(_navigationChain.Pop(), TransitionType.Out);
        }
        
        public void ToRootPoint()
        {
            ClearNavigationChain();
            ToPoint(GetPointsOfType(_main).First(), TransitionType.In);
        }

        public void ClearNavigationChain()
        {
            _navigationChain.Clear();
            CurrentPoint = null;
        }

        public T GetLastElementInChain<T>() where T : class, INavigationElement
        {
            return _navigationChain.LastOrDefault(point => point.Element is T)?.Element as T;
        }

        public NavigationButtonData GetDefaultButtonData(NavigationElementType elementType)
        {
            var settings = _navigationElementsSet.NavigationElementsSettings.FirstOrDefault(s => s.Type == elementType);
            var data = new NavigationButtonData();
            data.Icon = settings?.Icon;
            data.Title = settings?.Title;
            data.Description = settings?.Description;
            data.CompanyType = settings?.CompanyType;
            return data;
        }
        
        public NavigationScreenData GetDefaultScreenData(NavigationElementType elementType)
        {
            var settings = _navigationElementsSet.NavigationElementsSettings.FirstOrDefault(s => s.Type == elementType);
            var data = new NavigationScreenData();
            data.Icon = settings?.Icon;
            data.Title = settings?.Title;
            data.Description = settings?.Description;

            return data;
        }
    }

    public enum TransitionType
    {
        In,
        Out
    }
}