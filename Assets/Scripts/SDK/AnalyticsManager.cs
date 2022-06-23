using System;
using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.Events;

public class AnalyticsManager : MonoBehaviour
{
    [SerializeField] private StatusGame _statusGame;

    private UnityAction _start, _win, _lose;
    
    public void InitEvents()
    {
        _start += StartGame;
        _win += WinGame;
        _lose += LoseGame;
        
        _statusGame.AddActionLose(_lose);
        _statusGame.AddActionStart(_start);
        _statusGame.AddActionWin(_win);
    }

    private void StartGame()
    {
        string progress = "lvl: " + LevelData.GetNumberLevel();
        GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, progress);
        Debug.LogError(progress);
    }
    
    private void WinGame()
    {
        string progress = "lvl: " + LevelData.GetNumberLevel();
        GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, progress);
    }
    
    private void LoseGame()
    {
        string progress = "lvl: " + LevelData.GetNumberLevel();
        GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, progress);
    }
}
