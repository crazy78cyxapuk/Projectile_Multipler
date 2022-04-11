using System;
using System.Collections;
using System.Collections.Generic;
using Extension;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private StatusGame _statusGame;
    [SerializeField] private PoolObject _poolObject;
    [SerializeField] private LevelsData _levelsData;

    private void Awake()
    {
        InitScriptables();
        CreateLevel();
    }

    private void InitScriptables()
    {
        _statusGame.ResetAllData();
        _poolObject.Init();
    }

    private void CreateLevel()
    {
        Instantiate(_levelsData.GetLevel(), Vector3.zero, Quaternion.identity);
    }
}
