using System.Collections;
using System.Collections.Generic;
using Coin;
using UnityEngine;

[CreateAssetMenu]
public class CoinData : ScriptableObject
{
    [SerializeField] private int _minWin, _maxWin, _minLose, _maxLose;
    
    [HideInInspector] public CoinMain CoinMain;

    private string _coin = "coin";

    public int GetCountCoins()
    {
        int count = PlayerPrefs.GetInt(_coin);
        return count;
    }

    public void IncreaseCountCoins(int count)
    {
        int target = GetCountCoins() + count;
        PlayerPrefs.SetInt(_coin, target);
        
        CoinMain.IncreaseUI(count);
    }

    public int GetWinCount()
    {
        int count = UnityEngine.Random.Range(_minWin, _maxWin);
        return count;
    }
    
    public int GetLoseCount()
    {
        int count = UnityEngine.Random.Range(_minLose, _maxLose);
        return count;
    }
}
