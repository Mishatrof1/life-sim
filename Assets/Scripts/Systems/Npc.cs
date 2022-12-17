using System.Linq;
using Components;
using Components.Events;
using Components.Navigation;
using Core;
using DialogSystem;
using Leopotam.Ecs;
using Modules;
using Modules.Navigation;
using Settings;
using Settings.Accessories;
using Settings.Appearance;
using CharacterComponent = Components.CharacterComponent;

namespace Systems
{
    public class NpcCreation : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<NewParent> _newParentFilter;
        private EcsFilter<NewSibling> _newSiblingFilter;
        private EcsFilter<NewColleague> _newColleagueFilter;
        private EcsFilter<NextWorldDateIteration> _nextCycleFilter;
        private EcsFilter<Created> _characterCreatedFilter;
        private EcsFilter<ApplyDialogResult> _dialogResultFilter;
        private EcsFilter<CharacterComponent, ChangeOccupation> _changeOccupationCharacterFilter;
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<BlockComponent> _navigationFilter;
        private EcsFilter<BlockComponent, Active> _navigationActiveFilter;
        
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<NpcComponent> _npcFilter;
        
        private AppearanceSettingsList _facesSettings;
        private AccessorySettingsList _accessorySettingsList;
        private WorldGenerator _worldGenerator;

        public void Init()
        {
            foreach (var i in _npcFilter)
            {
                var npc = _npcFilter.Get1(i).Npc;
                npc.NavigationFilter = _navigationActiveFilter;
                npc.CharacterFilter = _characterFilter;
                _navigationFilter.RegisterElement(NavigationBlockType.Main, npc);
            }
        }

        public void Run()
        {
            foreach (var i in _characterCreatedFilter)
            {
                foreach (var npcIndex in _npcFilter)
                {
                    var npc = _npcFilter.Get1(npcIndex).Npc;
                    _navigationFilter.RemoveElement(NavigationBlockType.Main, npc);
                    _npcFilter.GetEntity(npcIndex).Destroy();
                }
            }

            var character = GetCurrentCharacter();
            if (character == null)
                return;

            foreach (var i in _newParentFilter)
            {
                var newParent = _newParentFilter.Get1(i);
                var parent = _worldGenerator.GenerateParentData(character, _facesSettings, newParent.Gender, _accessorySettingsList);
                parent.NavigationFilter = _navigationActiveFilter;
                parent.CharacterFilter = _characterFilter;
                _navigationFilter.RegisterElement(NavigationBlockType.Main, parent);

                _world.NewEntity()
                    .Replace(new NpcComponent {Npc = parent})
                    .Replace(new ParametersComponent {ParametersOwner = parent})
                    .Replace(new PersonComponent {Person = parent});
            }

            foreach (var i in _newSiblingFilter)
            {
                var newSibling = _newSiblingFilter.Get1(i);
                var sibling = _worldGenerator.GenerateSiblingData(character, _facesSettings, newSibling.Gender, _accessorySettingsList);
                sibling.NavigationFilter = _navigationActiveFilter;
                sibling.CharacterFilter = _characterFilter;
                _navigationFilter.RegisterElement(NavigationBlockType.Main, sibling);

                _world.NewEntity()
                    .Replace(new NpcComponent { Npc = sibling })
                    .Replace(new ParametersComponent { ParametersOwner = sibling })
                    .Replace(new PersonComponent { Person = sibling });
            }

            foreach (var i in _newColleagueFilter)
            {
                var newColleague = _newColleagueFilter.Get1(i);
                var colleague = newColleague.IsClassmate
                    ? _worldGenerator.GenerateClassmateData(character, _facesSettings, _accessorySettingsList)
                    : _worldGenerator.GenerateColleagueData(character, _facesSettings, _accessorySettingsList);
                colleague.CurrentOccupation = newColleague.Occupation;
                colleague.NavigationFilter = _navigationActiveFilter;
                colleague.CharacterFilter = _characterFilter;
                _navigationFilter.RegisterElement(NavigationBlockType.Main, colleague);
                
                _world.NewEntity()
                    .Replace(new NpcComponent {Npc = colleague})
                    .Replace(new ParametersComponent {ParametersOwner = colleague})
                    .Replace(new PersonComponent {Person = colleague});
            }

            foreach (var i in _nextCycleFilter)
            {
                var dateStart = WorldDate.FromYears(WorldDateModule.CurrentDate.TotalYears - 1);
                var dateEnd = WorldDateModule.CurrentDate;

                foreach (var j in _npcFilter)
                {
                    var npc = _npcFilter.Get1(j).Npc;
                    if (npc.IsAppearenceChanging(dateStart, dateEnd))
                    {
                        _world.NewEntity().Replace(new AppearanceChanged
                        {
                            Person = npc
                        });
                    }
                }

                DestroyUnusedNpc(_npcFilter, character);
            }
            
            foreach (var i in _changeOccupationCharacterFilter)
            {
                DestroyUnusedNpc(_npcFilter, character);
            }
            
            foreach (var i in _dialogResultFilter)
            {
                var entity = _dialogResultFilter.GetEntity(i);
                var dialogResult = entity.Get<ApplyDialogResult>();
                foreach (var npcIndex in _npcFilter)
                {
                    var npc = _npcFilter.Get1(npcIndex).Npc;
                    if (npc.Id != dialogResult.Participant)
                        continue;

                    if (dialogResult.ResultType != ParameterResultType.RelationshipType)
                        continue;
                    
                    var currRelationShip = npc.Relationships.FirstOrDefault(r => r.Person.Id == character.Id);
                    if (currRelationShip == null)
                    {
                        npc.Relationships.Add(new Core.Relationship { Person = character, RelationshipType = dialogResult.relationshipType });
                    }
                    else
                    {
                        if (dialogResult.Unfriend)
                        {
                            npc.Relationships.Remove(currRelationShip);
                        }
                        else
                        {
                            currRelationShip.RelationshipType = dialogResult.relationshipType;
                        }
                    }
                    entity.Destroy();
                }
            }
        }

        private void DestroyUnusedNpc(EcsFilter<NpcComponent> npcFilter, Core.Character character)
        {
            foreach (var i in npcFilter)
            {
                var npc = npcFilter.Get1(i).Npc;

                if (npc.Relationships?.Count == 0 &&
                    npc.CurrentOccupation?.Id != character?.CurrentOccupation?.Id)
                {
                    _navigationFilter.RemoveElement(NavigationBlockType.Main, npc);
                    npcFilter.GetEntity(i).Destroy();
                }
            }
        }
        
        private Core.Character GetCurrentCharacter()
        {
            foreach (var i in _charactersFilter)
            {
                return _charactersFilter.Get1(i).Character;
            }

            return null;
        }
    }
}