using Components;
using Leopotam.Ecs;
using Newtonsoft.Json;
using Settings;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class LocalizationSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<LocalizationChange> _localizationChangeFilter;
        private GlobalSettings _globalSettings;

        public void Run()
        {
            if (_localizationChangeFilter.IsEmpty())
                return;

            foreach (var i in _localizationChangeFilter)
            {
                var localizationChange = _localizationChangeFilter.Get1(i);
                LocalizationDictionary.Setup(_globalSettings, localizationChange.Language);
            }
        }

    }
}
