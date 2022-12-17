using Core;
using Settings.Education;

namespace Components.Events
{
    public struct StudyDirectionSelected
    {
        public Service Service { get; set; }
        public StudyDirection StudyDirection { get; set; }
    }
}