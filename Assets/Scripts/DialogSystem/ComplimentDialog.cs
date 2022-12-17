﻿using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu]
    public class ComplimentDialog : DialogNodeGraph
    {
        public Genders CharacterGender;
        public int CharacterMinAge;
        public int CharacterMaxAge;
        public Genders ParticipantGender;
        public int ParticipantMinAge;
        public int ParticipantMaxAge;

        public override List<DialogParticipantType> ParticipantTypes => new List<DialogParticipantType>
        {
            DialogParticipantType.Character,
            DialogParticipantType.Npc
        };
    }
}