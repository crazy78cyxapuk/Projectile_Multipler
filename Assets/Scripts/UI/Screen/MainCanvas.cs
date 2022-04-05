using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScreenPanel
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private MenuUI _menuUI;
        [SerializeField] private PlayUI _playUI;

        private UnityAction _startGame;
        
        private void Awake()
        {
            OnMenu();

            _startGame += OnPlay;
            _statusGame.AddActionStart(_startGame);
        }

        private void OnMenu()
        {
            _playUI.gameObject.SetActive(false);
        }

        public void OnPlay()
        {
            _menuUI.gameObject.SetActive(false);
            _playUI.gameObject.SetActive(true);
        }
    }
}
