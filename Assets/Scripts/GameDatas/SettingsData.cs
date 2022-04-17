using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsData
{
    private static string _audio = "audio", _vibration = "vibro";

    private static int _enable = 0, _disable = 1;

    public static void SwapSettingAudio()
    {
        if (PlayerPrefs.GetInt(_audio) == _enable)
        {
            PlayerPrefs.SetInt(_audio, _disable);
        }
        else
        {
            PlayerPrefs.SetInt(_audio, _enable);
        }
    }
    
    public static void SwapSettingVibro()
    {
        if (PlayerPrefs.GetInt(_vibration) == _enable)
        {
            PlayerPrefs.SetInt(_vibration, _disable);
        }
        else
        {
            PlayerPrefs.SetInt(_vibration, _enable);
        }
    } 

    public static bool IsEnableAudio()
    {
        if (PlayerPrefs.GetInt(_audio) == _enable)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public static bool IsEnableVibro()
    {
        if (PlayerPrefs.GetInt(_vibration) == _enable)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
