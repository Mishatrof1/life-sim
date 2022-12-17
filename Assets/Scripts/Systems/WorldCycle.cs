using System.Collections.Generic;
using Components;
using Components.Events;
using Leopotam.Ecs;
using Modules;
using Popups;

namespace Systems
{
    public class WorldCycle : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<NextWorldDateIteration> _nextWorldCycleIteration;
        
        private WorldDateModule _worldDateModule;
        
        public void Run()
        {
            if (_nextWorldCycleIteration.IsEmpty())
                return;
            
            _worldDateModule.NextIteration();
        }
    }
}