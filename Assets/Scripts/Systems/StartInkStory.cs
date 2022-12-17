using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Assets.Scripts.Settings;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using Core.NpcCommunication;
using DialogSystem;
using Leopotam.Ecs;
using Popups;
using Modules;
using Modules.Navigation;
using Settings;
using UnityEngine;
using Choice = Ink.Runtime.Choice;
using Random = System.Random;
using Story = Ink.Runtime.Story;
using Extensions;
using System.Text.RegularExpressions;
using Core.Education;

namespace Systems
{
    public class StartInkStory : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        private EcsFilter<PersonComponent> _personFilter;
        private EcsFilter<InkStoryComponent> _inkStoryFilter;
        private EcsFilter<NextWorldDateIteration> _nextWorldCycleIteration;
        private EcsFilter<Components.NpcCommunication> _npcCommunicationFilter;
        private EcsFilter<BlockComponent, Active> _navigationFilter;
        
        private DialogInkSet _dialogInkSet;
        private PopupViewManager _popupViewManager;
        private GlobalSettings _globalSettings;
        
        private Story _story;
        private string _storyName;
        private string _currentTextForLog;

        private string[]_currentPersons;

        public void Init()
        {
            EventSystem.Subscribe<DialogChoiceButton_Click>(OnDialogResponse_Click);
        }

        public void Run()
        {
            if (!_npcCommunicationFilter.IsEmpty())
                return;

#if UNITY_EDITOR
            if (_globalSettings.DisableStories)
                return;      
#endif
            foreach (var i in _inkStoryFilter)
            {
                var _name = _inkStoryFilter.Get1(i).StoryName;
                if (!_popupViewManager.HasOpened)
                {
                    TryRunInkStory(_name);
                    _inkStoryFilter.GetEntity(i).Destroy();
                }
            }
            
            if (_nextWorldCycleIteration.IsEmpty())
                return;
            
            var availableStories = new List<TextAsset>();
            foreach (var story in _dialogInkSet.NotRequiredInkSets)
            {
                if (CheckNotRequiredStory(story.text, story.name))
                {
                    availableStories.Add(story);
                }
            }
            
            int rand = UnityEngine.Random.Range(0, 100);
            if (availableStories.Count == 0 || rand < 25)
            {
                return;
            }
            
            rand = UnityEngine.Random.Range(0, availableStories.Count);
            _world.NewEntity().Replace(new InkStoryComponent { StoryName = availableStories[rand].name });
            
        }

        private bool CheckNotRequiredStory(string text, string name)
        {
            var story = new Story(text);
            var character = GetCurrentCharacter();
            if (character == null)
                return false;
            
            var sex = character.Gender;

            var persons = NpcCasting(character, story);

            if (persons == null) return false;

            if (story.variablesState.Contains("Character0MinAgeSc"))
            {
                var AgeMin = int.Parse(story.variablesState.GetVariableWithName("Character0MinAgeSc").ToString());
                if (AgeMin > character.Age.TotalYears)
                {
                    return false;
                }
            }
            
            if (story.variablesState.Contains("Character0MaxAgeSc"))
            {
                var AgeMax = int.Parse(story.variablesState.GetVariableWithName("Character0MaxAgeSc").ToString());
                if (AgeMax < character.Age.TotalYears)
                {
                    return false;
                }
            }
            if (story.variablesState.Contains("SexCondition"))
            {
                var Sex = story.variablesState.GetVariableWithName("SexCondition").ToString();
                if (!Sex.Equals(sex.ToString()))
                {
                    return false;
                }
            }
            
            if (story.variablesState.Contains("Character0OccupationSc"))
            {
                if (character.CurrentOccupation == null)
                    return false;
                
                if (character.CurrentOccupation is EducationService educationService)
                {
                    var currentOccupation = educationService.Type;
                    var conditionOccupationStory = story.variablesState.GetVariableWithName("Character0OccupationSc").ToString();
                    string[] conditionOccupationStorys = conditionOccupationStory.Split(':');

                    bool anyCondition = conditionOccupationStorys.Any(s => s.Contains(currentOccupation.ToString()));
                    // Проверка на колледж, из-за разных названий
                    if (currentOccupation == EducationType.CommunityCollege && story.variablesState.GetVariableWithName("Character0OccupationSc").ToString() == "College" )
                    {
                        anyCondition = true;
                    }
                    if (!anyCondition)
                    {
                        return false;
                    }
                }
                if (character.CurrentOccupation is SimpleWorkService simpleWorkService)
                {
                    var conditionOccupationStory = story.variablesState.GetVariableWithName("Character0OccupationSc").ToString();
                    string[] conditionOccupationStorys = conditionOccupationStory.Split(':');

                    bool anyCondition = conditionOccupationStorys.Any(s => s.Contains("FullTimeJob"));
                    if (!anyCondition)
                    {
                        return false;
                    }
                }
                if (character.CurrentOccupation is Core.MilitaryService MilitaryService)
                {
                    var conditionOccupationStory = story.variablesState.GetVariableWithName("Character0OccupationSc").ToString();
                    string[] conditionOccupationStorys = conditionOccupationStory.Split(':');

                    bool anyCondition = conditionOccupationStorys.Any(s => s.Contains("FullTimeJob"));
                    if (!anyCondition)
                    {
                        return false;
                    }
                }
            }
            
            if (character.InkStoryHistory.Keys.Contains(name))
            {
                return false;
            }
            return true;
        }

