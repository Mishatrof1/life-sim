using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Leopotam.Ecs;
using Modules.Navigation;
using Popups;
using Save;

public class FindMilitary : IEcsInitSystem, INavigationElement
{
    private EcsFilter<BlockComponent> _navigationFilter;
    private EcsFilter<CharacterComponent> _characterFilter;
    private EcsWorld _world;
    public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.Navy,
            NavigationElementType.Army,
            NavigationElementType.CostGueards,
            NavigationElementType.Marines,
            NavigationElementType.AirForce,

        };
    public bool CanDisplay(NavigationElementType elementType)
    {
        if (elementType == NavigationElementType.Navy ||
                elementType == NavigationElementType.Army ||
                elementType == NavigationElementType.CostGueards ||
                elementType == NavigationElementType.Marines ||
                elementType == NavigationElementType.AirForce
                )
        {
            return true;
        }

        return false;
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

    public bool OnClick(NavigationElementType elementType)
    {
        foreach (var i in _characterFilter)
        {
            var character = _characterFilter.Get1(i).Character;
            var text = "";
            var fields = new List<string>();
            var actions = new List<ActionButtonSettings>();
            var smarts = character.Parameters.Get(ParameterType.Smarts.ToString()).Value;
            var endurance = character.Parameters.Get(ParameterType.Endurance.ToString()).Value;

            if (character.Age.TotalYears < 21 )
            {
              
                    _world.NewEntity().Replace(new ShowPopup
                    {
                        PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                        {
                            HeaderText = "Rejected!",
                            ContentText = $"You was rejected by reason: \n" +
                            $"Age",
                           



                            ActionsSettings = new List<ActionButtonSettings>
                        {

                            new ActionButtonSettings
                            {
                                Title = "Ok",
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            }
                        }
                        })
                    });
                    return false;


                }
                if (character.Parameters.Get(ParameterType.Health.ToString()).Value < 70)
                {
                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                    {
                        HeaderText = "Rejected!",
                        ContentText = $"You was rejected by reason:" +
                           $"Health",



                        ActionsSettings = new List<ActionButtonSettings>
                        {

                            new ActionButtonSettings
                            {
                                Title = "Ok",
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            }
                        }
                    })
                });
                return false;
            }
            else
            {
                return true;
            }
               
            

            

        }
        return true;
    }

   
}
