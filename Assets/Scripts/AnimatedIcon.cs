using System;
using System.Collections.Generic;
using System.Linq;
using Animations;
using Popups;
using Save;
using Settings;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedIcon : MonoBehaviour
{
    private const int MaxCount = 20;
    private const int Offset = 250;
    private static bool[] _usedCell = new bool[MaxCount];
    
    private Transform _parent;
    private Camera _camera;

    private RawImage _rawImage;
    private int _freeCellIndex;
    private string _personId;

    public AnimatedFace FaceAnim { get; private set; }
        
    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
        _rawImage.transform.localScale = Vector3.one;
        _parent = GameObject.FindGameObjectWithTag("FaceParent").transform;
    }
    
    private void OnDestroy()
    {
        if (FaceAnim != null)
        {
            _usedCell[_freeCellIndex] = false;
            Destroy(FaceAnim.gameObject);
        }
        if (_camera != null)
        {
            Destroy(_camera.gameObject);
        }
    }

    public void Setup(Person person, int displaySize = 512)
    {
        if (!TrySetupAnimationIcon(person, displaySize))
        {
            _personId = person.Id;
            SetIcon(person);
        }
    }

    private bool TrySetupAnimationIcon(Person person, int displaySize)
    {
        //TODO Костыль для показа иконки для мужиков (нужно убрать когда будет настроенна анимация для мужиков)
        if (person.Gender == Genders.Male) return false;
        if (person.Id == _personId)
        {
            _usedCell[_freeCellIndex] = false;
            if (FaceAnim != null)
                Destroy(FaceAnim.gameObject);
            if (_camera != null)
                Destroy(_camera.gameObject);
        } else
        {
            _freeCellIndex = _usedCell.Select((c, i) => !c ? i : -1).First(i => i > -1);
        }

        var ageSetting = GameProcessingEcs.Instance.AgeStageSettings.GetAgeStageSetting(person.Age.TotalYears);

        var prefab = GameProcessingEcs.Instance.PrefabSet.FacePrefabs
            .FirstOrDefault(fp => ageSetting.AgeStage == fp.AgeStage);

        if (prefab == null)
            return false;
        if (prefab.FaceAnimPrefab == null)
            return false;

        var currentPrefab = prefab.FaceAnimPrefab;

        _personId = person.Id;

        FaceAnim = Instantiate(currentPrefab, _parent);
        FaceAnim.gameObject.SetActive(true);
        FaceAnim.transform.localPosition = Vector3.zero + Vector3.down * _freeCellIndex * Offset;
        _camera = Instantiate(GameProcessingEcs.Instance.PrefabSet.AnimatedIconCamera, _parent);
        _camera.transform.localPosition = Vector3.zero;
        _camera.transform.localPosition =
            FaceAnim.transform.localPosition + Vector3.back * 100 + Vector3.up * 70;
        
        var renderTexture =
            new RenderTexture(
                new RenderTextureDescriptor(displaySize, displaySize, RenderTextureFormat.Default));
        _rawImage.texture = renderTexture;
        _camera.targetTexture = renderTexture;
        _rawImage.transform.localScale = Vector3.one;
                
        FaceAnim.Setup(person);
        _usedCell[_freeCellIndex] = true;
        return true;
    }
    
    public void SetIcon(Sprite sprite)
    {
        _rawImage.texture = sprite.texture;
        _rawImage.transform.localScale = Vector3.one * 0.8f;
    }

    public void SetIcon(Person person)
    {
        var ageSetting = GameProcessingEcs.Instance.AgeStageSettings.GetAgeStageSetting(person.Age.TotalYears);
        if (ageSetting == null) return;

        var dummySprite = person.Gender == Genders.Male ? ageSetting.DummySpriteMale : ageSetting.DummySpriteFemale;

        if (dummySprite == null) return;
        _rawImage.texture = dummySprite.texture;
        _rawImage.transform.localScale = Vector3.one * 0.8f;
    }

}