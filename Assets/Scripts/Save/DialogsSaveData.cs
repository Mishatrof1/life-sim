using System;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    [CreateAssetMenu]
    public class DialogsSaveData : SaveData
    {
        public List<DialogSaveData> Dialogs;
        
        
        public override void ResetSaveData()
        {
            Dialogs = new List<DialogSaveData>();
        }
    }
    
    [Serializable]
    public class DialogSaveData
    { 
        public int DialogIndex;
        public int NodeIndex;
        public List<string> Participants;
    }
}
