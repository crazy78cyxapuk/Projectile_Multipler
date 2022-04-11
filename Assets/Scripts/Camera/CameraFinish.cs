using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Extension
{
    public class CameraFinish : MonoBehaviour
    {
        [SerializeField] private TurnController _turnController;
        [SerializeField] private float _speed;
        
        private UnityAction _disableFollow;
        
        private CinemachineTransposer _cinemachineTransposer;

        private CameraFinish _cameraFinish;

        private bool _isActivate = false;

        private void Awake()
        {
            _disableFollow += StopFollow;
            _turnController.AddAction(_disableFollow);
            
            _cinemachineTransposer = GetComponent<CinemachineVirtualCamera>()
                .GetCinemachineComponent<CinemachineTransposer>();

            _cameraFinish = GetComponent<CameraFinish>();
            _cameraFinish.enabled = false;
        }

        private void Update()
        {
            if (_isActivate)
            {
                MoveUP();
            }
        }

        private void StopFollow()
        {
            _isActivate = true;
            _cameraFinish.enabled = true;
        }

        private void MoveUP()
        {
            float tmp = _speed * Time.deltaTime;
            _cinemachineTransposer.m_FollowOffset += new Vector3(0, tmp, -tmp);

            _speed -= 2 * Time.deltaTime;
            if (_speed <= 0)
            {
                _cameraFinish.enabled = false;
            }
        }
    }
}
