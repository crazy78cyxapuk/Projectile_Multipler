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
        [SerializeField] private WinUI _winUI;
        [SerializeField] private LoseUI _loseUI;

        private UnityAction _startGame, _loseGame, _winGame;
        
        private void Awake()
        {
            OnMenu();

            _startGame += OnPlay;
            _statusGame.AddActionStart(_startGame);

            _loseGame += OnLose;
            _winGame += OnWin;
            
            _statusGame.AddActionLose(_loseGame);
            _statusGame.AddActionWin(_winGame);
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

        private void OnWin()
        {
            _playUI.gameObject.SetActive(false);
            _winUI.gameObject.SetActive(true);
        }

        private void OnLose()
        {
            _playUI.gameObject.SetActive(false);
            _loseUI.gameObject.SetActive(true);
        }
    }
}
