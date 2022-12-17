using Newtonsoft.Json;
using Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalizationDictionary 
{
    public static SystemLanguage Language => _currentLanguage;

    private static SystemLanguage _currentLanguage;
    private static Dictionary<string, string> _localization;
    private static GlobalSettings _settings;

    private static Dictionary<string, string> Localization
    {
        get
        {
            if (_localization == null)
            {
                string text = "";
                if (_settings != null)
                foreach (var json in _settings.localizations)
                {
                    if (json.language == _currentLanguage)
                    {
                        text = json.jSon.text;
                        break;
                    }
                }
                if (text == "")
                {
                    Debug.LogWarning($"Localization for {_currentLanguage} language not found");
                    if (_settings.localizations.Count > 0)
                    {
                        text = _settings.localizations[0].jSon.text;
                        _currentLanguage = _settings.localizations[0].language;
                        Debug.LogWarning($"Taking {_settings.localizations[0].language} localization instead");
                    }
                }
                _localization = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
            }
            return _localization;
        }
    }

    public static void Setup(GlobalSettings settings, SystemLanguage language)
    {
        _currentLanguage = language;
        _settings = settings;
    }

    public static string GetLocalizedString(string key)
    {
        if (Localization == null)
        {
            Debug.LogWarning($"Can't find {_currentLanguage} localization");
            return "";
        }
        if (!Localization.ContainsKey(key))
        {
            Debug.LogWarning($"Can't find localized string {key} in {_currentLanguage} localization file");
            return "";
        }
        return Localization[key];
    }
}
