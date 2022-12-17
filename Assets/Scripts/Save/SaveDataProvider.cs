using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Save
{
    [CreateAssetMenu(fileName = "SaveDataProvider", menuName = "SaveDataProvider", order = 0)]
    public class SaveDataProvider : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private string _filePrefix;
        [SerializeField] private string _fileExtention;

        private string FilePath(string instanceId)
        {
            return Path.Combine(Application.persistentDataPath,
                $"{_filePrefix}{(!string.IsNullOrEmpty(_filePrefix) ? "_" : "")}{instanceId}.{_fileExtention}");
        }

        public List<SaveData> SaveDataList;

        [ContextMenu("Save")]
        public void Save()
        {
            if (SaveDataList == null)
                return;

            foreach (var state in SaveDataList)
            {
                var jsonString = JsonUtility.ToJson(state);
                File.WriteAllText(FilePath(state.InstanceId), jsonString);   
            }
        }

        [ContextMenu("Load")]
        public void Load()
        {
            if (SaveDataList == null)
                return;
            
            foreach (var state in SaveDataList)
            {
                if (!File.Exists(FilePath(state.InstanceId)))
                {
                    state.ResetSaveData();
                        continue;
                }
                
                var jsonString = File.ReadAllText(FilePath(state.InstanceId));
                JsonUtility.FromJsonOverwrite(jsonString, state);
            }
        }
#if UNITY_EDITOR
        [ContextMenu("Clear")]
        public void Clear()
        {
            ResetSaveData();
            Save();
        }
#endif

        public void ResetSaveData()
        {
            foreach (var state in SaveDataList)
            {
                state.ResetSaveData();
            }
        }

        public T GetSaveData<T>() where T : SaveData
        {
            return SaveDataList.OfType<T>().First();
        }

        public void OnBeforeSerialize()
        {
            SaveDataList.ForEach(sd =>
            {
                if (sd == null)
                    return;
                sd.OnBeforeSerialize();
            });
        }

        public void OnAfterDeserialize()
        {
            SaveDataList.ForEach(sd =>
            {
                if (sd == null)
                    return;
                sd.OnAfterDeserialize();
            });
        }
    }
}