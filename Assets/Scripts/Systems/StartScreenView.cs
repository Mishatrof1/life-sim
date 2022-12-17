using Components;
using Components.Navigation;
using Components.Screen;
using Leopotam.Ecs;
using Save;
using UnityEngine;

namespace Systems
{
    public class StartScreenView : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<ScreenComponent> _screenFilter;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navBlockFilter;
        private EcsFilter<BlockComponent, Active> _navActiveBlockFilter;

        private SaveDataProvider _saveDataProvider;
        
        public void Init()
        {
            EventSystem.Subscribe<StartScreen_SoundClick>(OnStartScreenSoundClick);
        }

        public void Destroy()
        {
            EventSystem.Unsubscribe<StartScreen_SoundClick>(OnStartScreenSoundClick);
        }
        
        public void Run()
        {
            foreach (var i in _screenFilter)
            {
                ref var screenViewComp = ref _screenFilter.Get1(i);
                if (!(screenViewComp.ScreenView is global::Screens.StartScreen.StartScreenView startScreenView))
                    continue;

                if (screenViewComp.Initialized)
                    continue;

                screenViewComp.Initialized = true;

                SetUpSoundBtn(startScreenView);
                
                var characterSaveData = _saveDataProvider.GetSaveData<CharacterSaveData>();
                if (characterSaveData == null) return;

                var character = characterSaveData.Character;
                if (string.IsNullOrEmpty(character.Id))
                    return;

                var characterButton = GameObject.Instantiate(startScreenView.ButtonPrefab, startScreenView.CharInfoParent.transform);
                characterButton.Setup(new Core.Character(character));
            }
        }

        private void OnStartScreenSoundClick(StartScreen_SoundClick e)
        {
            foreach (var i in _screenFilter)
            {
                ref var screenViewComp = ref _screenFilter.Get1(i);
                if (!(screenViewComp.ScreenView is global::Screens.StartScreen.StartScreenView startScreenView))
                    continue;

                SoundProvider.Instance.ChangeSoundState();
                SoundProvider.Instance.PlaySound("click");
                SetUpSoundBtn(startScreenView);
            }
        }
        
        private void SetUpSoundBtn(global::Screens.StartScreen.StartScreenView startScreenView)
        {
            var state = SoundProvider.Instance.SoundState;
            if (startScreenView.SoundBtn == null || startScreenView.SoundOnSprite == null || startScreenView.SoundOffSprite == null) return;
            startScreenView.SoundBtn.sprite = state ? startScreenView.SoundOffSprite : startScreenView.SoundOnSprite;
        }
    }
}