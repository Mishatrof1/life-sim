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
using UnityEngine;

public class FindArmy : IEcsInitSystem, INavigationElement
{
    private EcsFilter<BlockComponent> _navigationFilter;
    bool InArmy = false;
    private EcsWorld _world;
    private ArmySettings _positionsSettings;
    private EcsFilter<ApplyArmyButton> _applyJobFilter;
    private EcsFilter<CharacterComponent> _characterFilter;
    public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.Recruit,
            NavigationElementType.WarrantOfficer,
            NavigationElementType.Officer,
      

        };
    public bool CanDisplay(NavigationElementType elementType)
    {
        if (elementType == NavigationElementType.Recruit ||
                elementType == NavigationElementType.WarrantOfficer ||
                elementType == NavigationElementType.Officer
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
        var actions = new List<ActionButtonSettings>();
        Debug.Log(_applyJobFilter.Get1(0).Vacancy);
        foreach (var i in _applyJobFilter)
        {
            
            var vacancy = _applyJobFilter.Get1(i).Vacancy;
            Debug.Log(vacancy);
            foreach (var charIndex in _characterFilter)
            {
                var character = _characterFilter.Get1(charIndex).Character;

                var text = "";
                var fields = new List<string>();
              
                var smarts = character.Parameters.Get(ParameterType.Smarts.ToString()).Value;
                var endurance = character.Parameters.Get(ParameterType.Endurance.ToString()).Value;

                if (vacancy.PositionConfiguration.IsMatchVacancyRequirement(character, _positionsSettings))
                {
                    var service = new Core.MilitaryService(System.Guid.NewGuid().ToString())
                    {
                        PositionConfiguration = vacancy.PositionConfiguration,
                        Salary = vacancy.BaseSalary,
                        Productivity = (1 + smarts * 0.01f) * endurance * 0.01f * 1 / vacancy.PositionConfiguration.Difficulty,
                    };

                    vacancy.Organization.AddService(service);

                    _characterFilter.GetEntity(charIndex).Replace(new ChangeOccupation { Service = service });

                    text = $"The country is proud of you!";
                    fields = new List<string>
                        {
                            $"Welcome to {service.Organization.Name}",
                            $"Title: {service.PositionConfiguration.NameDefault}",
                            $"Employer: {service.Organization.Name}",
                            $"Salary: {service.Salary.ToMoneyString()}",
                            $"Weekly hours: {service.HoursPerWeek}h"
                        };
                    actions = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = "Ok",
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                    _world.NewEntity().Replace(new NavigationHome());
                                }
                            }
                        };
                }
                else
                {
                    text = $"Rejected";
                    fields = new List<string>
                        {
                            "You are not qualified for this Military"
                        };
                    actions = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = "Ok",
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            }
                        };
                }
                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                    {
                        HeaderText = text,
                        ContentText = string.Join(System.Environment.NewLine, fields),
                        ActionsSettings = actions
                    })
                });
            }
        }
    
     
       
        return true;
   
      
        
    }

   
}
