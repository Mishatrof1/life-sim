using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using Components.Navigation;
using Leopotam.Ecs;
using Modules.Navigation;
using Save;
using EducationService = Core.Education.EducationService;

namespace Core
{
    public class Npc : Person, INavigationElement, IParametersOwner
    {
        public List<Relationship> Relationships;
        public Service CurrentOccupation;
        public FlirtProgress FlirtProgress;
        public BefriendProgress BefriendProgress;

        // TODO Нужно подумать о вынесении взаимодействий в отдельные объекты
        public int ComplimentYearCount;
        public int CommunicationYearCount;
        public int SpendTimeYearCount;
        public int GiftYearCount;
        public int PositiveStoryYearCount;
        public int NegativeStoryYearCount;
        public int InsultYearCount;
        public int FightYearCount;
        public int DateYearCount;
        public int SexYearCount;
        public int UnFriendYearsCount;

        [NonSerialized]
        public EcsFilter<CharacterComponent> CharacterFilter;
        public EcsFilter<BlockComponent, Active> NavigationFilter;
        public List<NavigationElementType> GrayButtons = new List<NavigationElementType>();
        
        public Npc(string id, WorldDate birthDate, Parameters parameters) : base(id, birthDate, parameters)
        {
            Relationships = new List<Relationship>();
            FlirtProgress = new FlirtProgress();
            BefriendProgress = new BefriendProgress();
        }
        
        public Npc(Person person) : this(person.Id, person.BirthDate, person.Parameters)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
            Gender = person.Gender;
            Avatar = person.Avatar;
            BirthLocation = person.BirthLocation;
            Appearance = person.Appearance;
            Accessories = person.Accessories;
        }
        
        public Npc(NpcSave npcSave) : this(npcSave.Id, npcSave.BirthDate, new Parameters())
        {
            FirstName = npcSave.FirstName;
            LastName = npcSave.LastName;
            Gender = npcSave.Gender;
            Appearance = new Appearance(npcSave.AppearanceV2Save);
            Accessories = new Accessories(npcSave.AccessoriesSave);
            FlirtProgress = npcSave.FlirtProgress;
            BefriendProgress = npcSave.BefriendProgress;
            Parameters.Restore(npcSave.ParametersSave);
            
            ComplimentYearCount = npcSave.CommunicationYearCount;
            CommunicationYearCount = npcSave.CommunicationYearCount;
            SpendTimeYearCount = npcSave.SpendTimeYearCount;
            GiftYearCount = npcSave.GiftYearCount;
            PositiveStoryYearCount = npcSave.PositiveStoryYearCount;
            NegativeStoryYearCount = npcSave.NegativeStoryYearCount;
            InsultYearCount = npcSave.InsultYearCount;
            FightYearCount = npcSave.FightYearCount;
            DateYearCount = npcSave.DateYearCount;
            SexYearCount = npcSave.SexYearCount;
            UnFriendYearsCount = npcSave.UnFriendYearsCount;
        }
        
        public string RelationshipStatus
        {
            get
            {
                Character character = null;
                foreach (var i in CharacterFilter)
                {
                    character = CharacterFilter.Get1(i).Character;
                }
                return Relationships?
                    .FirstOrDefault(r => r.Person.Id == character.Id)
                    ?.RelationshipType.ToString() ?? OccupationStatus;
            }
        }

        public string OccupationStatus
        {
            get
            {
                return CurrentOccupation switch
                {
                    EducationService service => LocalizationDictionary.GetLocalizedString("occupation_status_classmate"),
                    WorkService service => LocalizationDictionary.GetLocalizedString("occupation_status_colleague"),
                    SimpleWorkService service => LocalizationDictionary.GetLocalizedString("occupation_status_colleague"),
                    _ => LocalizationDictionary.GetLocalizedString("occupation_status_unknown")
                };
            }
        }

        public List<NavigationElementType> Types => new List<NavigationElementType>
        {
            NavigationElementType.NpcScreen
        };
        
        public bool IgnoreChildrenDisplayCheck(NavigationElementType elementType)
        {
            return true;
        }

        public bool CanDisplay(NavigationElementType elementType)
        {
            if (!Types.Contains(elementType))
                return false;
            
            var currentPoint = NavigationFilter.GetCurrentPoint(NavigationBlockType.Main);
            if (currentPoint == null)
                return false;

            Character character = null;
            foreach (var i in CharacterFilter)
            {
                character = CharacterFilter.Get1(i).Character;
            }

            return currentPoint.Type switch
            {
                NavigationElementType.RelationshipsScreen => Relationships != null && Relationships.Count > 0,
                NavigationElementType.ColleaguesDirectory => CurrentOccupation?.Id == character.CurrentOccupation.Id,
                _ => false
            };
        }

        public bool OnClick(NavigationElementType elementType)
        {
            return true;
        }

        public NavigationButtonData GetButtonData(NavigationElementType elementType)
        {
            var buttonData = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultButtonData(elementType);
            buttonData.Title = FullName;
            buttonData.Description = RelationshipStatus;
            buttonData.Progress =
                Parameters.Get(ParameterType.Relationship.ToString()).NormalizedValue;
            return buttonData;
        }

        public NavigationScreenData GetScreenData(NavigationElementType elementType)
        {
            var data = GameProcessingEcs.Instance.CurrentNavigationBlock.GetDefaultScreenData(elementType);
            data.Title = FullName;
            data.Description = RelationshipStatus;
            return data;
        }
    }
    
    public class Relationship
    {
        public Person Person;
        public RelationshipType RelationshipType;
    }
}