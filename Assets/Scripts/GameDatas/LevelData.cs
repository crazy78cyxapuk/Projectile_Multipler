using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelData
{
    private static string _level = "level";

    public static void IncreaseNumberLevel()
    {
        int lvl = PlayerPrefs.GetInt(_level) + 1;
        PlayerPrefs.SetInt(_level, lvl);
    }

    public static int GetNumberLevel()
    {
        int lvl = PlayerPrefs.GetInt(_level) + 1;
        return lvl;
    }
}
