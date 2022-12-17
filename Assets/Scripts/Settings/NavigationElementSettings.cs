using System.Collections.Generic;
using System.Linq;
using Modules.Navigation;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "NavigationElementSettings", menuName = "LifeSim/Navigation/Navigation element settings", order = 0)]
    public class NavigationElementSettings : ScriptableObject
    {
        [SerializeField] private NavigationElementType _type;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _title;
        [SerializeField] private string _easyname;
        [SerializeField] private string _description;
        [SerializeField] private string _companyType;
        [SerializeField] private List<NavigationElementType> _possibleChilds;

        public NavigationElementType Type => _type;
        public Sprite Icon => _icon;
        public string Title => _title;
        public string Easyname => _easyname;
        public string Description => _description;
        public string CompanyType => _companyType;
        public List<NavigationElementType> PossibleChilds => _possibleChilds.ToList();
    }
}