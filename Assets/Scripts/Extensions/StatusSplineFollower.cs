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

        private UnityAction _startGame;

        private void Awake()
        {
            _startGame += StartFollow;
            _statusGame.AddActionStart(_startGame);
        }

        private void StartFollow()
        {
            _splineFollower.follow = true;
        }
    }
}