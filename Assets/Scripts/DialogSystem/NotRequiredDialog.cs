using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu]
    public class NotRequiredDialog : DialogNodeGraph
    {
        public Genders CharacterGender;
        public override List<DialogParticipantType> ParticipantTypes => new List<DialogParticipantType>
        {
            DialogParticipantType.Character
        };
    }
}
