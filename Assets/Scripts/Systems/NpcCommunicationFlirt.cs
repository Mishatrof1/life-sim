using System.Collections.Generic;
using Components;
using Components.Events;
using Components.Navigation;
using Core.NpcCommunication;
using DialogSystem;
using Extensions;
using Leopotam.Ecs;
using Modules.Navigation;
using Settings.NpcCommunication;

namespace Systems
{
    public class NpcCommunicationFlirt : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsFilter<Components.NpcCommunication> _communicationFilter;
        private EcsFilter<BlockComponent, Active> _navigationFilter;
        
        private ReactionsSettings _reactionsSettings;

        public void Init()
        {
            EventSystem.Subscribe<DialogChoiceButton_Click>(OnDialogResponse_Click);
        }
        
        public void Destroy()
        {
            EventSystem.Unsubscribe<DialogChoiceButton_Click>(OnDialogResponse_Click);
        }
        
        public void Run()
        {
            foreach (var i in _communicationFilter)
            {
                ref var communication = ref _communicationFilter.Get1(i);
                var entity = _communicationFilter.GetEntity(i);

                if (!(communication.Communication is FlirtCommunication))
                    continue;
                
                if (_navigationFilter.GetCurrentPoint(NavigationBlockType.Main)?.Type != NavigationElementType.FlirtInteraction)
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
                    entity.Replace(new ChoicesChanged
                    {
                        Message = communication.Communication.GetTopText(communication.Npc),
                        ButtonChoices = communication.Communication.GenerateChoices(communication.Npc)
                    });
                }
                
                if (entity.Has<ChoiceSelected>())
                {
                    if (!communication.Final)
                    {
                        var selectedIndex = entity.Get<ChoiceSelected>().ChoiceIndex;
                        foreach (var charCompIndex in _charactersFilter)
                        {
                            var character = _charactersFilter.Get1(charCompIndex).Character;
                            if (character.Id == communication.Character.Id)
                            {
                                foreach (var npcComIndex in _npcFilter)
                                {
                                    var npc = _npcFilter.Get1(npcComIndex).Npc;
                                    if (npc.Id == communication.Npc.Id)
                                    {
                                        EventSystem.Send(new BubbleTextComponent
                                        {
                                            BubbleTextValue = communication.Communication.HandleSelectedChoice(selectedIndex,
                                                ref _charactersFilter.GetEntity(charCompIndex),
                                                ref _npcFilter.GetEntity(npcComIndex),
                                                out var description)
                                        });
                                        
                                        communication.Final = true;
                                        _communicationFilter.GetEntity(i)
                                            .Replace(new ChoicesChanged
                                            {
                                                Message = description,
                                                ButtonChoices = new List<CommunicationChoice>
                                                {
                                                    new CommunicationChoice
                                                    {
                                                        Index = 0,
                                                        Text = LocalizationDictionary.GetLocalizedString("ok")
                                                    }
                                                }
                                            });
                                    }
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
                _communicationFilter.GetEntity(i).Replace(new ChoiceSelected {ChoiceIndex = e.ChoiceIndex});
            }
        }
    }
}