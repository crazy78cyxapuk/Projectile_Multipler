using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelsData : ScriptableObject
{
    [SerializeField] private List<Level> _allLevels = new List<Level>();

    public GameObject GetLevel()
    {
        return _allLevels[0].level;
    }
}

[Serializable]
public class Level
{
    public GameObject level;
}
