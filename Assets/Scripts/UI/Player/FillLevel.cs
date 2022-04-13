using System;
using System.Collections;
using System.Collections.Generic;
using MPUIKIT;
using UnityEngine;

namespace Extension
{
    public class FillLevel : MonoBehaviour
    {
        [SerializeField] private PlayerUI _playerUI;
        [SerializeField] private MPImage _fill;

        private void Awake()
        {
            InitUI();
        }

        private void InitUI()
        {
            _fill.fillAmount = 0;
            _playerUI.fillLevel = GetComponent<FillLevel>();
        }

        public void Fill(double target)
        {
            _fill.fillAmount = (float)target;
        }
    }
}
