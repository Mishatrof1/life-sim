using System.Collections.Generic;

namespace Modules.Navigation
{
    public interface INavigationElement
    {
        List<NavigationElementType> Types { get; }
        bool IgnoreChildrenDisplayCheck(NavigationElementType elementType);
        bool CanDisplay(NavigationElementType elementType);
        bool OnClick(NavigationElementType elementType);
        NavigationButtonData GetButtonData(NavigationElementType elementType);
        NavigationScreenData GetScreenData(NavigationElementType elementType);
    }
}