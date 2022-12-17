using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Modules.Navigation;
using UnityEngine;

namespace Save
{
    [CreateAssetMenu]
    public class NpcSaveData : SaveData
    {
        public List<NpcSave> Npcs;
        
        public override void ResetSaveData()
        {
            Npcs = new List<NpcSave>();
        }
    }

    [Serializable]
    public class NpcSave : PersonSave
    {
        public List<RelationshipSave> Relationships;
        public string CurrentOccupationId;
        public FlirtProgress FlirtProgress;
        public BefriendProgress BefriendProgress;
        
        public int ComplimentYearCount;
        public int CommunicationYearCount;
        public int SpendTimeYearCount;
        public int GiftYearCount;
        public int PositiveStoryYearCount;
        public int NegativeStoryYearCount;
        public int InsultYearCount;
        public int FightYearCount;
        public int DateYearCount;
        public int SexYearCount;
        public int UnFriendYearsCount;
    }

    [Serializable]
    public class RelationshipSave
    {
        public string Id;
        public RelationshipType RelationshipType;
    }
}