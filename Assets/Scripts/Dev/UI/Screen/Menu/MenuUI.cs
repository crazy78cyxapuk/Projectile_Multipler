using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ScreenPanel
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private TMP_Text _numberLvl;

        private void Awake()
        {
            InitUI();
        }

        public void StartGame()
        {
            _statusGame.ExecuteCutscene();

            gameObject.SetActive(false);
        }

        private void InitUI()
        {
            _numberLvl.SetText("LEVEL " + LevelData.GetNumberLevel());
        }
    }
}