using System;
using System.Globalization;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using UnityEngine;
using Random = System.Random;

public static class Utils
{
    public static Matrix<double> ParseMatrix(string matrixString)
    {
        var rows = matrixString.Split('!');
        var columnsLength = rows[0].Split(' ').Length;
        var array = new double[rows.Length, columnsLength];
        for (var i = 0; i < rows.Length; i++)
        {
            var col = rows[i].Split(' ');
            for (var j = 0; j < columnsLength; j++)
            {
                array[i, j] = double.Parse(col[j], CultureInfo.InvariantCulture);
            }
        }
        return DenseMatrix.OfArray(array);
    }
    
    public static double Cqrt(double value)
    {
        return value >= 0 ? Math.Pow(value, 1d / 3d) : -Math.Pow(Math.Abs(value), 1d / 3d);
    }
        
    public static double Pow(double value, double pow)
    {
        return value >= 0 ? Math.Pow(value, pow) : -Math.Pow(Math.Abs(value), pow);
    }

    public static string ToMoneyString(this float value)
    {
        return $"${value.ToString("N0", new CultureInfo("en-US"))}";
    }

    public static bool InRange(this float value, float a, float b, bool includeFirst = false, bool includeSecond = false)
    {
        if (includeFirst && (a - value) < Mathf.Epsilon)
        {
            return true;
        }
        if (includeSecond && (b - value) < Mathf.Epsilon)
        {
            return true;
        }
        return value > a && value < b;
    }
    
    public static float NormalDistribution(float min, float max, float mean, float stdDev)
    {
        return SkewDistribution(min, max, mean, stdDev, 0);
    }
        
    public static float SkewDistribution(float min, float max, float mean, float stdDev, float skew)
    {
        if (skew >= 1 || skew <= -1)
        {
            throw new ArgumentException("Skew parameter must be between -1 and 1");
        }

        if (mean > max || mean < min)
        {
            throw new ArgumentException($"Mean parameter must be between {nameof(min)}({min}) and {nameof(max)}({max})");
        }
            
        var pattern = new SkewedGeneralizedT();
        var skewDistribution = new SkewedGeneralizedT(mean, stdDev, skew, pattern.P, pattern.Q);
        return Mathf.Clamp((float)skewDistribution.Sample(), min, max);
    }
}