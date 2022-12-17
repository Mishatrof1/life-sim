using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu]
    public class ZodiacSettings : ScriptableObject
    {
        [Serializable]
        public struct ZodiacSign
        {
            public string signName;

            public int monthMin;
            public int dayMin;

            public int monthMax;
            public int dayMax;

            public bool CheckDate(DateTime date)
            {
                bool comp1 = date.Month == monthMin && date.Day >= dayMin;
                bool comp2 = date.Month == monthMax && date.Day <= dayMax;
                return comp1 || comp2;
            }

            public override string ToString() => signName;

        }

        [SerializeField] private List<ZodiacSign> zodiacs;

        public ZodiacSign CalculateSign(DateTime birthday)
        {
            foreach (ZodiacSign z in zodiacs)
            {
                if (z.CheckDate(birthday)) return z;
            }
            return new ZodiacSign();
        }

    }
}

