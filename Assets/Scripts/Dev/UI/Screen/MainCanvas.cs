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

        [SerializeField] private float _delayShowScreen;

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
            StartCoroutine(WaitFinishScreen(true));
        }

        IEnumerator WaitFinishScreen(bool isWin)
        {
            yield return new WaitForSeconds(_delayShowScreen);
            
            _playUI.gameObject.SetActive(false);

            if (isWin)
            {
                _winUI.gameObject.SetActive(true);
            }
            else
            {
                _loseUI.gameObject.SetActive(true);
            }
        }

        private void OnLose()
        {
            StartCoroutine(WaitFinishScreen(false));
        }
    }
}
