using System.Collections.Generic;

namespace DialogSystem
{
    public class ConditionalDialog : DialogNodeGraph
    {
        public int CharacterAge;
        public Genders CharacterGender;
        
        public override List<DialogParticipantType> ParticipantTypes => new List<DialogParticipantType>
        {
            DialogParticipantType.Character
        };
    }
}