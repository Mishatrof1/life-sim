using Components.Screen;
using Leopotam.Ecs;
using UnityEngine;

namespace Screens
{
    public static class ScreenUtils
    {
        public static Color SetSliderColor(float value)
        {
            if (value <= 0.33)
            {
                return new Color(1f, 0.27f, 0.1f);
            } 
            else if (value >= 0.66)
            {
                return new Color(0.39f, 0.82f, 0.24f);
            }
            else
            {
                return new Color(1f, 0.88f, 0.2f);
            }
        }

        public static bool HasScreenView<T>(this EcsFilter<ScreenComponent> filter)
        {
            foreach (var i in filter)
            {
                var comp = filter.Get1(i);
                if (comp.ScreenView is T)
                {
                    return true;
                }
            }

            return false;
        }
        
        public static void Destroy<T>(this EcsFilter<ScreenComponent> filter)
        {
            foreach (var i in filter)
            {
                var comp = filter.Get1(i);
                if (comp.ScreenView is T)
                {
                    filter.GetEntity(i).Destroy();
                }
            }
        }
    }
}