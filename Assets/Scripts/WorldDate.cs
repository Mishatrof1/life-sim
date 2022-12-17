using System;
using UnityEngine;

[Serializable]
public struct WorldDate : IEquatable<WorldDate>
{
    public static int MonthsInYear => 12;
    public static int WeeksInMonths => 4;

    public static WorldDate FromMonths(int months)
    {
        return new WorldDate() {_totalMonths = months};;
    }

    public static WorldDate FromYears(int years)
    {
        return new WorldDate() {_totalMonths = years * MonthsInYear};
    }
        
    public int Months => TotalMonths - TotalYears * MonthsInYear;
    [SerializeField] private int _totalMonths;
    public int TotalMonths => _totalMonths;
    public int TotalYears => _totalMonths / MonthsInYear;

    public static WorldDate operator +(WorldDate a, WorldDate b)
    {
        return FromMonths(a.TotalMonths + b.TotalMonths);
    }
        
    public static WorldDate operator -(WorldDate a, WorldDate b)
    {
        return FromMonths(a.TotalMonths - b.TotalMonths);
    }

    public bool Equals(WorldDate other)
    {
        return _totalMonths == other._totalMonths;
    }

    public override bool Equals(object obj)
    {
        return obj is WorldDate other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _totalMonths;
    }
}