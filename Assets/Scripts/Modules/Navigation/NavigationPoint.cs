namespace Modules.Navigation
{
    public class NavigationPoint
    {
        public NavigationElementType Type { get; set; }
        public INavigationElement Element { get; set; }

        public NavigationButtonData GetButtonData()
        {
            return Element?.GetButtonData(Type) ?? GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(Type);
        }

        public NavigationScreenData GetScreenData()
        {
            return Element?.GetScreenData(Type) ?? GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(Type);
        }
    }
}