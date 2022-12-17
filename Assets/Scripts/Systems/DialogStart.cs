using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using DialogSystem;
using Leopotam.Ecs;
using Save;
using Settings;

namespace Systems
{
    public class DialogStart : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Created, CharacterComponent> _characterCreatedFilter;
        private EcsFilter<StartDialog> _startDialogFilter;
        
        private SaveDataProvider _saveDataProvider;
        private DialogsSet _dialogsSet;
        
        private DialogsSaveData _dialogSystemSaveData;

        public void Init()
        {
            _dialogSystemSaveData = _saveDataProvider.GetSaveData<DialogsSaveData>();
        }

        public void Run()
        {
            foreach (var i in _startDialogFilter)
            {
                ref var entity = ref _startDialogFilter.GetEntity(i);
                ref var startDialog = ref entity.Get<StartDialog>();
                _dialogSystemSaveData.Dialogs.Add(new DialogSaveData()
                {
                    DialogIndex = _dialogsSet.DialogNodeGraphs.IndexOf(startDialog.Dialog),
                    NodeIndex = startDialog.Dialog.nodes.IndexOf(startDialog.Dialog.nodes.Cast<DialogNode>().First(n => n.IsStartNode())),
                    Participants = startDialog.Participants
                });

                entity.Destroy();
            }
            
            foreach (var i in _characterCreatedFilter)
            {
                var character = _characterCreatedFilter.Get2(i).Character;
                foreach (var graph in _dialogsSet.DialogNodeGraphs)
                {
                    if (graph is RequiredDialog &&
                        (((RequiredDialog)graph).CharacterGender == character.Gender ||
                         ((RequiredDialog)graph).CharacterGender == Genders.any))
                    {
                        _world.NewEntity().Replace(new StartDialog
                        {
                            Dialog = graph,
                            Participants = new List<string>
                            {
                                character.Id
                            }
                        });
                    }
                }

            }
        }
    }
}
