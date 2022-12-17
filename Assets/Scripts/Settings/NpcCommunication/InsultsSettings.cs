using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Components;
using Core;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Settings.NpcCommunication
{
    [CreateAssetMenu]
    public class InsultsSettings : CommunicationSettings<Insult>
    {
        [SerializeField] private string _screenTitle;

        public double MainValue;
        public string MainMatrix;
        public string BaseChangeMatrix;
        public double BaseRelCoefficient1;
        public double BaseRelCoefficient2;
        public double BaseRelCoefficient3;
        public double BaseRelCoefficient4;
        public double BasePower;
        public double BaseHappCoefficient1;
        public double BaseHappCoefficient2;
        public double BaseHappCoefficient3;
        public List<Insult> Insults;

        public override List<Insult> Communications => Insults;
        public string ScreenTitle => _screenTitle;

    }

    [Serializable]
    public class Insult : CommunicationChoiceSettings
    {
        public string ChangeMatrix;
        public double Sentiment;
        public double Politeness;
        public double Formality;
        public double RelCoefficient1;
        public double RelCoefficient2;
        public double RelCoefficient3;
        public double RelCoefficient4;
        public double Power;
        public double HappCoefficient1;
        public double HappCoefficient2;
        public double HappCoefficient3;
    }

}