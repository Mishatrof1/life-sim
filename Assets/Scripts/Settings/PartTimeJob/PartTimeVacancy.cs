using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Core;
using Leopotam.Ecs;
using Modules.Navigation;
using Popups;
using Settings;

public class PartTimeVacancy : INavigationElement
    {
        private readonly EcsWorld _world;
    private EcsFilter<CharacterComponent> _charactersFilter;
    private readonly GradeConfiguration _gradeConfiguration;

        public PartTimePositionConfiguration PartTimePositionConfiguration { get; }
        public PartTimePositionSettings PartTimePositionSettings { get; }
        public Organization Organization { get; set; }
        public float BaseSalary { get; set; }
        public float HoursWeek { get; set; }


    public PartTimeVacancy(GradeConfiguration gradeConfiguration, PartTimePositionSettings partTimePositionSettings, PartTimePositionConfiguration partTimePositionConfiguration, EcsWorld world)
    {
        PartTimePositionConfiguration = partTimePositionConfiguration;
        PartTimePositionSettings = partTimePositionSettings;
        _world = world;
        _gradeConfiguration = gradeConfiguration;
    }

    public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            
        };

        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return false;
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
        if (elementType == NavigationElementType.PartTimeVacancy /*&& _charactersFilter?.Get1(0).Character?.CurrentPartTimeOccupation == null && _charactersFilter?.Get1(0).Character?.Age.TotalYears >= 14*/)
        {
            return true;
        }
        return false;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            
                var text = $"Apply for this open position today! {Environment.NewLine}";
                text += $"{ Environment.NewLine }";
                text += $"{ Environment.NewLine }";
                text += $"Job: {PartTimePositionConfiguration.NameDefault}{ Environment.NewLine }";
                text += $"Hourly rate: {BaseSalary.ToMoneyString()}{ Environment.NewLine }";
                text += $"Weekly Hours: {HoursWeek}{ Environment.NewLine }";
                text += $"Years Wage: {(BaseSalary * HoursWeek * 17).ToMoneyString()}{ Environment.NewLine }";

                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                    {
                        HeaderText = "Job",
                        ContentText = text,
                        ActionsSettings = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = "Try to get a job",
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new ApplyPartTimeButton {PartTimeVacancy = this});
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            },
                            new ActionButtonSettings
                            {
                                Title = "Back",
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

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            var button = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
            button.Title = PartTimePositionConfiguration.NameDefault;
            button.Description = BaseSalary.ToMoneyString();
            button.Icon = PartTimePositionConfiguration.Icon;
            return button;
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            return GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
        }
}