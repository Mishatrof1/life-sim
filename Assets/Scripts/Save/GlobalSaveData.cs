using UnityEngine;

namespace Save
{
    [CreateAssetMenu()]
    public class GlobalSaveData : SaveData
    {
        public WorldDate CurrentDate;
        public bool SoundState;
        public SystemLanguage savedLanguage;

        public override void ResetSaveData()
        {
            CurrentDate = new WorldDate();
            SoundState = true;
            savedLanguage = SystemLanguage.English;
        }
    }
}