        private string[] NpcCasting(Core.Character character,Story story)
        {
            Dictionary<string, List<string>> castingPool = new Dictionary<string, List<string>>();
            var conditions = story.variablesState.Where(v => v.EndsWith("Sc") && v.StartsWith("NPC"));

            foreach (var condition in conditions)
            {
                string key = condition.Substring(0, 4);
                if (!castingPool.ContainsKey(key))
                    castingPool.Add(key, new List<string>());
                castingPool[key].Add(condition);
            }

            Dictionary<string, List<string>> actorsPool = new Dictionary<string, List<string>>();

            foreach (var roleConditions in castingPool)
            {
                actorsPool.Add(roleConditions.Key, null);
                foreach (var item in _npcFilter)
                {
                    var npc = _npcFilter.Get1(item).Npc;
                    bool npcResult = true;
                    foreach (var condition in roleConditions.Value)
                    {
                        npcResult &= CheckNpcCondition(npc, condition.Replace(roleConditions.Key, ""),
                            story.variablesState.GetVariableWithName(condition).ToString(), character);
                    }
                    if (npcResult)
                    {
                        if (actorsPool[roleConditions.Key] == null)
                            actorsPool[roleConditions.Key] = new List<string>();

                        actorsPool[roleConditions.Key].Add(npc.Id);
                    }
                }
                if (actorsPool[roleConditions.Key] == null)
                    return null;
            }

            string[] castingResult = new string[actorsPool.Count+1];
            castingResult[0] = character.Id;

            while (true)
            {
                int i = 1;
                bool roleConfirmed = false;
                string actorId = "";
                foreach (var pair in actorsPool)
                {
                    var actors = pair.Value;
                    if (actors == null)
                    {
                        i++;
                        continue;
                    }
                    if (actors.Count == 1)
                    {
                        roleConfirmed = true;
                        actorId = actors[0];
                        castingResult[i] = actorId;
                        actorsPool[pair.Key] = null;
                        break;
                    }
                    i++;
                }
                if (!roleConfirmed)
                {
                    i = 1;
                    foreach (var pair in actorsPool)
                    {
                        var actors = pair.Value;
                        if (actors == null)
                        {
                            i++;
                            continue;
                        }
                        roleConfirmed = true;
                        actorId = actors[0];
                        castingResult[i] = actorId;
                        actorsPool[pair.Key] = null;
                        break;
                    }
                }
                if (roleConfirmed)
                {
                    foreach (var pair in actorsPool)
                    {
                        if (pair.Value == null) continue;
                        pair.Value.Remove(actorId);
                        if (pair.Value.Count < 1) return null;
                    }
                    continue;
                }
                else
                {
                    foreach (string result in castingResult)
                        if (result == "") return null;
                    return castingResult;
                }
            }
        }

