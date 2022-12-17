using Components;
using Components.Events;
using Leopotam.Ecs;
using Modules;

namespace Systems
{
    public class Location : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Created, CharacterComponent> _characterCreatedFilter;
        private EcsFilter<CharacterComponent, ChangeLocation> _changeLocationFilter;
        private EcsFilter<LocationComponent> _locationFilter;
        
        private WorldGenerator _worldGenerator;

        public void Run()
        {
            foreach (var i in _characterCreatedFilter)
            {
                foreach (var locationIndex in _locationFilter)
                {
                    _locationFilter.GetEntity(locationIndex).Destroy();
                }
                
                var location = _worldGenerator.GenerateLocationData();
                var character = _characterCreatedFilter.Get2(i).Character;

                character.CurrentLocation = location;
                character.AvailableLocations.Add(location);

                _world.NewEntity()
                    .Replace(new LocationComponent {Location = location})
                    .Replace(new NewLocation());
            }
            
            foreach (var i in _changeLocationFilter)
            {
                var character = _changeLocationFilter.Get1(i).Character;
                var newLocation = _changeLocationFilter.Get2(i);

                character.CurrentLocation = newLocation.Location;
                character.AvailableLocations.Add(newLocation.Location);
                
                if (!character.AvailableLocations.Contains(newLocation.Location))
                {
                    character.AvailableLocations.Add(newLocation.Location);
                }
            }
        }
    }
}