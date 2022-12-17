using System.Collections.Generic;
using Components;
using Components.Events;
using Components.Navigation;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Popups;
using Save;
using Screens;
using CharacterComponent = Components.CharacterComponent;

namespace Systems
{
    public class CharacterDeath : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<BlockComponent, Active> _navigationFilter;
        private EcsFilter<ShowPopup> _showPopupRequestFilter;
        
        private SaveDataProvider _saveDataProvider;
        private PopupViewManager _popupViewManager;

        public void Init()
        {
            EventSystem.Subscribe<StartScreen_NewCharacterClick>(OnNewCharacterClick);
        }

        public void Destroy()
        {
            EventSystem.Unsubscribe<StartScreen_NewCharacterClick>(OnNewCharacterClick);
        }

        private void OnNewCharacterClick(StartScreen_NewCharacterClick e)
        {
            _saveDataProvider.ResetSaveData();
            foreach (var i in _charactersFilter)
            {
                _charactersFilter.GetEntity(i).Destroy();
            }
            foreach (var i in _showPopupRequestFilter)
            {
                _showPopupRequestFilter.GetEntity(i).Destroy();
            }
            _world.NewEntity().Replace(new NewCharacter());
        }

        public void Run()
        {
            foreach (var i in _charactersFilter)
            {
                var character = _charactersFilter.Get1(i).Character;

                bool isDead = character.Parameters.Get(ParameterType.Health.ToString()).Value <= 0;

                if (!isDead)
                    continue;
                
                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                    {
                        HeaderText = LocalizationDictionary.GetLocalizedString("you_dead_pp_title"),
                        ContentText = LocalizationDictionary.GetLocalizedString("you_dead_pp"),
                        ActionsSettings = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = LocalizationDictionary.GetLocalizedString("new_character"),
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new NewCharacter());
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            }
                        }
                    })
                });
                _charactersFilter.GetEntity(i).Destroy();
            }
        }

    }
}