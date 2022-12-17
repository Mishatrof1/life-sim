using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Save
{
    [Serializable]
    public class AgeLogSaveData
    {
        public List<YearLog> YearLogs;
        
        public AgeLogSaveData(Dictionary<WorldDate, List<Record>> yearLogs)
        {
            YearLogs = new List<YearLog>();
            foreach (var yearLog in yearLogs)
            {
                YearLogs.Add(new YearLog
                {
                    WorldDate = yearLog.Key,
                    Records = yearLog.Value.Select(r => new RecordSaveData
                    {
                        Priority = r.Priority,
                        Text = r.Text
                    }).ToList()
                });
            }
        }
    }

    [Serializable]
    public class YearLog
    {
        public WorldDate WorldDate;
        public List<RecordSaveData> Records;
    }

    [Serializable]
    public class RecordSaveData
    {
        public int Priority;
        public string Text;
    }
}