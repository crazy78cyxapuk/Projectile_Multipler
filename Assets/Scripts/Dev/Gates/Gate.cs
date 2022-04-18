using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gates
{
    [RequireComponent(typeof(GateView))]
    public class Gate : MonoBehaviour
    {
        [SerializeField] private GatesData _gatesData;
        [SerializeField] private TypeGate _currentType;

        [SerializeField] private GameObject _otherGate;

        [SerializeField] private bool _isRandomValue = false;
        [SerializeField] private int _value;

        private int _numberBonus;

        private GateView _gateView;

        private void Awake()
        {
            _gateView = GetComponent<GateView>();
            
            InitGate();
        }

        private void InitGate()
        {
            if (_isRandomValue)
            {
                _numberBonus = _gatesData.GetValue(_currentType);
            }
            else
            {
                _numberBonus = _value;
            }

            _gateView.InitView(_currentType, _numberBonus);
        }

        public void HideGate()
        {
            _otherGate.SetActive(false);
            gameObject.SetActive(false);
        }

        public TypeGate GetType()
        {
            return _currentType;
        }

        public int GetCountBonus()
        {
            return _numberBonus;
        }
    }
}