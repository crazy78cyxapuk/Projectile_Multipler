using System;
using System.Collections;
using System.Collections.Generic;
using Coin;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    [SerializeField] private CoinData _coinData;
    [SerializeField] private CoinIncreaser _coinIncreaser;

    private void Start()
    {
        InitUI();
    }

    private void InitUI()
    {
        int count = _coinData.GetWinCount();
        _coinIncreaser.SetTarget(count);
        
        _coinData.IncreaseCountCoins(count);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneNames.GetNameGameScene());
    }
}
