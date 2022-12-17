using System.Collections.Generic;
using Leopotam.Ecs;
using Save;

namespace Systems
{
    public class DialogInit : IEcsInitSystem
    { 
        private SaveDataProvider _saveDataProvider;

        public void Init()
        {
            var _dialogSystemSaveData = _saveDataProvider.GetSaveData<DialogsSaveData>();
            _dialogSystemSaveData.Dialogs ??= new List<DialogSaveData>();
        }
    }
}
