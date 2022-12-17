using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Leopotam.Ecs;
using Modules.Navigation;
using Popups;
using Random = UnityEngine.Random;

namespace Systems.NavigationElements
{
    public class SexCommunication : INavigationElement, IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.SexInteraction
        };
        
        public void Init()
        {
            _navigationFilter.RegisterElement(NavigationBlockType.Main, this);
        }

        public void Run()
        {
        }
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return true;
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
            if (elementType != NavigationElementType.SexInteraction)
                return false;

            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                var relation = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                if (relation != null && relation.RelationshipType == RelationshipType.Lover)
                {
                    AddGrayButton(elementType);
                    var result = true;
                    if (character.Gender == Genders.Male)
                    {
                        result &= character.Age.TotalYears >= 16 && character.Age.TotalYears <= 60;
                    }
                    if (npc.Gender == Genders.Male)
                    {
                        result &= npc.Age.TotalYears >= 16 && npc.Age.TotalYears <= 60;
                    }

                    if (result)
                    {
                        RemoveGrayButton(elementType);
                    }
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool OnClick(NavigationElementType elementType)
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                var endurance = character.Parameters.Get(ParameterType.Endurance.ToString());
                var smarts = character.Parameters.Get(ParameterType.Smarts.ToString());
                
                var content = new StringBuilder();
                content.Append($"{LocalizationDictionary.GetLocalizedString("sex_title")}.{Environment.NewLine}{Environment.NewLine}");
                content.Append($"{LocalizationDictionary.GetLocalizedString("sex_player_enjoy")}: {Random.Range(20f, 60f) + 0.05f * (endurance.Value + smarts.Value)}{Environment.NewLine}");
                content.Append($"{LocalizationDictionary.GetLocalizedString("sex_npc_enjoy")}: {Random.Range(20f, 60f) + 0.05f * (endurance.Value + smarts.Value)}{Environment.NewLine}");

                _world.NewEntity().Replace(new ShowPopup
                {
                    PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                    {
                        HeaderText = LocalizationDictionary.GetLocalizedString("sex"),
                        ContentText = content.ToString(),
                        ActionsSettings = new List<ActionButtonSettings>
                        {
                            new ActionButtonSettings
                            {
                                Title = LocalizationDictionary.GetLocalizedString("ok"),
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new HideCurrentPopup());
                                }
                            }
                        }
                    })
                });
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
        
        public void AddGrayButton(NavigationElementType elementType)
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            if (!npc.GrayButtons.Contains(elementType))
            {
                npc.GrayButtons.Add(elementType);
            }
        }
        
        public void RemoveGrayButton(NavigationElementType elementType)
        {
            var npc = _navigationActiveFilter.GetLastElementInChain<Npc>(NavigationBlockType.Main);
            if (npc.GrayButtons.Contains(elementType))
            {
                npc.GrayButtons.Remove(elementType);
            }
        }
    }
}