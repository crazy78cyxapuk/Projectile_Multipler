using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Events;

namespace Extension
{
    public class StatusSplineFollower : MonoBehaviour
    {
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private SplineFollower _splineFollower;

        private UnityAction _startGame, _stopGame;

        private void Awake()
        {
            _startGame += StartFollow;
            _stopGame += StopFollow;
            
            _statusGame.AddActionStart(_startGame);
            _statusGame.AddActionLose(_stopGame);
            _statusGame.AddActionWin(_stopGame);
        }

        private void StartFollow()
        {
            _splineFollower.follow = true;
        }

        private void StopFollow()
        {
            _splineFollower.follow = false;
        }
    }
}