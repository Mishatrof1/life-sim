using System.Linq;
using Systems;
using Systems.Menu;
using Systems.NavigationElements;
using Animations;
using Assets.Scripts.Settings;
using Components;
using Components.Events;
using Core;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Save;
using Settings;
using Settings.Accessories;
using Settings.Appearance;
using Settings.Education;
using Settings.Job;
using Settings.Job.Simple;
using Settings.NpcCommunication;
using UnityEngine;
using NpcCommunication = Systems.NpcCommunication;
using SaveData = Systems.Save.SaveData;
using Components.Navigation;

public class GameProcessingEcs : MonoBehaviour
{
    public static GameProcessingEcs Instance { get; private set; }
        
    [Header("Settings")]
    [SerializeField] private GlobalSettings _globalSettings;
    [SerializeField] private WorldGenerationSettings _worldGenerationSettings;
    [SerializeField] private JobGenerationSettings _jobGenerationSettings;
    [SerializeField] private BeFriendSettings _beFriendSettings;
    [SerializeField] private BeFriendRequestSettings _beFriendRequestSettings;
    [SerializeField] private UnfriendSettings _unFriendSettings;
    [SerializeField] private UnfriendRequestSettings _unFriendRequestSettings;
    [SerializeField] private AskOutRequestSettings _askOutRequestSettings;
    [SerializeField] private ComplimentsSettings _complimentsSettings;
    [SerializeField] private InsultsSettings _insultsSettings;
    [SerializeField] private FlirtSettings _flirtSettings;
    [SerializeField] private DateSettings _dateSettings;
    [SerializeField] private AskOutSettings _askOutSettings;
    [SerializeField] private GiftSettings _giftSettings;
    [SerializeField] private SpendTimeSettings _spendTimeSettings;
    [SerializeField] private EmptySettings _emptySettings;
    [SerializeField] private ReactionsSettings _reactionsSettings;
    [SerializeField] private GiftReactionsSettings _giftReactionsSettings;
    [SerializeField] private EmptyReactionsSettings _emptyReactionsSettings;
    [SerializeField] private StudyDirectionSettings _universityDirectionSettings;
    [SerializeField] private PositionsSettings _positionsSettings;
    [SerializeField] private AppearanceSettingsList _facesSettings;
    [SerializeField] private AccessorySettingsList _accessorySettingsList;
    [SerializeField] private ArmySettings _armySettings;
    [SerializeField] private PrefabSet _prefabSet;
    [SerializeField] private NavigationSettings _navigationSettings;
    [SerializeField] private DialogsSet _dialogsSet;
    [SerializeField] private DialogInkSet _dialogInkSet;
    [SerializeField] private SpriteSet _spriteSet;
    [SerializeField] private EmployerSet _employerSet;
    [SerializeField] private PositionChainSet _positionChainSet;
    [SerializeField] private GradeConfiguration _gradeConfiguration;
    [SerializeField] private PartTimeJobGenerationSettings _partTimeJobGenerate;
    [SerializeField] private PartTimePositionSettings _partTimePositionSettings;
    [SerializeField] private AgeStageSettings _ageStageSettings;
    [SerializeField] private AskMoneySettings _askMoneySettings;

    [Header("Save")]
    [SerializeField] private SaveDataProvider _saveDataProvider;
    
    private Transform _popupParent;
    private Canvas _mainCanvas;

    private EcsWorld _world;
    private EcsSystems _systems;
    private EcsSystems _saveDataSystems;

    private WorldGenerator _worldGenerator;
    private PopupViewManager _popupViewManager;
    private WorldDateModule _worldDateModule;

    public PrefabSet PrefabSet => _prefabSet;
    public AgeStageSettings AgeStageSettings => _ageStageSettings;
    public SaveDataProvider SaveDataProvider => _saveDataProvider;
    public GlobalSettings GlobalSettings => _globalSettings;
    public Canvas MainCanvas => _mainCanvas;

    //Лютый костыль, надо избавится как можно скорее
    public NavigationBlock CurrentNavigationBlock { get; set; }

    private void Awake()
    {
        Instance = this;
        
        _popupParent = GameObject.FindGameObjectWithTag("PopupParent").transform;
        _mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        
        EventSystem.Subscribe<Popup_Close>(OnPopup_Close);
    }

