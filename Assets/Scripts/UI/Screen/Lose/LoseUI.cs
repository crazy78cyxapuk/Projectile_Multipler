using System.Collections;
using System.Collections.Generic;
using Coin;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUI : MonoBehaviour
{
    [SerializeField] private CoinData _coinData;
    [SerializeField] private CoinIncreaser _coinIncreaser;

    private void Start()
    {
        InitUI();
    }

    private void InitUI()
    {
        int count = _coinData.GetLoseCount();
        _coinIncreaser.SetTarget(count);
        
        _coinData.IncreaseCountCoins(count);
    }
    public void Repeat()
    {
        SceneManager.LoadScene(0);
    }
}
