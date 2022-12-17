using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Leopotam.Ecs;
using Modules.Navigation;
using Popups;
using Save;
using Settings.Job.Simple;
using Core.Job.Simple;
using Systems.Job.Simple;
using Modules;

public class FindPartTimeJob : IEcsInitSystem, INavigationElement
{
    private EcsFilter<BlockComponent> _navigationFilter;
    private EcsFilter<CharacterComponent> _characterFilter;
    private EcsWorld _world;

    private Dictionary<NavigationElementType, string> _popupHeaders;
    private Dictionary<NavigationElementType, string> _popupText;

    public List<NavigationElementType> Types => new List<NavigationElementType>
    {

    };
    public bool CanDisplay(NavigationElementType elementType)
    {
        return false;
    }

    public bool OnClick(NavigationElementType elementType)
    {
        return true;
    }

    public NavigationButtonData GetButtonData(NavigationElementType elementType)
    {
        return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
    }

    public NavigationScreenData GetScreenData(NavigationElementType elementType)
    {
        return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
    }

    public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
    {
        return false;
    }

    public void Init()
    {
        _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
    }
}