    void Start ()
    {
        _worldGenerator = new WorldGenerator(_worldGenerationSettings, _employerSet, _globalSettings);
        _popupViewManager = new PopupViewManager(_popupParent);
        _worldDateModule = new WorldDateModule();
        
        _saveDataProvider.Load();
            
        _world = new EcsWorld ();
        _saveDataSystems = new EcsSystems(_world).Add(new SaveData());
        _systems = new EcsSystems(_world)
            .Add(new GameInit())
            .Add(new LocalizationSystem())
            .Add(new DialogInit())
            .Add(new Navigation())
            .Add(new Systems.NavigationElements.Job())
            .Add(new Systems.NavigationElements.Military())
            .Add(new Systems.NavigationElements.FindJob())
            .Add(new Menu())
            .Add(new WorldCycle())
            .Add(new CharacterHealth())
            .Add(new CharacterDeath())
            .Add(new CharacterCreation())
            .Add(new Systems.Location())
            .Add(new Education())
            .Add(new Systems.Character())
            .Add(new global::Systems.Job.Simple.Job())
            .Add(new PartTimeJob())
            .Add(new global::Systems.Job.Simple.Military())
            .Add(new DialogProcessing())
            .Add(new OccupationSelection())
            .Add(new OccupationChanging())
            .Add(new StatsChanging())
            .Add(new CharacterFinances())
            .Add(new Profile())
            .Add(new InkTest())
            .Add(new StartInkStory())
            .Add(new NpcCommunication())
            .Add(new NpcCommunicationDate())
            .Add(new NpcCommunicationAskOut())
            .Add(new NpcCommunicationBefriend())
            .Add(new NpcCommunicationGift())
            .Add(new NpcCommunicationUnFriend())
            .Add(new NpcCommunicationSpendTime())
            .Add(new NpcCommunicationFlirt())
            .Add(new NpcCommunicationAskMoney())
            .Add(new DialogStart())
            .Add(new ElementarySchool())
            .Add(new MiddleSchool())
            .Add(new HighSchool())
            .Add(new CommunityCollege())
            .Add(new University())
            .Add(new NpcCreation())
            .Add(new FlirtNpcActivity())
            .Add(new BeFriendNpcActivity())
            .Add(new UnFriendNpcActivity())
            .Add(new CommunicationNpcActivity())
            .Add(new ChatNpcActivity())
            .Add(new GiftNpcActivity())
            .Add(new InsultNpcActivity())
            .Add(new FightNpcActivity())
            .Add(new AskMoneyNpcActivity())
            .Add(new ComplimentNpcActivity())
            .Add(new DateNpcActivity())
            .Add(new AskOutNpcActivity())
            .Add(new SexCommunication())
            .Add(new SpendTimeCommunication())
            .Add(new BefriendRequestFromNpc())
            .Add(new UnfriendRequestFromNpc())
            .Add(new AskOutRequestFromNpc())
            .Add(new RelationshipProcessing())
            .Add(new RandomLog())
            .Add(new FindMilitary())
            .Add(new FindArmy())
            .Add(new FindPartTimeJob())
            .Add(new Systems.Screens())
            .Add(new Systems.ScreenTransitionAnimation())
            .Add(new Systems.Popups())
            .Add(new Systems.MainScreenView())
            .Add(new Systems.ActionsScreenView())
            .Add(new Systems.CharacterScreenView())
            .Add(new Systems.StartScreenView())
            .Add(_saveDataSystems)
            .OneFrame<NextWorldDateIteration>()
            .OneFrame<NewLocation>()
            .OneFrame<ChangeLocation>()
            .OneFrame<ShowProfile>()
            .OneFrame<HideCurrentPopup>()
            .OneFrame<NewParent>()
            .OneFrame<NewColleague>()
            .OneFrame<GetJobSuccess>()
            .OneFrame<Resign>()
            .OneFrame<Components.Events.NavigationPointChanged>()
            .OneFrame<ChoicesChanged>()
            .OneFrame<ChoiceSelected>()
            .OneFrame<New>()
            .OneFrame<ApplyJobButton>()
            .OneFrame<ApplyPartTimeButton>()
            .OneFrame<ApplyArmyButton>()
            .OneFrame<LocalizationChange>()
            .OneFrame<OccupationChanged>()
            .OneFrame<AppearanceChanged>()
            .OneFrame<RefreshActionScreenButtons>()
            .Inject(_worldDateModule)
            .Inject(_saveDataProvider)
            .Inject(_dialogsSet)
            .Inject(_dialogInkSet)
            .Inject(_worldGenerator)
            .Inject(_popupViewManager)
            .Inject(_globalSettings)
            .Inject(_spriteSet)
            .Inject(_prefabSet)
            .Inject(_employerSet)
            .Inject(_positionChainSet)
            .Inject(_beFriendSettings)
            .Inject(_beFriendRequestSettings)
            .Inject(_unFriendSettings)
            .Inject(_unFriendRequestSettings)
            .Inject(_askOutRequestSettings)
            .Inject(_complimentsSettings)
            .Inject(_insultsSettings)
            .Inject(_flirtSettings)
            .Inject(_reactionsSettings)
            .Inject(_jobGenerationSettings)
            .Inject(_gradeConfiguration)
            .Inject(_universityDirectionSettings)
            .Inject(_positionsSettings)
            .Inject(_armySettings)
            .Inject(_dateSettings)
            .Inject(_askOutSettings)
            .Inject(_giftSettings)
            .Inject(_emptySettings)
            .Inject(_emptyReactionsSettings)
            .Inject(_giftReactionsSettings)
            .Inject(_spendTimeSettings)
            .Inject(_navigationSettings)
            .Inject(_facesSettings)
            .Inject(_partTimePositionSettings)
            .Inject(_partTimeJobGenerate)
            .Inject(_accessorySettingsList)
            .Inject(_askMoneySettings);
        _systems.Init ();
    }
    
    void Update () {
        _systems.Run ();
    }

    void OnDestroy () {
        _systems.Destroy ();
        _world.Destroy ();
        
        EventSystem.Unsubscribe<Popup_Close>(OnPopup_Close);
    }
        
    private void OnApplicationFocus(bool hasFocus)
    {
        _world?.NewEntity().Replace(new Focus {HasFocus = hasFocus});
        _saveDataSystems?.Run();
    }
        
    private void OnApplicationPause(bool isPause)
    {
        _world?.NewEntity().Replace(new Pause {IsPaused = isPause});
        _saveDataSystems?.Run();
    }

    private void OnPopup_Close(Popup_Close e)
    {
        _world.NewEntity().Replace(new HideCurrentPopup());
    }
}
