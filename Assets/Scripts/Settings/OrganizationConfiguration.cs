using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "OrganizationConfiguration", menuName = "LifeSim/OrganizationConfiguration", order = 0)]
    public class OrganizationConfiguration : ScriptableObject
    {
        public List<string> PossibleNames;
        public string TypeName;
        public Sprite Icon;
        public TypeOrg Type;
        public float Solvency;
        
        public void SetSolvency()
        {
            
            Solvency += Random.Range(-5, 10);
            if(Solvency >= 100)
            {
                if (Type != TypeOrg.Big)
                {
                    Type++;
                    Solvency = 0;
                }
            }else if(Solvency <= 0)
            {
                if (Type != 0)
                {
                    Type--;
                    Solvency = 0;
                }  
                else
                {
                    Debug.Log("GG");
                }
                
            }
        }
       
    }

    [System.Serializable]
    public enum TypeOrg
    {
        Small,
        Medium,
        Big
    }
}
