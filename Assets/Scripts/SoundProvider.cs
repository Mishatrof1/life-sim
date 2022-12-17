using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundProvider : MonoBehaviour
{

    private static SoundProvider _instance;

    public static SoundProvider Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundProvider>();
            }
            return _instance;
        }
    }

    [SerializeField] private List<AudioClip> sounds;
    [SerializeField] private AudioSource backgroundMusic;

    private AudioSource source
    {
        get
        {
            return GetComponent<AudioSource>();
        }
    }

    public void PlaySound(string soundName)
    {
        foreach (AudioClip clip in sounds)
        {
            if (clip.name.Equals(soundName))
            {
                source.clip = clip;
                source.Play();
                return;
            }
        }
    }

    public bool SoundState { get; private set; }

    public void ChangeSoundState()
    {
        ChangeSoundState(!SoundState);
    }

    public void ChangeSoundState(bool state)
    {
        SoundState = state;
        if (backgroundMusic != null)
            backgroundMusic.mute = SoundState;
        source.mute = SoundState;
    }



    //todo savesettings
}
