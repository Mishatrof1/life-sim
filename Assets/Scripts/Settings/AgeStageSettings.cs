using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "AgeStageSettings", menuName = "LifeSim/AgeStageSettings", order = 0)]
    public class AgeStageSettings : ScriptableObject
    {
        public enum AgeStage
        {
            Default,
            Baby,
            Child,
            Teenager,
            Adult,
            Old
        }

        [SerializeField] private List<AgeStageSetting> _stages;
        public List<AgeStageSetting> Stages => _stages;

        public AgeStageSetting GetAgeStageSetting(int age)
        {
            foreach (AgeStageSetting stage in _stages)
            {
                if (Mathf.Clamp(age, stage.YearMin, stage.YearMax) == age)
                    return stage;
            }
            return null;
        }

        [Serializable]
        public class AgeStageSetting
        {
            [SerializeField] private AgeStage _ageStage;
            [SerializeField] private int _yearMin;
            [SerializeField] private int _yearMax;
            [SerializeField] private Sprite _dummySpriteMale;
            [SerializeField] private Sprite _dummySpriteFemale;

            public AgeStage AgeStage => _ageStage;
            public int YearMin => _yearMin;
            public int YearMax => _yearMax;
            public Sprite DummySpriteMale => _dummySpriteMale;
            public Sprite DummySpriteFemale => _dummySpriteFemale;

        }

    }

}


