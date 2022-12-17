using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Settings.Accessories;
using Settings.Appearance;
using Spine;
using Spine.Unity;
using Spine.Unity.AttachmentTools;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Animations
{
    public class AnimatedFace : MonoBehaviour
    {
        private static bool _oneChange;
        
        [SerializeField] private AppearanceSettingsList _appearanceSettingsList;
        [SerializeField] private AccessorySettingsList _accessoriesSettings;
        
        private List<AnimationType> _emotionAnimations;
        private int _curAnimation = 0;
        private SkeletonAnimation _sa;
        
#if UNITY_EDITOR
        [Header("Editor only")]
        [SerializeField] private string _slotName;
        [SerializeField] private Vector2 _offset = Vector2.zero;
        [SerializeField] private float _scale = 1;

        private Person _currentPerson;
#endif

        private void Awake()
        {
            _sa = GetComponent<SkeletonAnimation>();
            _emotionAnimations = Enum.GetValues(typeof(AnimationType)).Cast<AnimationType>()
                .Where(x => !x.ToString().StartsWith("Idle")).ToList();
        }

        private void Start()
        {
            Play(AnimationType.IdleNeutral);
            _sa.AnimationState.Complete += OnEmotionComplete;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Play(AnimationType.Laugh);
            }

#if UNITY_EDITOR
            if (!string.IsNullOrEmpty(_slotName))
            {
                var slot = _sa.skeleton.FindSlot(_slotName);
                if (slot != null)
                {
                    switch (slot.Attachment)
                    {
                        case RegionAttachment regAtt:
                        {
                            regAtt.RegionOffsetX = _offset.x;
                            regAtt.RegionOffsetY = _offset.y;
                            regAtt.UpdateOffset();
                            break;
                        }
                        case MeshAttachment meshAtt:
                        {
                            meshAtt.RegionOffsetX = _offset.x;
                            meshAtt.RegionOffsetY = _offset.y;
                            meshAtt.UpdateUVs();
                            break;
                        }
                    }
                }
            }
#endif
        }

        public void OnDestroy()
        {
            _sa.AnimationState.Complete -= OnEmotionComplete;
        }

        
        public void Play(AnimationType animation)
        {
            _sa.AnimationName = AnimationUtils.GetAnimationName(animation);
        }

        public void PlayNextAnimation()
        {
            _curAnimation++;
            if (_curAnimation == _emotionAnimations.Count)
            {
                _curAnimation = 0;
            }
            Play(_emotionAnimations[_curAnimation]);
        }
        
        private void OnEmotionComplete(TrackEntry trackEntry)
        {
            if (!trackEntry.Animation.Name.StartsWith("idle_"))
            {
                Play(AnimationType.IdleNeutral);
            }
        }

        private Dictionary<string, AttachmentData> GetAppearanceRegionsData(Person person, Appearance appearance, AppearanceSettingsList settings)
        {
            var result = new Dictionary<string, AttachmentData>();
            var personAppearanceSettings = settings.AppearanceSettings.FirstOrDefault(s =>
                s.Gender == person.Gender && (person.Age.TotalYears >= s.MinAge && person.Age.TotalYears < s.MaxAge));
            
            if (personAppearanceSettings == null)
                return result;
            
            foreach (var appearanceGroupState in appearance.AppearanceGroupsState)
            {
                var appearanceGroupSettings =
                    personAppearanceSettings.AppearanceGroups.FirstOrDefault(g => g.name == appearanceGroupState.Key);
                if (appearanceGroupSettings == null)
                    continue;
                
                foreach (var slotData in appearanceGroupSettings.SlotList[appearanceGroupState.Value.Index].Slots)
                {
                    var colorGroupIndex = appearance.ColorGroupsState[slotData.ColorGroup.name].Index;
                    result.Add(slotData.Name, new AttachmentData
                    {
                        AttachmentName = slotData.Attachment,
                        RegionName = slotData.Region,
                        Color = slotData.ColorGroup.Colors[colorGroupIndex],
                        Offset = slotData.Offset,
                        Scale = slotData.Scale,
                        IgnoreChanges = slotData.IgnoreChanges
                    });
                }
            }
            return result;
        }
        
        private Dictionary<string, AttachmentData> GetAccessoriesRegionsData(Person person, Accessories accessories, AccessorySettingsList settings)
        {
            var result = new Dictionary<string, AttachmentData>();
            if (accessories == null)
                return result;
            
            foreach (var appliedAccessory in accessories.AppliedAccessories)
            {
                var accessorySettings = settings.AccessorySettings.FirstOrDefault(s => s.name == appliedAccessory.Key);
                if (accessorySettings == null)
                    continue;

                foreach (var slotData in accessorySettings.SlotLists[appliedAccessory.Value].Slots)
                {
                    var colorGroupIndex = accessories.ColorGroups[slotData.ColorGroup.name];
                    result.Add(slotData.Name, new AttachmentData
                    {
                        AttachmentName = slotData.Attachment,
                        RegionName = slotData.Region,
                        Color = slotData.ColorGroup.Colors[colorGroupIndex],
                        Offset = slotData.Offset,
                        Scale = slotData.Scale,
                        IgnoreChanges = slotData.IgnoreChanges
                    });
                }
            }
            return result;
        }

        private Color RandomColor()
        {
            return new Color(UnityEngine.Random.Range(0, 255f), UnityEngine.Random.Range(0, 255f),
                UnityEngine.Random.Range(0, 255f));
        }
        
        public void Setup(Person person)
        {
            Setup(_appearanceSettingsList, person, _accessoriesSettings);
        }
        
        private void Setup(AppearanceSettingsList appearanceSettingsList, Person person, AccessorySettingsList accessorySettingsList)
        {
#if UNITY_EDITOR
            _currentPerson = person;
#endif
            
            SetSkinCopy(Guid.NewGuid().ToString());
            
            foreach (var attachment in _sa.skeleton.Skin.Attachments)
            {
                SetAsEmpty(attachment.Attachment);
            }
            
            SetupAppearance(GetAppearanceRegionsData(person, person.Appearance, appearanceSettingsList));
            SetupAccessories(GetAccessoriesRegionsData(person, person.Accessories, accessorySettingsList));
        }

        private void SetSkinCopy(string newSkinId)
        {
            var copySkin = new Skin(newSkinId);
            _sa.skeleton.SetSkin("default");
            copySkin.CopySkin(_sa.skeleton.Skin);
            _sa.skeleton.Data.Skins.Add(copySkin);
            _sa.skeleton.SetSkin(newSkinId);
        }
        
        private void SetupAppearance(Dictionary<string, AttachmentData> regionsData)
        {
            ApplyAttachmentsChanges(regionsData);
        }
        
        private void SetupAccessories(Dictionary<string, AttachmentData> regionsData)
        {
            ApplyAttachmentsChanges(regionsData);
        }
        
        private void ApplyAttachmentsChanges(Dictionary<string, AttachmentData> regionsData)
        {
            foreach (var slot in _sa.Skeleton.Slots)
            {
                Attachment attachmentClone = null;
                if (regionsData.TryGetValue(slot.Data.Name, out var attachmentData))
                {
                    var attachmentName = attachmentData.AttachmentName;
                    var requiredRegionName = attachmentData.RegionName;
                    var atlasBase = _sa.skeletonDataAsset.atlasAssets.FirstOrDefault(a =>
                    {
                        var checkedAtlas = a.GetAtlas();
                        return checkedAtlas.Regions.Any(r => r.name == requiredRegionName);
                    });
                    
                    if (atlasBase != null)
                    {
                        var atlas = atlasBase.GetAtlas();
                        var regionClone = atlas.FindRegion(requiredRegionName).Clone();
                        var originalAttachment =
                            _sa.skeleton.Data.DefaultSkin.GetAttachment(slot.Data.Index, attachmentName);
                        
                        attachmentClone = originalAttachment.Copy();
                        attachmentClone.SetRegion(regionClone);
                        SetRegionValues(attachmentClone, originalAttachment);
                        if (!attachmentData.IgnoreChanges)
                        {
                            ApplyRegionChanges(attachmentClone, attachmentData.Offset);
                        }
                        slot.SetColor(attachmentData.Color);
                    }
                    else
                    {
                        attachmentClone = _sa.skeleton.Skin.GetAttachment(slot.Data.Index, attachmentName);
                        SetAsEmpty(attachmentClone);
                    }
                }
                
                if (attachmentClone != null)
                {
                    _sa.skeleton.Skin.SetAttachment(slot.Data.Index, attachmentClone.Name, attachmentClone);
                    slot.Attachment = attachmentClone;
                }
            }
        }

        private void SetRegionValues(Attachment attachment, Attachment originalAttachment)
        {
            switch (attachment)
            {
                case RegionAttachment regionAtt:
                {
                    regionAtt.UpdateOffset();
                    break;
                }
                case MeshAttachment meshAtt:
                {
                    var currentRegion = (AtlasRegion)meshAtt.RendererObject;
                    var meshAttOriginal = (MeshAttachment)originalAttachment;
                    var regionOriginal = (AtlasRegion)meshAttOriginal.RendererObject;
            
                    if (currentRegion.name == regionOriginal.name)
                    {
                        meshAtt.RegionHeight = meshAttOriginal.RegionHeight;
                        meshAtt.RegionWidth = meshAttOriginal.RegionWidth;
                        meshAtt.RegionOriginalHeight = meshAttOriginal.RegionOriginalHeight;
                        meshAtt.RegionOriginalWidth = meshAttOriginal.RegionOriginalWidth;
                        meshAtt.RegionOffsetX = meshAttOriginal.RegionOffsetX;
                        meshAtt.RegionOffsetY = meshAttOriginal.RegionOffsetY;
                    }
                    else
                    {
                        meshAtt.RegionOriginalHeight = meshAtt.RegionHeight;
                        meshAtt.RegionOriginalWidth = meshAtt.RegionWidth;
                        meshAtt.RegionOffsetX = 0;
                        meshAtt.RegionOffsetY = 0;
                    }
                    meshAtt.UpdateUVs();
                    break;
                }
            }
        }

        private void ApplyRegionChanges(Attachment attachment, Vector2 offset)
        {
            switch (attachment)
            {
                case RegionAttachment regionAtt:
                {
                    regionAtt.RegionOffsetX = offset.x;
                    regionAtt.RegionOffsetY = offset.y;
                    regionAtt.UpdateOffset();
                    break;
                }
                case MeshAttachment meshAtt:
                {
                    meshAtt.RegionOffsetX = offset.x;
                    meshAtt.RegionOffsetY = offset.y;        
                    meshAtt.UpdateUVs();
                    break;
                }
            }
        }
        
        private void SetAsEmpty(Attachment attachment)
        {
            switch (attachment)
            {
                case RegionAttachment regionAtt:
                {
                    regionAtt.ScaleX = 0;
                    regionAtt.ScaleY = 0;
                    regionAtt.UpdateOffset();
                    break;
                }
                case MeshAttachment meshAtt:
                {
                    meshAtt.RegionU = 0;
                    meshAtt.RegionU2 = 0;
                    meshAtt.RegionV = 0;
                    meshAtt.RegionV2 = 0;
                    meshAtt.UpdateUVs();
                    break;
                }
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Save changes")]
        public void SaveChanges()
        {
            SaveAppearanceChanges();
            SaveAccessoryChanges();
        }

        private void SaveAppearanceChanges()
        {
            var guids = AssetDatabase.FindAssets("t:AppearanceSettingsList", new[] {"Assets/Settings"});
            var asset = AssetDatabase.LoadAssetAtPath<AppearanceSettingsList>(AssetDatabase.GUIDToAssetPath(guids[0]));
            if (asset == null)
            {
                Debug.LogWarning($"Save changes failed. {nameof(AppearanceSettingsList)} not found.");
                return;
            }

            var personAppearanceSettings = asset.AppearanceSettings.FirstOrDefault(s =>
                s.Gender == _currentPerson.Gender && (_currentPerson.Age.TotalYears >= s.MinAge && _currentPerson.Age.TotalYears < s.MaxAge));
            if (personAppearanceSettings == null)
            {
                Debug.LogWarning($"Save changes failed. Not found appearance settings for current person.");
                return;
            }
            
            foreach (var slot in _sa.Skeleton.Slots)
            {
                var group = personAppearanceSettings.AppearanceGroups.FirstOrDefault(g =>
                    g.SlotList.Any(sl => sl.Slots.Any(s => s.Name == slot.Data.Name)));
                
                if (group == null)
                {
                    Debug.LogWarning($"{nameof(SaveAppearanceChanges)} Not found group for slot ({slot.Data.Name}).");
                    continue;
                }

                var groupItemIndex = _currentPerson.Appearance.AppearanceGroupsState[group.name].Index;
                var groupItem = group.SlotList[groupItemIndex];
                var slotSettings = groupItem.Slots.First(s => s.Name == slot.Data.Name);
                slotSettings.Offset = GetAttachmentOffset(slot);
            }
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }

        private void SaveAccessoryChanges()
        {
            var guids = AssetDatabase.FindAssets("t:AccessorySettingsList", new[] {"Assets/Settings"});
            var asset = AssetDatabase.LoadAssetAtPath<AccessorySettingsList>(AssetDatabase.GUIDToAssetPath(guids[0]));
            if (asset == null)
            {
                Debug.LogWarning($"Save changes failed. {nameof(AccessorySettingsList)} not found.");
                return;
            }
            
            foreach (var slot in _sa.Skeleton.Slots)
            {
                var group = _accessoriesSettings.AccessorySettings.FirstOrDefault(groupSettings =>
                    _currentPerson.Age.TotalYears >= groupSettings.MinAge && _currentPerson.Age.TotalYears < groupSettings.MaxAge &&
                    groupSettings.SlotLists.Any(sl => sl.Slots.Any(s => s.Name == slot.Data.Name)));
                
                if (group == null)
                {
                    Debug.LogWarning($"{nameof(SaveAccessoryChanges)} Not found group for slot ({slot.Data.Name}).");
                    continue;
                }

                if (_currentPerson.Accessories.AppliedAccessories.ContainsKey(group.name))
                {
                    var groupItemIndex = _currentPerson.Accessories.AppliedAccessories[group.name];
                    var groupItem = group.SlotLists[groupItemIndex];
                    var slotSettings = groupItem.Slots.First(s => s.Name == slot.Data.Name);
                    slotSettings.Offset = GetAttachmentOffset(slot);
                }
            }
            
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }

        private Vector2 GetAttachmentOffset(Slot slot)
        {
            switch (slot.Attachment)
            {
                case RegionAttachment regAtt:
                {
                    return new Vector2(regAtt.RegionOffsetX, regAtt.RegionOffsetY);
                }
                case MeshAttachment meshAtt:
                {
                    return new Vector2(meshAtt.RegionOffsetX, meshAtt.RegionOffsetY);
                }
                default:
                    return Vector2.zero;
            }
        }
#endif
    }

    public class AttachmentData
    {
        public string AttachmentName;
        public string RegionName;
        public Color Color;
        public Vector2 Offset;
        public float Scale;
        public bool IgnoreChanges;
    }
}
