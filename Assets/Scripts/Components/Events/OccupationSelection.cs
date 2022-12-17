namespace Components.Events
{
    public struct OccupationSelected
    {
        public string CharacterId { get; set; }
        public OccupationSelectionType Type { get; set; }
    }

    public enum OccupationSelectionType
    {
        Skip,
        College,
        University,
        Job, 
        Army
    }
}