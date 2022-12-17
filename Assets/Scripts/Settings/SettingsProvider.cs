using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsProvider : MonoBehaviour
{

    [SerializeField] private Settings.ZodiacSettings _zodiacSettings;
    public Settings.ZodiacSettings ZodiacSettings => _zodiacSettings;
    
    public static SettingsProvider Instance { get; private set; }
    private void Awake()
    {
        Instance = this;

    }
}
