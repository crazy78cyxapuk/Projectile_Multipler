using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Coin
{
    public class CoinIncreaser : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinText;
        [SerializeField] [Min(1)] private int _speed;

        [SerializeField] private int _target, _current;

        [SerializeField] private string _beforeText = "";

        private CoinIncreaser _coinIncreaser;
        
        private void Awake()
        {
            _coinIncreaser = GetComponent<CoinIncreaser>();
            _coinIncreaser.enabled = false;
            
            _current = 0;
        }

        private void Update()
        {
            Increase();
        }

        private void Increase()
        {
            _current += _speed;

            if (_current < _target)
            {
                _coinText.SetText(_beforeText + _current.ToString());
            }
            else
            {
                _coinText.SetText(_beforeText + _target.ToString());
                _coinIncreaser.enabled = false;
            }
        }

        public void SetTarget(int target, int current = default)
        {
            _target = target;
            _current = current;

            if (_coinIncreaser == null)
            {
                _coinIncreaser = GetComponent<CoinIncreaser>();
            }
            
            _coinIncreaser.enabled = true;
        }
    }
}
