using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Save;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Parameters
{
    private Dictionary<string, Parameter> _parameters;

    public Parameters()
    {
        _parameters = new Dictionary<string, Parameter>();
    }

    public void Add(string id, Parameter parameter)
    {
        if (!_parameters.ContainsKey(id))
            _parameters.Add(id, parameter);
    }

    public Parameter Get(string id)
    {
        return _parameters.TryGetValue(id, out var value)
            ? value
            : default;
    }

    public List<ParameterSaveData> SaveList()
    {
        return _parameters.Select(p => new ParameterSaveData(p.Key, p.Value)).ToList();
    }
    
    public void Restore(List<ParameterSaveData> saveData)
    {
        _parameters = saveData.ToDictionary(x => x.Id, x => new Parameter(x));
    }
}

public class Parameter
{
    public float Min { get; }
    public float Max { get; }
    public float Value { get; private set; }
    public float NormalizedValue => (Value - Min) / (Max - Min);

    public Parameter(float value, float? min = null, float? max = null)
    {
        Min = min ?? float.MinValue;
        Max = max ?? float.MaxValue;
        SetValue(value);
    }
    
    public Parameter() : this(0)
    {
    }

    public Parameter(ParameterSaveData saveData)
        : this(saveData.Value, saveData.Min, saveData.Max)
    {
    }

    public void Set(float value)
    {
        SetValue(value);
    }
    
    public void Inc(float value)
    {
        SetValue(Value += value);
    }
    
    public void Dec(float value)
    {
        SetValue(Value -= value);
    }

    private void SetValue(float value)
    {
        Value = Mathf.Clamp(value, Min, Max);
    }

    public void OffsetToTarget(float target, float offsetMultiplier, OffsetToTargetMode mode = OffsetToTargetMode.DoubleSide)
    {
        var distance = target - Value;
        var result = Value + distance * offsetMultiplier;

        switch (mode)
        {
            case OffsetToTargetMode.Up:
            {
                if (Value > target)
                    return;
                
                Value = Mathf.Min(target, result);
                return;
            }
            case OffsetToTargetMode.Down:
            {
                if (Value < target)
                    return;
                
                Value = Mathf.Max(target, result);
                return;
            }
            case OffsetToTargetMode.DoubleSide:
            {
                Value = target < Value ? Mathf.Max(target, result) : Mathf.Min(target, result);
                return;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }
}

public enum OffsetToTargetMode
{
    Up,
    Down,
    DoubleSide
}