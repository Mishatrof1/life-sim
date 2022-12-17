using Settings.Job.Simple;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MilitaryConfig", menuName = "LifeSim/Army/MilitaryConfig", order = 0)]
public class MilitaryConfig : ScriptableObject
{
    public ArmyConfiguration[] armyConfig;
}
