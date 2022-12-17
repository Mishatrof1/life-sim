using Components;
using Leopotam.Ecs;
using Modules;

namespace Systems
{
    public class Character : IEcsRunSystem
    {
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsWorld _world;

        public void Run()
        {

            if (_nextIterationFilter.IsEmpty())
                return;

            var dateStart = WorldDate.FromYears(WorldDateModule.CurrentDate.TotalYears - 1);
            var dateEnd = WorldDateModule.CurrentDate;

            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                character.ResetProductivity();
                if (character.IsAppearenceChanging(dateStart, dateEnd))
                {
                    _world.NewEntity().Replace(new AppearanceChanged
                    {
                        Person = character
                    });
                }
            }
        }
    }
}

