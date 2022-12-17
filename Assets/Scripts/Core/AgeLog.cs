using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Save;

namespace Core
{
    public class AgeLog
    {
        private readonly int _lastRecordsCount;
        private readonly Dictionary<WorldDate, List<Record>> _log;
        
        private string _logStr;

        public AgeLog()
        {
            _log = new Dictionary<WorldDate, List<Record>>();
            _lastRecordsCount = 0;
        }

        public AgeLog(AgeLogSaveData saveData) : this()
        {
            foreach (var yearLogs in saveData.YearLogs)
            {
                _log.Add(yearLogs.WorldDate, yearLogs.Records.Select(r => new Record(r.Text, r.Priority)).ToList());
            }
        }

        public AgeLogSaveData GetAgeLogSaveData()
        {
            return new AgeLogSaveData(_log);
        }

        public string AsString(Person person)
        {
            if (_lastRecordsCount != _log.Sum(x => x.Value.Count))
            {
                _logStr = GenerateLogString(person);
            }

            return _logStr;
        }
        
        public void AddRecord(WorldDate date, Record record)
        {
            if (record.IsEmpty)
                return;
            
            if (!_log.TryGetValue(date, out var rec))
            {
                _log.Add(date, new List<Record>());
            }
            _log[date].Add(record);
        }

        private string GenerateLogString(Person person)
        {
            var sb = new StringBuilder();
            foreach (var ageLog in _log)
            {
                var isHalf = ageLog.Key.TotalMonths % WorldDate.MonthsInYear > 0;
                var ageForSelectedDate = ageLog.Key - person.BirthDate;
                sb.Append($"<b>{LocalizationDictionary.GetLocalizedString("age")}: " +
                    $"{ageForSelectedDate.TotalYears.ToString()} {LocalizationDictionary.GetLocalizedString("years")}" +
                    $"{(isHalf ? $" {ageForSelectedDate.Months.ToString()} {LocalizationDictionary.GetLocalizedString("months")}" : "")}</b>");
                sb.Append(Environment.NewLine);
                
                sb.Append(Environment.NewLine);
                var prioritizedRecords = ageLog.Value.OrderBy(r => r.Priority);
                foreach (var record in prioritizedRecords)
                {
                    sb.Append(record);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }

    [Serializable]
    public class Record
    {
        public const int DefaultPriority = 100;

        public int Priority { get; }
        public string Text { get; }

        public bool IsEmpty => string.IsNullOrEmpty(Text);
        
        public Record(string text, int priority = DefaultPriority)
        {
            Text = text?.Replace("\n", "").Replace("\r", "");
            Priority = priority;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}