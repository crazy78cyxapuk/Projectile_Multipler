using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Extension
{
    public class StatusSplineFollower : MonoBehaviour
    {
        [SerializeField] private SpeedPlayer _speedPlayer;
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private SplineFollower _splineFollower;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private PlayerUI _playerUI;
        [SerializeField] private TurnController _turnController;
        
        private UnityAction _startGame, _stopGame, _increaseSpeed, _speedInLine;

        private StatusSplineFollower _statusSplineFollower;
        
        private void Awake()
        {
            _statusSplineFollower = GetComponent<StatusSplineFollower>();
            _statusSplineFollower.enabled = false;
            
            _startGame += StartFollow;
            _stopGame += StopFollow;
            
            _statusGame.AddActionStart(_startGame);
            _statusGame.AddActionLose(_stopGame);
            _statusGame.AddActionWin(_stopGame);

            _increaseSpeed += SetFinishSpeed;
            _turnController.AddAction(_increaseSpeed);

            _speedInLine += SetSpeedInLine;
            _cameraData.SetActionPlayerSpeed(_speedInLine);
            
            SetStartSpeed();
        }

        private void Update()
        {
            UpdatePercentUI();
        }

        private void StartFollow()
        {
            _splineFollower.follow = true;
            _statusSplineFollower.enabled = true;
        }

        private void StopFollow()
        {
            _splineFollower.follow = false;
            _statusSplineFollower.enabled = false;
        }

        public void SetParent()
        {
            _cameraData.SetParent(transform);
        }

        private void UpdatePercentUI()
        {
            if (_playerUI.fillLevel != null)
            {
                _playerUI.fillLevel.Fill(_splineFollower.GetPercent());
            }
        }

        private void SetFinishSpeed()
        {
            _splineFollower.followSpeed = _speedPlayer.speedFinish;
        }

        private void SetStartSpeed()
        {
            _splineFollower.followSpeed = _speedPlayer.speedStart;
        }

        private void SetSpeedInLine()
        {
            _splineFollower.followSpeed = _speedPlayer.speedInLine;
        }
    }
}