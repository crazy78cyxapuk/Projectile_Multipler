using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using Extension;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private TurnController _turnController;
    [SerializeField] private StatusGame _statusGame;
    [SerializeField] private PoolObject _poolObject;
    [SerializeField] private LevelsData _levelsData;
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private ArrowData _arrowData;
    [SerializeField] private AnalyticsManager _analyticsManager;

    private void Awake()
    {
        InitScriptables();
        CreateLevel();
    }

    private void InitScriptables()
    {
        _statusGame.ResetAllData();
        _poolObject.Init();
        _turnController.Reset();
        _enemyData.Reset();
        _arrowData.Reset();
        
        _analyticsManager.InitEvents();
    }

    private void CreateLevel()
    {
        Instantiate(_levelsData.GetLevel(), Vector3.zero, Quaternion.identity);
    }
}
