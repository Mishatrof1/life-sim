using System.Collections.Generic;
using Components.Navigation;
using Leopotam.Ecs;
using Modules.Navigation;

namespace Systems.Menu
{
    public class Menu : IEcsInitSystem, INavigationElement
    {
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;
        
        public void Init()
        {
            _navigationFilter.RegisterElement(NavigationBlockType.Menu, this);
        }

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.Menu,
            NavigationElementType.MenuSound
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return elementType == NavigationElementType.Menu;
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
            return true;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            if (elementType == NavigationElementType.MenuSound)
            {
                SoundProvider.Instance.ChangeSoundState();
                SoundProvider.Instance.PlaySound("click");
                return false;
            }
            return true;
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            var data = _navigationFilter.GetDefaultButtonData(NavigationBlockType.Menu, elementType);
            data.ToggleActive = true;
            data.ToggleState = !SoundProvider.Instance.SoundState;
            return data;
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            return _navigationFilter.GetDefaultScreenData(NavigationBlockType.Menu, elementType);
        }
    }
}