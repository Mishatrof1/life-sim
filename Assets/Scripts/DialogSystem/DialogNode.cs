using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DialogSystem
{
    public struct Connection
    {
    }

    [NodeWidth(500)]
    public class DialogNode : Node
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Connection Enter;

        public string Label;
        [TextArea(8, 500)] public string MessageText;
        [Output(dynamicPortList = true)] public List<Response> Responses = new List<Response>();
        public List<ConditionType> ListConditions = new List<ConditionType>();
        public int AgeCondition;
        public int RelationMin;
        public int RelationMax;
        public int SexualityCondition;

        public List<Result> Results = new List<Result>();

        public bool IsStartNode()
        {
            return !GetInputPort("Enter").IsConnected;
        }
    }

    [Serializable]
    public class Result
    {
        public ParameterResultType ResultType;
        public int ParticipantIndex;
        public int HappinessChange;
        public int LookChange;
        public int SmartChange;
        public int HealthChange;
        public int MoneyChange;
        public int RelationshipChange;
        public TypeOfOccupation TypeOfOccupation;
        public RelationshipType relationshipType;
    }

    [Serializable]
    public class Response
    {
        public string Label;
    }

    public enum ParameterResultType
    {
        Happiness,
        Look,
        Smart,
        Health,
        Occupation,
        Money,
        Relationship,
        RelationshipType
    }
    public enum TypeOfOccupation
    {
       PrimarySchool,
       MiddleSchool,
       HighSchool,
       University
    }
}