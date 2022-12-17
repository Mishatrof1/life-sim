using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Core;
using Leopotam.Ecs;
using Modules;
using Popups;
using UnityEngine;

namespace Systems
{
    public class RelationshipProcessing : IEcsRunSystem
    {
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsWorld _world;

        public void Run()
        {
            if (_nextIterationFilter.IsEmpty())
                return;

            foreach (var charIndex in _characterFilter)
            {
                var character = _characterFilter.Get1(charIndex).Character;
                foreach (var i in _npcFilter)
                {
                    var npc = _npcFilter.Get1(i).Npc;
                    var relation = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                    var sympathy = npc.Parameters.Get(ParameterType.Sympathy.ToString());
                    var relationship = npc.Parameters.Get(ParameterType.Relationship.ToString());
                    
                    if (relation != null)
                    {
                        if (relation.RelationshipType == RelationshipType.Lover && sympathy.Value < 30)
                            npc.Relationships.Remove(relation);

                        if (relation.RelationshipType == RelationshipType.Friend)
                        {
                            if (relationship.Value < 5)
                            {
                                npc.UnFriendYearsCount++;
                            } else
                            {
                                npc.UnFriendYearsCount = 0;
                            }
                        }
                    }

                    if (npc.FlirtProgress.LastFlirtWorldDate.HasValue &&
                        (WorldDateModule.CurrentDate - npc.FlirtProgress.LastFlirtWorldDate.Value).TotalYears < 5 &&
                        SympathyDownNormalizationIsRequired(npc.DateYearCount + npc.SexYearCount, sympathy.Value))
                    {
                        sympathy.OffsetToTarget(0, 0.18f, OffsetToTargetMode.Down);
                    }

                    if (RelationshipDownNormalizationIsRequired(
                        npc.ComplimentYearCount + npc.CommunicationYearCount + npc.SpendTimeYearCount +
                        npc.GiftYearCount + npc.PositiveStoryYearCount, relationship.Value))
                    {
                        relationship.OffsetToTarget(0, 0.1f, OffsetToTargetMode.Down);
                    }

                    if (RelationshipUpNormalizationIsRequired(
                        npc.InsultYearCount + npc.FightYearCount + npc.NegativeStoryYearCount, relationship.Value))
                    {
                        relationship.OffsetToTarget(0, 0.1f, OffsetToTargetMode.Up);
                    }
                }
            }
        }

        private bool SympathyDownNormalizationIsRequired(int totalValue, float sympathy)
        {
            return sympathy switch
            {
                { } s when (s > 30 && s <= 55) => totalValue < 5,
                { } s when (s > 55 && s <= 80) => totalValue < 3,
                { } s when (s > 80 && s <= 100) => totalValue < 1,
                _ => false
            };
        }
        
        private bool RelationshipDownNormalizationIsRequired(int totalValue, float relationship)
        {
            return relationship switch
            {
                { } s when (s > 0 && s <= 25) => totalValue < 10,
                { } s when (s > 25 && s <= 50) => totalValue < 6,
                { } s when (s > 50 && s <= 75) => totalValue < 3,
                { } s when (s > 75 && s <= 100) => totalValue < 1,
                _ => false
            };
        }
        
        private bool RelationshipUpNormalizationIsRequired(int totalValue, float relationship)
        {
            return relationship switch
            {
                { } s when (s >= -100 && s <= -50) => totalValue < 2,
                { } s when (s > -50 && s <= 0) => totalValue < 1,
                _ => false
            };
        }

    }
}