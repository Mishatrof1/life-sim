using System;

namespace Core
{
    public class ColorGroupState
    {
        public int Index;
    }

    [Serializable]
    public class ColorGroupStateSave
    {
        public string Type;
        public int Index;
    }
}