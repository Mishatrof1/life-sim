using System.Collections.Generic;
using Components;
using Components.Navigation;
using Leopotam.Ecs;

namespace Modules.Navigation
{
    public static class NavigationUtils
    {
        public static void RegisterElement(this EcsFilter<BlockComponent> filter, NavigationBlockType blockType, INavigationElement element)
        {
            foreach (var i in filter)
            {
                var block = filter.Get1(i).Block;
                if (block.Type != blockType)
                    continue;
                
                block.RegisterElement(element);
            }
        }
        
        public static void RemoveElement(this EcsFilter<BlockComponent> filter, NavigationBlockType blockType, INavigationElement element)
        {
            foreach (var i in filter)
            {
                var block = filter.Get1(i).Block;
                if (block.Type != blockType)
                    continue;
                
                block.RemoveElement(element);
            }
        }
        
        public static T GetLastElementInChain<T>(this EcsFilter<BlockComponent, Active> filter, NavigationBlockType blockType)
            where T : class, INavigationElement
        {
            foreach (var i in filter)
            {
                var block = filter.Get1(i).Block;
                if (block.Type != blockType)
                    continue;
                
                return block.GetLastElementInChain<T>();
            }

            return null;
        }
        
        public static NavigationPoint GetCurrentPoint(this EcsFilter<BlockComponent, Active> filter, NavigationBlockType blockType)
        {
            foreach (var i in filter)
            {
                var block = filter.Get1(i).Block;
                if (block.Type != blockType)
                    continue;
                
                return block.CurrentPoint;
            }

            return null;
        }
        
        public static NavigationPoint GetCurrentPoint(this EcsFilter<BlockComponent, Active> filter)
        {
            foreach (var i in filter)
            {
                var activeComp = filter.Get2(i);
                if (activeComp.Order != filter.GetEntitiesCount() - 1)
                    continue;
                
                return filter.Get1(i).Block.CurrentPoint;
            }

            return null;
        }
        
        public static List<NavigationPoint> GetPointsToDisplay(this EcsFilter<BlockComponent, Active> filter)
        {
            foreach (var i in filter)
            {
                var activeComp = filter.Get2(i);
                if (activeComp.Order != filter.GetEntitiesCount() - 1)
                    continue;
                
                return filter.Get1(i).Block.GetPointsToDisplay();
            }

            return null;
        }
        
        public static NavigationButtonData GetDefaultButtonData(this EcsFilter<BlockComponent> filter, NavigationBlockType blockType, NavigationElementType elementType)
        {
            foreach (var i in filter)
            {
                var block = filter.Get1(i).Block;
                if (block.Type != blockType)
                    continue;
                
                return block.GetDefaultButtonData(elementType);
            }

            return null;
        }
        
        public static NavigationScreenData GetDefaultScreenData(this EcsFilter<BlockComponent> filter, NavigationBlockType blockType, NavigationElementType elementType)
        {
            foreach (var i in filter)
            {
                var block = filter.Get1(i).Block;
                if (block.Type != blockType)
                    continue;
                
                return block.GetDefaultScreenData(elementType);
            }

            return null;
        }
    }
}