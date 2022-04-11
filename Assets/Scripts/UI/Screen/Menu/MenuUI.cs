using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScreenPanel
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private StatusGame _statusGame;

        public void StartGame()
        {
            //_statusGame.ExecuteStart();
            _statusGame.ExecuteCutscene();
        }
    }
}