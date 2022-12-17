using System.Collections.Generic;
using System.Linq;

namespace Modules.Navigation
{
    public class ContainerNavigationElement : INavigationElement
    {
        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.MainScreen,
            NavigationElementType.ActivitiesScreen,
            NavigationElementType.AssetsScreen,
            NavigationElementType.RelationshipsScreen
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return Types.Any(t => t == elementType);
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
            return Types.Any(t => t == elementType);
        }

        public bool OnClick(NavigationElementType elementType)
        {
            return Types.Any(t => t == elementType);
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
        }
    }
}