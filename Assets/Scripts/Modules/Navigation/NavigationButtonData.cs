using System.Linq;
using UnityEngine;

namespace Modules.Navigation
{
    public class NavigationButtonData
    {
        public Sprite Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyType { get; set; }
        public string ProgressTitle { get; set; }
        public float? Progress { get; set; }
        public bool ToggleActive { get; set; }
        public bool ToggleState { get; set; }
        public bool EnableState { get; set; }
        public bool SpecifyProgressColor { get; set; }
        public float ProgressFillColorValue { get; set; }

    }
}