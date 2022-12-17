using System;
using System.Collections.Generic;
using System.Linq;
using Settings;
using Settings.Appearance;

namespace Core
{
    public class Appearance
    {
        public Dictionary<string, AppearanceGroupState> AppearanceGroupsState;
        public Dictionary<string, ColorGroupState> ColorGroupsState;

        public Appearance()
        {
            AppearanceGroupsState = new Dictionary<string, AppearanceGroupState>();
            ColorGroupsState = new Dictionary<string, ColorGroupState>();
        }

        public Appearance(AppearanceSave appearanceSave)
        {
            AppearanceGroupsState =
                appearanceSave.AppearanceGroupsState.ToDictionary(ags => ags.Type, ags => new AppearanceGroupState
                {
                    Index = ags.Index
                });
            ColorGroupsState =
                appearanceSave.ColorGroupsStateSave.ToDictionary(cgs => cgs.Type, cgs => new ColorGroupState
                {
                    Index = cgs.Index
                });
        }
    }

    [Serializable]
    public class AppearanceSave
    {
        public List<AppearanceGroupStateSave> AppearanceGroupsState;
        public List<ColorGroupStateSave> ColorGroupsStateSave;

        public AppearanceSave(Appearance appearance)
        {
            AppearanceGroupsState = appearance.AppearanceGroupsState.Select(agss => new AppearanceGroupStateSave
            {
                Type = agss.Key,
                Index = agss.Value.Index
            }).ToList();
            ColorGroupsStateSave = appearance.ColorGroupsState.Select(cgss => new ColorGroupStateSave
            {
                Type = cgss.Key,
                Index = cgss.Value.Index
            }).ToList();
        }
    }

    public class AppearanceGroupState
    {
        public int Index;
    }

    [Serializable]
    public class AppearanceGroupStateSave
    {
        public string Type;
        public int Index;
    }
}