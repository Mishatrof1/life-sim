using Components;
using Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class StatsChanging : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<ParametersComponent, ChangeStatsComponent, PersonComponent> _changeStatsFilter;

        public void Run()
        {
            foreach (var i in _changeStatsFilter)
            {
                var parametersOwner = _changeStatsFilter.Get1(i).ParametersOwner;
                var changeStats = _changeStatsFilter.Get2(i);

                foreach (var changeStat in changeStats.ChangeStats)
                {
                    var parametrId = changeStat.ParameterId;
                    parametrId = parametrId.Replace("Wealth","Balance"); //todo финансовая система
                    parametersOwner.Parameters.Get(parametrId).Inc(changeStat.Value);
                }

                _changeStatsFilter.GetEntity(i).Del<ChangeStatsComponent>();

                EventSystem.Send(new ParametersChanged
                {
                    Person = _changeStatsFilter.Get3(i).Person
                });
            }
        }
    }
}