using System;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private GameProcessingEcs GameProcessingPrefab;
    [SerializeField] private SettingsProvider SettingsProviderPrefab;
    [SerializeField] private SoundProvider SoundProviderPrefab;

    private void Awake()
    {
        var currentGameProcessing = FindObjectOfType<GameProcessingEcs>();
        if (currentGameProcessing == null)
            Instantiate(GameProcessingPrefab);

        var currentSettingsProvide = FindObjectOfType<SettingsProvider>();
        if (currentSettingsProvide == null)
            Instantiate(SettingsProviderPrefab);

        var currentSoundProvider = FindObjectOfType<SoundProvider>();
        if (currentSoundProvider == null)
            Instantiate(SoundProviderPrefab);
    }
}