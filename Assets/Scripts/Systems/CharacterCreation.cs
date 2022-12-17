using System;
using System.Collections.Generic;
using Components;
using Components.Events;
using Leopotam.Ecs;
using Modules;
using Settings;
using Settings.Appearance;
using CharacterComponent = Components.CharacterComponent;

namespace Systems
{
    public class CharacterCreation : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<NewCharacter> _newCharacterFilter;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<Created, CharacterComponent> _createdFilter;

        private AppearanceSettingsList _facesSettings;
        private WorldGenerator _worldGenerator;
        private GlobalSettings _globalSettings;
        private PopupViewManager _popupViewManager;

        public void Run()
        {
            foreach (var i in _createdFilter)
            {
                _charactersFilter.GetEntity(i).Del<Created>();
            }
            
            if (_popupViewManager.HasOpened)
                return;
            
            if (_newCharacterFilter.IsEmpty())
                return;
            
            foreach (var i in _charactersFilter)
            {
                _charactersFilter.GetEntity(i).Destroy();
            }

            foreach (var i in _newCharacterFilter)
            {
#if UNITY_EDITOR
                var character = _worldGenerator.GenerateCharacter(WorldDateModule.CurrentDate, _facesSettings, _globalSettings.MaxCharacterParameters);
#else
                var character = _worldGenerator.GenerateCharacter(WorldDateModule.CurrentDate, _facesSettings, false);
#endif
                var entity = _newCharacterFilter.GetEntity(i);

                entity
                    .Replace(new CharacterComponent {Character = character})
                    .Replace(new ParametersComponent {ParametersOwner = character})
                    .Replace(new PersonComponent {Person = character});

                _world.NewEntity().Replace(new NewParent { Gender = Genders.Male });
                _world.NewEntity().Replace(new NewParent { Gender = Genders.Female });
                
                entity.Del<NewCharacter>();
                entity.Replace(new Created());

            }
        }
    }
}