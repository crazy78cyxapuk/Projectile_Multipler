using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Coin
{
    public class CoinMain : MonoBehaviour
    {
        [SerializeField] private CoinData _coinData;
        [SerializeField] private TMP_Text _coinText;
        [SerializeField] private CoinIncreaser _coinIncreaser;

        private int _current;

        private void Awake()
        {
            InitUI();
        }

        private void InitUI()
        {
            _current = _coinData.GetCountCoins();
            _coinText.SetText(_current.ToString());

            _coinData.CoinMain = GetComponent<CoinMain>();
        }

        public void IncreaseUI(int count)
        {
            int target = _current + count;
            
            _coinIncreaser.SetTarget(target, _current);
        }
    }
}
