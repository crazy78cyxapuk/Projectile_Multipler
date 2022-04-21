using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private ViewHealthBar _viewHealthBar;
        [SerializeField] private float _totalHP;

        private float _minHP = 0;

        private void Awake()
        {
            _viewHealthBar.SetTotalHP(_totalHP);
        }

        public void TakeDamage(float count)
        {
            _totalHP -= count;
            
            if (_totalHP <= _minHP)
            {
                //_statusGame.ExecuteLose();
                _viewHealthBar.SetTarget(_minHP);
            }
            else
            {
                _viewHealthBar.SetTarget(_totalHP);
            }
        }

        public bool IsZeroHP()
        {
            return _totalHP <= _minHP;
        }
    }

    public enum TypeMover
    {
        Car, Airplane, Human
    }
}