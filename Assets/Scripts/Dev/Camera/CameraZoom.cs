using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Extension
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private CinemachineVirtualCamera _cinemachineCameraOffset;
        [SerializeField] private Vector3 _valueZoom;
        [SerializeField] private int _speedCount;

        private CinemachineTransposer _cinemachineTransposer;
        private Vector3 _firstZoom;

        private int _count, _currentCount;

        private int _maxCount = 199, _minCount = 1;

        private CameraZoom _cameraZoom;

        private bool _isActivate = false;

        private void Awake()
        {
            _cameraZoom = GetComponent<CameraZoom>();
            _cameraData.cameraZoom = _cameraZoom;

            _cinemachineTransposer = _cinemachineCameraOffset.GetCinemachineComponent<CinemachineTransposer>();
            
            _count = 0;

            _cameraZoom.enabled = false;
        }

        private void Update()
        {
            if (_isActivate)
            {
                UpdateCount();
            }
        }

        public void Zoom(int count)
        {
            _count = count;

            if (_count > _maxCount)
            {
                _count = _maxCount;
            }

            if (_count < _minCount)
            {
                _count = _minCount;
            }

            _cameraZoom.enabled = true;
        }

        private void UpdateCount()
        {
            if (_currentCount < _count)
            {
                _currentCount += _speedCount;

                if (_currentCount >= _count)
                {
                    DisableUpdateCount();
                }
            }
            else
            {
                _currentCount -= _speedCount;

                if (_currentCount <= _count)
                {
                    DisableUpdateCount();
                }
            }
            
            _cinemachineTransposer.m_FollowOffset = _firstZoom + _currentCount * _valueZoom;
        }

        private void DisableUpdateCount()
        {
            _currentCount = _count;
            _cameraZoom.enabled = false;
        }

        public void SetZoom()
        {
            _firstZoom = _cinemachineTransposer.m_FollowOffset;
            _isActivate = true;
        }
    }
}