        private bool CheckNpcCondition(Npc npc, string conditionType, string conditionValue, Core.Character character)
        {
            switch (conditionType)
            {
                case "RelativesSc":
                {
                    var values = conditionValue.Split(':');
                    foreach (var value in values)
                    {
                        if (ChecNpcRelationship(character, npc, value))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                case "RelationshipSc":
                {
                    var values = conditionValue.Split(':');
                    foreach (var value in values)
                    {
                        if (ChecNpcRelationship(character, npc, value))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                case "OccupationSc":
                {
                    var values = conditionValue.Split(':');
                    foreach (var value in values)
                    {
                        if (CheckNpcOccupation(character, npc, value))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                case "GenderSc":
                {
                    var values = conditionValue.Split(':');
                    foreach (var value in values)
                    {
                        if (CheckNpcGender(npc,value,character))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                case "MinAgeSc":
                {
                    var value = conditionValue;
                    if (Int32.Parse(conditionValue) < npc.Age.TotalYears)
                    {
                        return true;
                    }
                    return false;
                }
                case "MaxAgeSc":
                {
                    var value = conditionValue;
                    if (Int32.Parse(conditionValue) > npc.Age.TotalYears)
                    {
                        return true;
                    }
                    return false;
                }    
                default:
                    return false;
            }
        }

        private bool ChecNpcRelationship(Core.Character character, Npc npc, string value)
        {
            var relation = npc.Relationships.FirstOrDefault(r =>
                                            r.Person.Id == character.Id);
            if (relation == null) return false;
            switch (value)
            {
                case "Parent":
                    return relation.RelationshipType == RelationshipType.Mother || relation.RelationshipType == RelationshipType.Father;
                case "Sibling":
                    return relation.RelationshipType == RelationshipType.Sister || relation.RelationshipType == RelationshipType.Brother;
                case "Friend":
                    return relation.RelationshipType == RelationshipType.Friend;
                case "Partner":
                    return relation.RelationshipType == RelationshipType.Lover;
                case "Enemy":
                    return relation.RelationshipType == RelationshipType.Enemy;
                case "StepParent":
                case "StepSibling":
                case "Pet":
                case "Kid":
                case "AdoptedKid":
                case "Crush":
                case "SignificantOther":
                case "Stranger ":
                default:
                    return false;
            }
        }

        private bool CheckNpcOccupation(Core.Character character, Npc npc, string value)
        {
            if (character.CurrentOccupation == null) return false;
            if (npc.CurrentOccupation == null) return false;
            var characterOrganizaionId = character.CurrentOccupation.Id;
            var npcOrganizaionId = npc.CurrentOccupation.Id;
            if (characterOrganizaionId == npcOrganizaionId)
            {
                switch (value)
                {
                    case "Classmate":
                        {
                            return npc.CurrentOccupation is EducationService;
                        }
                    case "Colleague":
                        {
                            return npc.CurrentOccupation is WorkService || npc.CurrentOccupation is SimpleWorkService;
                        }
                    case "HigherInPosition":
                        {
                            return false; //на текущий момент должности не реализованы
                        }
                    default:
                        return false;
                }
            }
            return false;
        }
        
        private bool CheckNpcGender(Npc npc, string value, Core.Character character)
        {
            switch (value)
            {
                case "Female":
                    return npc.Gender == Genders.Female;
                case "Male":
                    return npc.Gender == Genders.Male;
                case "Same":
                    return npc.Gender == character.Gender;
                case "Opposite":
                    return npc.Gender != character.Gender;
                default:
                    return false;
            }
        }

        public void Destroy()
        {
            EventSystem.Unsubscribe<DialogChoiceButton_Click>(OnDialogResponse_Click);
        }

        private void TryRunInkStory(string storyName)
        {
            _story = null;
            foreach (var inkStory in _dialogInkSet.InkSets)
            {
                if (inkStory.name == storyName)
                {
                    _storyName = storyName;
                    StartStory(inkStory.text);
                    var character = GetCurrentCharacter();
                    if (!character.InkStoryHistory.ContainsKey(storyName))
                    {
                        character.InkStoryHistory.Add(storyName, WorldDateModule.CurrentDate);
                    }
                }
            }
            foreach (var inkStory in _dialogInkSet.NotRequiredInkSets)
            {
                if (inkStory.name == storyName)
                {
                    _storyName = storyName;
                    StartStory(inkStory.text);
                    var character = GetCurrentCharacter();
                    if (!character.InkStoryHistory.ContainsKey(storyName))
                    {
                        character.InkStoryHistory.Add(storyName, WorldDateModule.CurrentDate);
                    }
                }
            }
        }

        private void StartStory(string inkText)
        {
            _story = new Story(inkText);
            _currentPersons = NpcCasting(GetCurrentCharacter(), _story);
            CopyVarsToStory();
            RefreshView();
        }

        private void RefreshView()
        {
            if (_story.canContinue)
            {
                string _messageText = GetNextStoryBlock();
                if (_story.variablesState.Contains("Bubble") == true)
                {
                    var _txt = _story.variablesState.GetVariableWithName("Bubble").ToString().EnrichText(getCurrentPersons());
                    EventSystem.Send(new BubbleTextComponent { BubbleTextValue = _txt });
                }

                if (_story.currentChoices.Count > 0)
                {
                    //если не находимся в окне Npc открываем попап
                    if (_navigationFilter.GetCurrentPoint(NavigationBlockType.Main) == null
                        || !(_navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.ChatInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.InsultInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.CommunicationInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.FightInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.FlirtInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.GiftInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.AskMoneyInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.BeFriendInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.DateInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.AskOutInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.SpendTimeInteraction
                        || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.UnFriendInteraction))
                    {
                        var buttonSettings = new List<ActionButtonSettings>();
                        foreach (Choice response in _story.currentChoices)
                        {
                            buttonSettings.Add(new ActionButtonSettings
                            {
                                Title = response.text.EnrichText(getCurrentPersons()),
                                Action = () => { OnClickChoiceButton(response); }
                            });
                        }
                        if (_story.variablesState.Contains("GroupTitle")) {
                                
                        }

                        _world.NewEntity().Replace(new ShowPopup
                        {
                            PopupToShow = new PopupToShow<NonHeaderPopup>(new NonHeaderPopup
                            {
                                HeaderText = _story.variablesState.Contains("GroupTitle")? _story.variablesState.GetVariableWithName("GroupTitle").ToString() : "",
                                ContentText = _messageText.EnrichText(getCurrentPersons()),
                                ActionsSettings = buttonSettings
                            })
                        });
                    }
                    else
                    {
                        _world.NewEntity()
                            .Replace(new ChoicesChanged
                            {
                                Message = _messageText.EnrichText(getCurrentPersons()),
                                ButtonChoices = _story.currentChoices.Select((choice, i) => new CommunicationChoice
                                {
                                    Index = i,
                                    Text = choice.text.Trim().EnrichText(getCurrentPersons())
                                }).ToList()
                            });
                    }
                }
                else
                {  // финальная нода
                    CopyVarsFromStory();
                    WriteLastMessageToLog();
                    if (_navigationFilter.GetCurrentPoint(NavigationBlockType.Main) == null
                        || !(_navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.ChatInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.InsultInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.CommunicationInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.FightInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.FlirtInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.GiftInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.AskMoneyInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.BeFriendInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.DateInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.AskOutInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.SpendTimeInteraction
                             || _navigationFilter.GetCurrentPoint(NavigationBlockType.Main).Type == NavigationElementType.UnFriendInteraction))
                    {
                       _world.NewEntity().Replace(new HideCurrentPopup());
                       _story = null;
                    }
                    else
                    {
                        _world.NewEntity().Replace(new NavigationBack());
                        _story = null;
                    }
                }
            }
        }

        private void WriteLastMessageToLog()
        {
            foreach (var i in _charactersFilter)
            {
                _charactersFilter.Get1(i).Character.AgeLog.AddRecord(WorldDateModule.CurrentDate, new Record(_currentTextForLog.EnrichText(getCurrentPersons())));
                _currentTextForLog = "";
            }
        }

        private void OnClickChoiceButton(Choice choice)
        {
            if (!_npcCommunicationFilter.IsEmpty())
                return;
            
            CopyVarsToStory();
            _story.ChooseChoiceIndex(choice.index);
            RefreshView();
            _world.NewEntity().Replace(new HideCurrentPopup());
        }

        private void OnDialogResponse_Click(DialogChoiceButton_Click e)
        {
            if (!_npcCommunicationFilter.IsEmpty())
                return;
            
            CopyVarsToStory();
            _story.ChooseChoiceIndex(e.ChoiceIndex);
            RefreshView();
        }

        private string GetNextStoryBlock()
        {
            string text = "";
            if (_story.canContinue)
            {
                if (_story.currentText.Length > 1)
                {
                    _currentTextForLog = _story.currentText;
                }
                else
                {
                    _currentTextForLog = null;
                }

                text = _story.ContinueMaximally();
            }
            return text;
        }

        private Core.Character GetCurrentCharacter()
        {
            foreach (var i in _charactersFilter)
            {
                return _charactersFilter.Get1(i).Character;
            }
            return null;
        }

        private Person GetPerson(string id)
        {
            foreach (var i in _personFilter)
            {
                if (_personFilter.Get1(i).Person.Id == id)
                    return _personFilter.Get1(i).Person;
            }
            return null;
        }

        private Person[] getCurrentPersons()
        {
            Person[] persons = new Person[_currentPersons.Length];
            for (int i = 0; i < _currentPersons.Length; i++)
            {
                var id = _currentPersons[i];
                foreach (var j in _personFilter)
                {
                    if (_personFilter.Get1(j).Person.Id == id)
                    {
                        persons[i] = _personFilter.Get1(j).Person;
                        break;
                    }
                }
            }
            return persons;
        }

        private void CopyVarsToStory()
        {
            if (_story.variablesState.Contains("NpcName"))
                _story.variablesState["NpcName"] = GetPerson(_currentPersons[1]).FullName;
            
            if (_story.variablesState.Contains("Relationship") == true)
                _story.variablesState["Relationship"] = GetPerson(_currentPersons[1]).Parameters.Get(ParameterType.Relationship.ToString()).Value;
            
            if (_story.variablesState.Contains("NpcLooks") == true)
                _story.variablesState["NpcLooks"] = GetPerson(_currentPersons[1]).Parameters.Get(ParameterType.Looks.ToString()).Value;

            if (_story.variablesState.Contains("NpcGender") == true)
                _story.variablesState["NpcGender"] = GetPerson(_currentPersons[1]).Gender.ToString();

            if (_story.variablesState.Contains("PlayerGender") == true)
                _story.variablesState["PlayerGender"] = GetCurrentCharacter().Gender.ToString();

            if (_story.variablesState.Contains("PlayerAge") == true)
                _story.variablesState["PlayerAge"] = GetCurrentCharacter().Age.TotalYears.ToString();

            if (_story.variablesState.Contains("Happiness") == true)
                _story.variablesState["Happiness"] = GetCurrentCharacter().Parameters.Get(ParameterType.Happiness.ToString()).Value;

            if (_story.variablesState.Contains("Health") == true)
                _story.variablesState["Health"] = GetCurrentCharacter().Parameters.Get(ParameterType.Health.ToString()).Value;

        }

        private void CopyVarsFromStory()
        {
            if (_story.variablesState.Contains("LoverStatus") == true)
            {
                if (_story.variablesState.GetVariableWithName("LoverStatus").ToString() == "true")
                {
                    _world.NewEntity().Replace(new ApplyDialogResult
                    {
                        Participant = GetPerson(_currentPersons[1]).Id,
                        ParticipantType = DialogParticipantType.Npc,
                        ResultType = ParameterResultType.RelationshipType,
                        relationshipType = RelationshipType.Lover,
                    });
                }
            }
            if (_story.variablesState.Contains("FriendStatus") == true)
            {
                if (_story.variablesState.GetVariableWithName("FriendStatus").ToString() == "true")
                {
                    _world.NewEntity().Replace(new ApplyDialogResult
                    {
                        Participant = GetPerson(_currentPersons[1]).Id,
                        ParticipantType = DialogParticipantType.Npc,
                        ResultType = ParameterResultType.RelationshipType,
                        relationshipType = RelationshipType.Friend,
                    });
                }
            }
            if (_story.variablesState.Contains("UnFriendStatus") == true)
            {
                if (_story.variablesState.GetVariableWithName("UnFriendStatus").ToString() == "true")
                {
                    _world.NewEntity().Replace(new ApplyDialogResult
                    {
                        Participant = GetPerson(_currentPersons[1]).Id,
                        ParticipantType = DialogParticipantType.Npc,
                        ResultType = ParameterResultType.RelationshipType,
                        Unfriend = true
                    });
                }
            }
            
            if (_story.variablesState.Contains("TextForLog"))
            {
                _currentTextForLog = _story.variablesState.GetVariableWithName("TextForLog").ToString();
            }

            Dictionary<EcsEntity, List<ChangeStats>> statsToChange = new Dictionary<EcsEntity, List<ChangeStats>>();

            var regex = new Regex(@"(\S+)(\d)(\S+)Ch");

            foreach (string variable in _story.variablesState)
            {
                var changeStats = new List<ChangeStats>();
                var match = regex.Match(variable);
                if (match.Length < 1) continue;

                var personType = match.Groups[1].Value;
                var personId = int.Parse(match.Groups[2].Value);
                var parametrString = match.Groups[3].Value;

                Person person = null;
                EcsEntity personEntity = EcsEntity.Null;

                switch (personType)
                {
                    case "NPC":
                        foreach (var i in _npcFilter)
                        {
                            var npc = _npcFilter.Get1(i).Npc;
                            if (npc.Id == _currentPersons[personId])
                            {
                                personEntity = _npcFilter.GetEntity(i);
                                person = npc;
                                break;
                            }
                        }
                        break;
                    case "Character":
                        foreach (var i in _charactersFilter)
                        {
                            personEntity = _charactersFilter.GetEntity(i);
                            person = _charactersFilter.Get1(i).Character;
                            break;
                        }
                        break;
                }

                if (person == null) continue;

                if (Enum.TryParse(parametrString, out ParameterType type))
                {
                    var value = _story.variablesState.GetVariableWithName(variable).ToString();
                    if (value.Contains("ValueRef"))
                    {
                        var valueRegex = new Regex(@"(%(\S+)%)");
                        value = valueRegex.Match(value).Groups[2].Value;
                        var valueRef = ReadValueRef(person, type, value);
                        var stat = new ChangeStats
                        {
                            ParameterId = type.ToString(),
                            Value = valueRef
                        };
                        changeStats.Add(stat);
                    }
                    else
                    {
                    #if UNITY_EDITOR
                        if (value.Contains("%"))
                            Debug.LogWarning($"Story variable contains '%' (value = {value}, variable name = {variable}, story name = {_storyName}");
                    #endif
                        value = value.Replace("%","");
                        var stat = new ChangeStats
                        {
                            ParameterId = type.ToString(),
                            Value = float.Parse(value)
                        };
                        changeStats.Add(stat);
                    }
                }

                if (!statsToChange.ContainsKey(personEntity))
                    statsToChange.Add(personEntity, new List<ChangeStats>());
                statsToChange[personEntity].AddRange(changeStats);
            }

            //код для поддержки историй старого формата
            foreach (var i in _charactersFilter)
            {
                var changeStats = new List<ChangeStats>();
                if (_story.variablesState.Contains("ChangeHappiness"))
                {
                    var stat = new ChangeStats
                    {
                        ParameterId = ParameterType.Happiness.ToString(),
                        Value = float.Parse(_story.variablesState.GetVariableWithName("ChangeHappiness").ToString())
                    };
                    changeStats.Add(stat);
                }
                if (_story.variablesState.Contains("ChangeLooks"))
                {
                    var stat = new ChangeStats
                    {
                        ParameterId = ParameterType.Looks.ToString(),
                        Value = float.Parse(_story.variablesState.GetVariableWithName("ChangeLooks").ToString())
                    };
                    changeStats.Add(stat);
                }
                if (_story.variablesState.Contains("ChangeSmarts"))
                {
                    var stat = new ChangeStats
                    {
                        ParameterId = ParameterType.Smarts.ToString(),
                        Value = float.Parse(_story.variablesState.GetVariableWithName("ChangeSmarts").ToString())
                    };
                    changeStats.Add(stat);
                }
                if (_story.variablesState.Contains("ChangeHealth"))
                {
                    var stat = new ChangeStats
                    {
                        ParameterId = ParameterType.Health.ToString(),
                        Value = float.Parse(_story.variablesState.GetVariableWithName("ChangeHealth").ToString())
                    };
                    changeStats.Add(stat);
                }
                if (_story.variablesState.Contains("ChangeMoneyAmount") == true)
                {
                    var stat = new ChangeStats
                    {
                        ParameterId = ParameterType.Balance.ToString(),
                        Value = float.Parse(_story.variablesState.GetVariableWithName("ChangeMoneyAmount").ToString())
                    };
                    changeStats.Add(stat);
                }
                _charactersFilter.GetEntity(i).Replace(new ChangeStatsComponent 
                {  
                    ChangeStats = changeStats
                });
            }
            
            foreach (var pair in statsToChange)
            {
                pair.Key.Replace(new ChangeStatsComponent 
                { 
                    ChangeStats = pair.Value
                });
            }
        }
        
        private float ReadValueRef(Person person, ParameterType param, string valueRef)
        {
            string[] keys = valueRef.Split(':');
            int quarter = int.Parse(keys[1]);
            return GetValueRef(person, param, quarter, keys[2] == "+");
        }

        private float GetValueRef(Person person, ParameterType param, int quarter, bool nonNegative = true)
        {
            var parametr = person.Parameters.Get(param.ToString());
            var range = parametr.Max - parametr.Min;
            return new Random().Next(0, (int)((quarter+1) * 0.25f * range)) * (nonNegative ? 1 : -1);
        }

    }
}