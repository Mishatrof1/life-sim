using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Leopotam.Ecs;
using Settings.NpcCommunication;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using UnityEngine;
using Random = System.Random;
using Extensions;

namespace Core.NpcCommunication
{
    public class InsultsCommunication : Communication<InsultsSettings, ReactionsSettings>
    {
        public InsultsCommunication(InsultsSettings communicationSettings, ReactionsSettings reactionSettings)
            : base(communicationSettings, reactionSettings)
        {
        }

        public override string GetTopText(Npc npc)
        {
            return _communicationSettings.ScreenTitle.Enrich(npc);
        }

        public override List<CommunicationChoice> GenerateChoices(Npc npc)
        {
            return _communicationSettings.SelectRandomChoices(ChoiceCount, npc);
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity)
        {
            var npc = npcEntity.Get<NpcComponent>().Npc;
            var communication = _communicationSettings.Communications[choiceIndex];
            
            Matrix<double> baseMatrix = Utils.ParseMatrix(_communicationSettings.MainMatrix);
            Matrix<double> npcMatrix = DenseMatrix.OfArray(new double[,]
            {
                {
                    npc.Parameters.Get(ParameterType.Kindness.ToString()).Value,
                    npc.Parameters.Get(ParameterType.Conformity.ToString()).Value,
                    npc.Parameters.Get(ParameterType.Optimism.ToString()).Value,
                    npc.Parameters.Get(ParameterType.Extroversion.ToString()).Value,
                    npc.Parameters.Get(ParameterType.Happiness.ToString()).Value
                }
            });

            var changeMatrix = Utils.ParseMatrix(string.IsNullOrEmpty(communication.ChangeMatrix)
                ? _communicationSettings.BaseChangeMatrix
                : communication.ChangeMatrix);

            Matrix<double> payloadParametersMatrix = DenseMatrix.OfArray(new double[,]
            {
                {communication.Sentiment},
                {communication.Politeness},
                {communication.Formality}
            });

            var baseValue = _communicationSettings.MainValue;
            var decreaseValue = 0d;
            var relCoeff1 = communication.RelCoefficient1 != 0 ? communication.RelCoefficient1 : _communicationSettings.BaseRelCoefficient1;
            var relCoeff2 = communication.RelCoefficient2 != 0 ? communication.RelCoefficient2 : _communicationSettings.BaseRelCoefficient2;
            var relCoeff3 = communication.RelCoefficient3 != 0 ? communication.RelCoefficient3 : _communicationSettings.BaseRelCoefficient3;
            var relCoeff4 = communication.RelCoefficient4 != 0 ? communication.RelCoefficient4 : _communicationSettings.BaseRelCoefficient4;
            var power = communication.Power != 0 ? communication.Power : _communicationSettings.BasePower;
            
            var happCoeff1 = communication.HappCoefficient1 != 0 ? communication.HappCoefficient1 : _communicationSettings.BaseHappCoefficient1;
            var happCoeff2 = communication.HappCoefficient2 != 0 ? communication.HappCoefficient2 : _communicationSettings.BaseHappCoefficient2;
            var happCoeff3 = communication.HappCoefficient3 != 0 ? communication.HappCoefficient3 : _communicationSettings.BaseHappCoefficient3;
            
            var deltaRelationshipNpc = DialogChoiceRelationshipDelta(baseValue, decreaseValue, power,
                npcMatrix, baseMatrix, changeMatrix, payloadParametersMatrix,
                relCoeff1, relCoeff2, relCoeff3, relCoeff4);

            if (deltaRelationshipNpc > 0)
            {
                deltaRelationshipNpc = 0;
            }
            var deltaHappinessCharacter = DialogChoiceHappinessDeltaCharacter(baseValue, deltaRelationshipNpc, decreaseValue,
                happCoeff1, happCoeff2);
            
            var deltaHappinessNpc = DialogChoiceHappinessDeltaNpc(baseValue, deltaRelationshipNpc, decreaseValue,
                happCoeff1, happCoeff3);

            npcEntity.Replace(new ChangeStatsComponent
            {
                ChangeStats = new List<ChangeStats>
                {
                    new ChangeStats
                    {
                        ParameterId = ParameterType.Relationship.ToString(),
                        Value = (float)deltaRelationshipNpc
                    },
                    new ChangeStats
                    {
                        ParameterId = ParameterType.Happiness.ToString(),
                        Value = (float)deltaHappinessNpc
                    }
                }
            });
            characterEntity.Replace(new ChangeStatsComponent
            {
                ChangeStats = new List<ChangeStats>
                {
                    new ChangeStats
                    {
                        ParameterId = ParameterType.Happiness.ToString(),
                        Value = (float)deltaHappinessCharacter
                    }
                }
            });

            var reactionPool =
                _reactionSettings.ReactionsPools.First(rp =>
                    deltaRelationshipNpc > rp.Min && deltaRelationshipNpc <= rp.Max);
            return reactionPool.Reactions[new Random(DateTime.Now.Millisecond).Next(0, reactionPool.Reactions.Count)];
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity characterEntity, ref EcsEntity npcEntity,
            out string description)
        {
            throw new NotImplementedException();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity)
        {
            throw new NotImplementedException();
        }

        public override string HandleSelectedChoice(int choiceIndex, ref EcsEntity communicationEntity, ref EcsEntity characterEntity,
            ref EcsEntity npcEntity, out string description)
        {
            throw new NotImplementedException();
        }

        public override string GetChoiceText(int choiceIndex, Npc npc)
        {
            return _communicationSettings.Communications[choiceIndex].GetActualText(npc);
        }

        private double DialogChoiceRelationshipDelta(double baseValue, double decreaseValue, double power,
            Matrix<double> npcMatrix, Matrix<double> baseMatrix, Matrix<double> changeMatrix, Matrix<double> payloadMatrix,
            double coeff1, double coeff2, double coeff3, double coeff4)
        {
            var value = Utils.Pow((coeff4 * (npcMatrix * (changeMatrix + baseMatrix) * payloadMatrix)[0, 0]), power);
            return baseValue + coeff1 + coeff3 * coeff2 * value + decreaseValue;
        }

        private double DialogChoiceHappinessDeltaCharacter(double baseValue, double relationshipDelta, double decreaseValue,
            double coeff1, double coeff2)
        {
            return coeff1 * Utils.Cqrt(relationshipDelta + coeff2) + decreaseValue;
        }
        
        private double DialogChoiceHappinessDeltaNpc(double baseValue, double relationshipDelta, double decreaseValue,
            double coeff1, double coeff2)
        {
            return coeff1 * Utils.Cqrt(relationshipDelta) + coeff2 + decreaseValue;
        }
    }
}