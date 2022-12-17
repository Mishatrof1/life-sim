using DialogSystem;

namespace Components
{
    public struct ApplyDialogResult
    {
        public string Participant;
        public DialogParticipantType ParticipantType;
        public ParameterResultType ResultType;
        public int ParticipantIndex;
        public int HappinessChange;
        public int LookChange;
        public int SmartChange;
        public int HealthChange;
        public int MoneyChange;
        public int RelationshipChange;
        public TypeOfOccupation OccupationChange;

        public RelationshipType relationshipType;
        public bool Unfriend;
    }
}