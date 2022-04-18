using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelsData : ScriptableObject
{
    [SerializeField] private List<Level> _allLevels = new List<Level>();
    [SerializeField] private bool _isTestMode = false;
    [SerializeField] private Level _testLevel;

    public GameObject GetLevel()
    {
        if (_isTestMode == false)
        {
            if (_allLevels.Count == 1)
            {
                return _allLevels[0].level;
            }
            else
            {
                int idLvl = LevelData.GetNumberLevel();
                idLvl -= 1;
                
                if (idLvl >= _allLevels.Count)
                {
                    int rand = UnityEngine.Random.Range(0, _allLevels.Count);
                    return _allLevels[rand].level;
                }
                else
                {
                    return _allLevels[idLvl].level;
                }
            }
        }
        else
        {
            return _testLevel.level;
        }
    }
}

[Serializable]
public class Level
{
    public GameObject level;
}
