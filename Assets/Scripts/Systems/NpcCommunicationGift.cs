using System.Collections.Generic;
using Components;
using Components.Events;
using Components.Navigation;
using Core.NpcCommunication;
using DialogSystem;
using Leopotam.Ecs;
using Modules.Navigation;
using Settings.NpcCommunication;

namespace Systems
{
    public class NpcCommunicationGift : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsFilter<Components.NpcCommunication> _communicationFilter;
        private EcsFilter<BlockComponent, Active> _navigationFilter;

        private int _dropDownValue;
        
        public void Init()
        {
            EventSystem.Subscribe<DialogChoiceButton_Click>(OnDialogResponse_Click);
            EventSystem.Subscribe<CharacterScreen_DropDownValueChanged>(OnCharacterScreenDropDownValueChanged);
        }
        
        public void Destroy()
        {
            EventSystem.Unsubscribe<DialogChoiceButton_Click>(OnDialogResponse_Click);
            EventSystem.Unsubscribe<CharacterScreen_DropDownValueChanged>(OnCharacterScreenDropDownValueChanged);
        }
        
        public void Run()
        {
            foreach (var i in _communicationFilter)
            {
                ref var communication = ref _communicationFilter.Get1(i);
                var entity = _communicationFilter.GetEntity(i);

                if (!(communication.Communication is GiftCommunication))
                    continue;
                
                if (_navigationFilter.GetCurrentPoint(NavigationBlockType.Main)?.Type != NavigationElementType.GiftInteraction)
                {
                    entity.Destroy();
                    continue;
                }

                if (entity.Has<ChoicesChanged>())
                {
                    entity.Del<ChoicesChanged>();
                }
                
                if (entity.Has<New>())
                {
                    communication.DropListChoices = communication.Communication.GenerateChoices(communication.Npc);
                    communication.ButtonChoices = new List<CommunicationChoice>
                    {
                        new CommunicationChoice
                        {
                            Index = 0,
                            Text = LocalizationDictionary.GetLocalizedString("communication_make_gift")
                        }
                    };
                    
                    entity.Replace(new ChoicesChanged
                    {
                        Message = communication.Communication.GetTopText(communication.Npc),
                        DropListChoices = communication.DropListChoices,
                        ButtonChoices = communication.ButtonChoices
                    });
                }
                
                if (entity.Has<ChoiceSelected>())
                {
                    if (!communication.Final)
                    {
                        var selectedIndex = entity.Get<ChoiceSelected>().CurrentDropDownIndex;
                        foreach (var charCompIndex in _charactersFilter)
                        {
                            var character = _charactersFilter.Get1(charCompIndex).Character;
                            if (character.Id != communication.Character.Id)
                                continue;
                            
                            foreach (var npcComIndex in _npcFilter)
                            {
                                var npc = _npcFilter.Get1(npcComIndex).Npc;
                                if (npc.Id != communication.Npc.Id)
                                    continue;
                
                                var bubbleText = communication.Communication.HandleSelectedChoice(selectedIndex,
                                    ref _communicationFilter.GetEntity(i),
                                    ref _charactersFilter.GetEntity(charCompIndex),
                                    ref _npcFilter.GetEntity(npcComIndex));
                
                                if (!string.IsNullOrEmpty(bubbleText))
                                {
                                    EventSystem.Send(new BubbleTextComponent { BubbleTextValue = bubbleText });
                                }
                            }
                        }
                    }
                    else
                    {
                        entity.Destroy();
                        _world.NewEntity().Replace(new NavigationBack());
                    }
                }
            }
        }

        private void OnDialogResponse_Click(DialogChoiceButton_Click e)
        {
            foreach (var i in _communicationFilter)
            {
                _communicationFilter.GetEntity(i).Replace(new ChoiceSelected
                {
                    ChoiceIndex = e.ChoiceIndex,
                    CurrentDropDownIndex = e.CurrentDropDownIndex
                });
            }
        }
        
        private void OnCharacterScreenDropDownValueChanged(CharacterScreen_DropDownValueChanged e)
        {
            _dropDownValue = e.Value;
        }
    }
}