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

        private int _numberBonus;

        private GateView _gateView;

        private void Awake()
        {
            _gateView = GetComponent<GateView>();
            
            InitGate();
        }

        private void InitGate()
        {
            _numberBonus = _gatesData.GetValue(_currentType);

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