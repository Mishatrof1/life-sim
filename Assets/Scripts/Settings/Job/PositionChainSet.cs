using System;
using System.Collections.Generic;
using System.Linq;
using Core.Job;
using UnityEngine;

namespace Settings.Job
{
    [CreateAssetMenu(fileName = "PositionChainSet", menuName = "LifeSim/Job/Position chain set")]
    public class PositionChainSet : ScriptableObject, IPositionChainSet
    {
        [SerializeField]
        private List<PositionChain> _chains;
        public List<PositionChain> Chains => _chains.Select(chain =>
        {
            chain.SetupPositions();
            return chain;
        }).ToList();

        public List<Position> GetAvailablePositions(OrganizationType employerType, ScopeType scopeType)
        {
            return Chains.SelectMany(chain => chain.Positions
                .Where(p => p.AvailableEmployers.Any(ae => ae == employerType) &&
                            p.AvailableScopes.Any(avScope => avScope == scopeType))).ToList();
        }
    }
    
    [Serializable]
    public class PositionChain
    {
        public string Title;
        public List<Position> Positions;

        public void SetupPositions()
        {
            Positions.ForEach(pos => pos.Chain = this);
        }
    }

    [Serializable]
    public class Position
    {
        public string Title;
        public Sprite Icon;
        public float BaseSalary;
        /// <summary>
        /// Коэффициент для определения возможности повышения
        /// </summary>
        public float IncreaseFactor;
        /// <summary>
        /// Коэффициент для определения необходимости увольнения
        /// </summary>
        //public float ProductivityThreshold;
        public List<ScopeType> AvailableScopes;
        public List<OrganizationType> AvailableEmployers;
        public List<SkillType> IncreaseSkills;
        public List<SkillValue> RequiredSkills;
        public int RequiredExperience;
        public EducationResultType RequiredEducation;

        public PositionChain Chain { get; set; }

        public Position PreviousPosition(OrganizationType employerType, ScopeType scopeType)
        {
            var availablePositions = Chain.Positions.Where(pos =>
                pos.AvailableEmployers.Any(employer => employer == employerType) &&
                pos.AvailableScopes.Any(scope => scope == scopeType)).ToList();
            
            var currentPositionIndex = availablePositions.IndexOf(this);
            return currentPositionIndex > 0
                ? availablePositions[currentPositionIndex - 1]
                : null;
        }
        
        public Position NextPosition(OrganizationType employerType, ScopeType scopeType)
        {
            var availablePositions = Chain.Positions.Where(pos =>
                pos.AvailableEmployers.Any(employer => employer == employerType) &&
                pos.AvailableScopes.Any(scope => scope == scopeType)).ToList();
            
            var currentPositionIndex = availablePositions.IndexOf(this);
            return currentPositionIndex < availablePositions.Count - 1
                ? availablePositions[currentPositionIndex + 1]
                : null;
        }
    }

    [Serializable]
    public class SkillValue
    {
        public SkillType Type;
        public float Value;
    }

    public interface IPositionChainSet
    {
        public List<PositionChain> Chains { get; }
    }
}