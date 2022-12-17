using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Events;
using Components.Screen;
using Core;
using DialogSystem;
using Ink.Parsed;
using Leopotam.Ecs;
using Modules;
using Popups;
using Save;
using Screens;
using Settings;
using UnityEngine;
using CharacterComponent = Components.CharacterComponent;
using EducationService = Core.Education.EducationService;
using Organization = Core.Organization;
using Random = UnityEngine.Random;
using Service = Core.Service;

namespace Systems
{
    public class DialogProcessing : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsFilter<OrganizationComponent> _organizationFilter;
        private EcsFilter<ScreenComponent> _screenFilter;

        private DialogsSet _dialogsSet;
        private PopupViewManager _popupViewManger;
        private SaveDataProvider _saveDataProvider;

        private DialogsSaveData _dialogsSaveData;

        public void Init()
        {
            _dialogsSaveData = _saveDataProvider.GetSaveData<DialogsSaveData>();
        }

        public void Run()
        {
            foreach (var i in _screenFilter)
            {
                if (_screenFilter.Get1(i).ScreenView.BlockPopups)
                    return;
            }

            if (_characterFilter.IsEmpty()) 
                return;

            if (_popupViewManger.HasOpened)
                return;

            var currentCharacter = GetCurrentCharacter();
            
            foreach (var dialogSaveData in _dialogsSaveData.Dialogs)
            {
                var graph = _dialogsSet.DialogNodeGraphs[dialogSaveData.DialogIndex];
                var currentNode = (DialogNode)graph.nodes[dialogSaveData.NodeIndex];
                var canShow = true;
                foreach (var condition in currentNode.ListConditions)
                {
                    switch (condition)
                    {
                        case ConditionType.Age:
                            {
                                canShow &= currentCharacter.Age.TotalYears >=
                                          currentNode.AgeCondition;
                                break;
                            }
                    }
                }

                if (canShow)
                {
                    var buttonSettings = new List<ActionButtonSettings>();
                    foreach (var response in currentNode.Responses)
                    {
                        buttonSettings.Add(new ActionButtonSettings
                        {
                            Title = response.Label,
                            Action = () => { OnDialogResponseVariantButtonClick(_world, _dialogsSaveData, graph, dialogSaveData, response.Label); }
                        });
                    }

                    _world.NewEntity().Replace(new ShowPopup
                    {
                        PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                        {
                            HeaderText = currentNode.Label,
                            ContentText = ReplaceVarsToWords(currentNode.MessageText),
                            ActionsSettings = buttonSettings
                        })
                    });
                    return;
                }
            }
        }

        private void HandleOccupationResultType(DialogSaveData dialogSaveData, Result result)
        {
            foreach (var i in _characterFilter)
            {
                var entity = _characterFilter.GetEntity(i);
                var id = entity.Get<CharacterComponent>().Character.Id;
                if (id == dialogSaveData.Participants[result.ParticipantIndex])
                {
                    switch (result.TypeOfOccupation)
                    {
                        case TypeOfOccupation.PrimarySchool:
                        {
                            var primarySchoolService = GetAvailableServices<EducationService>(_organizationFilter,
                                service => service.Type == EducationType.PrimarySchool).FirstOrDefault();
                            if (primarySchoolService != null)
                            {
                                entity.Replace(new ChangeOccupation { Service = primarySchoolService });
                            }
                            break;
                        }
                        case TypeOfOccupation.MiddleSchool:
                        {
                            var middleSchoolService = GetAvailableServices<EducationService>(_organizationFilter,
                                service => service.Type == EducationType.MiddleSchool).FirstOrDefault();
                            if (middleSchoolService != null)
                            {
                                entity.Replace(new ChangeOccupation { Service = middleSchoolService });
                            }
                            break;
                        }
                        case TypeOfOccupation.HighSchool:
                        {
                            var highSchoolService = GetAvailableServices<EducationService>(_organizationFilter,
                                service => service.Type == EducationType.HighSchool).FirstOrDefault();
                            if (highSchoolService != null)
                            {
                                entity.Replace(new ChangeOccupation { Service = highSchoolService });
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void OnDialogResponseVariantButtonClick(EcsWorld world,
            DialogsSaveData dialogsSaveData, DialogNodeGraph dialogGraph, DialogSaveData dialogSaveData,
            string responseLabel)
        {
            var currentNode = (DialogNode)dialogGraph.nodes[dialogSaveData.NodeIndex];

            foreach (var result in currentNode.Results)
            {
                switch (result.ResultType)
                {
                    case ParameterResultType.Occupation:
                        HandleOccupationResultType(dialogSaveData, result);
                        break;

                    default:
                    {
                        _world.NewEntity().Replace(new ApplyDialogResult
                        {
                            Participant = dialogSaveData.Participants[result.ParticipantIndex],
                            ParticipantType = dialogGraph.ParticipantTypes[result.ParticipantIndex],
                            ResultType = result.ResultType,
                            HappinessChange = result.HappinessChange,
                            HealthChange = result.HealthChange,
                            LookChange = result.LookChange,
                            SmartChange = result.SmartChange,
                            MoneyChange = result.MoneyChange,
                            OccupationChange = result.TypeOfOccupation
                        });
                        break;
                    }
                }
            }
            
            var clickedIndex = 0;
            for (var i = 0; i < currentNode.Responses.Count; i++)
            {
                if (responseLabel == currentNode.Responses[i].Label)
                    clickedIndex = i;

                if (responseLabel == "Befriend" || responseLabel=="Ask")
                {
                    int decision = Random.Range(0, 100);
                    for (int j = 0; j < dialogGraph.nodes.Count; j++)
                    {
                        if (((DialogNode)dialogGraph.nodes[j]).Label == "Yes" && decision > 50)
                        {
                            dialogSaveData.NodeIndex = j;
                            world.NewEntity().Replace(new HideCurrentPopup());
                            return;
                        }
                        if (((DialogNode)dialogGraph.nodes[j]).Label == "No" && decision < 51)
                        {
                            dialogSaveData.NodeIndex = j;
                            world.NewEntity().Replace(new HideCurrentPopup());
                            return;
                        }
                    }
                }

            }
            var port = currentNode.GetPort("Responses " + clickedIndex);
            if (port.IsConnected)
            {
                dialogSaveData.NodeIndex = dialogGraph.nodes.IndexOf(port.Connection.node);
                world.NewEntity().Replace(new HideCurrentPopup());
            }
            else
            {
                world.NewEntity().Replace(new HideCurrentPopup());
                dialogsSaveData.Dialogs.Remove(dialogSaveData);
            }
        }

        private string ReplaceVarsToWords(string txt)
        {
            var currentCharacter = GetCurrentCharacter();

            txt = txt.Replace("{PlayerFullName}", currentCharacter.FullName);
            txt = txt.Replace("{PlayerGender}", currentCharacter.Gender.ToString()); 
            txt = txt.Replace("{PlayerAge}", currentCharacter.Age.TotalYears.ToString());
            txt = txt.Replace("{PlayerFatherName}", "FatherName");
            return txt;
        }

        private Person GetCurrentCharacter()
        {
            foreach (var i in _characterFilter)
            {
                return _characterFilter.Get1(i).Character;
            }

            return null;
        }

        private List<T> GetAvailableServices<T>(EcsFilter<OrganizationComponent> organizationFilter, Func<T, bool> condition)
            where T : Service
        {
            var result = new List<T>();
            foreach (var i in organizationFilter)
            {
                var organization = organizationFilter.Get1(i).Organization;
                result.AddRange(organization.Services.Where(s => s is T sCast && condition(sCast)).Cast<T>());
            }

            return result;
        }
    }
}