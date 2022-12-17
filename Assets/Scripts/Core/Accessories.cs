using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Accessories
    {
        public Dictionary<string, int> AppliedAccessories;
        public Dictionary<string, int> ColorGroups;

        public Accessories()
        {
            AppliedAccessories = new Dictionary<string, int>();
            ColorGroups = new Dictionary<string, int>();
        }
        
        public Accessories(AccessoriesSave save)
        {
            AppliedAccessories = save?.AppliedAccessories.ToDictionary(x => x.Name, x => x.Index) ??
                                 new Dictionary<string, int>();
            ColorGroups = save?.ColorGroups.ToDictionary(x => x.Name, x => x.Index) ??
                          new Dictionary<string, int>();
        }
    }
    
    [Serializable]
    public class AccessoriesSave
    {
        public List<AppliedAccessoriesSave> AppliedAccessories;
        public List<ColorGroupsSave> ColorGroups;

        public AccessoriesSave()
        {
            AppliedAccessories = new List<AppliedAccessoriesSave>();
            ColorGroups = new List<ColorGroupsSave>();
        }

        public AccessoriesSave(Accessories accessories)
        {
            AppliedAccessories = accessories?.AppliedAccessories.Select(x => new AppliedAccessoriesSave
            {
                Name = x.Key,
                Index = x.Value
            }).ToList() ?? new List<AppliedAccessoriesSave>();
            ColorGroups = accessories?.ColorGroups.Select(x => new ColorGroupsSave
            {
                Name = x.Key,
                Index = x.Value
            }).ToList() ?? new List<ColorGroupsSave>();
        }
    }

    [Serializable]
    public class AppliedAccessoriesSave
    {
        public string Name;
        public int Index;
    }

    [Serializable]
    public class ColorGroupsSave
    {
        public string Name;
        public int Index;
    }
}