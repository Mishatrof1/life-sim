using System;
using System.Collections.Generic;
using Animations;
using Popups;
using Screens;
using UnityEngine;
using static Settings.AgeStageSettings;

namespace Settings
{
    [CreateAssetMenu(fileName = "PrefabSet", menuName = "PrefabSet", order = 0)]
    public class PrefabSet : ScriptableObject
    {
        public GameObject InformationFieldPrefab;
        public GameObject ProgressPrefab;
        public GameObject ActionButtonPrefab;
        public GameObject GroupSplitterPrefab;
        public GameObject BackPartPrefab;
        public GameObject BackPartBotPrefab;
        public GameObject BackPartTopPrefab;
        public DialogResponseButton DialogResponseButton;
        public Camera AnimatedIconCamera;
        
        [Space]
        public List<ScreenViewBase> ScreenPrefabs;
        public GameObject PopupsDarkBack;
        public List<PopupViewBase> PopupPrefabs;
        public List<ActivityButtonPrefab> ActivityButtonPrefabs;
        public List<FacePrefab> FacePrefabs;
    }
    
    [Serializable]
    public class ActivityButtonPrefab
    {
        public ActivityButtonType ButtonType;
        public GameObject Prefab;
    }

    [Serializable]
    public class FacePrefab
    {
        public AgeStage AgeStage;
        public AnimatedFace FaceAnimPrefab;
    }

}