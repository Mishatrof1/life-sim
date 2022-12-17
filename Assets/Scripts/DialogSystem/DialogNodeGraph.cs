using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DialogSystem
{
    [CreateAssetMenu]
    public class DialogNodeGraph : NodeGraph
    {

        public virtual List<DialogParticipantType> ParticipantTypes => new List<DialogParticipantType>
        {
            DialogParticipantType.Character
        };
    }
}