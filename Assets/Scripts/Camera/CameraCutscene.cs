using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Extension
{
    public class CameraCutscene : MonoBehaviour
    {
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private float _targetY, _targetZ;
        [SerializeField] private float _speed;

        [SerializeField] private CameraZoom _cameraZoom;
        
        private CinemachineTransposer _cinemachineTransposer;

        private CameraCutscene _cameraCutscene;

        private UnityAction _startCutscene;

        private void Awake()
        {
            _cameraCutscene = GetComponent<CameraCutscene>();
            _cameraCutscene.enabled = false;

            _cinemachineTransposer = GetComponent<CinemachineVirtualCamera>()
                    .GetCinemachineComponent<CinemachineTransposer>();

            _startCutscene += StartZoom;
            _statusGame.AddActionCutscene(_startCutscene);
        }

        private void Update()
        {
            IncreaseZoom();
        }

        private void IncreaseZoom()
        {
            if (_cinemachineTransposer.m_FollowOffset.y > _targetY)
            {
                _cinemachineTransposer.m_FollowOffset -= new Vector3(0, _speed * Time.deltaTime, 0);
            }
            else
            {
                _cinemachineTransposer.m_FollowOffset.y = _targetY;
            }
            
            if (_cinemachineTransposer.m_FollowOffset.z < _targetZ)
            {
                _cinemachineTransposer.m_FollowOffset += new Vector3(0, 0, _speed * Time.deltaTime);
            }
            else
            {
                _cinemachineTransposer.m_FollowOffset.z = _targetZ;
            }

            if (_cinemachineTransposer.m_FollowOffset.z == _targetZ
                && _cinemachineTransposer.m_FollowOffset.y == _targetY)
            {
                DisableZoom();
            }
        }

        private void DisableZoom()
        {
            _cameraCutscene.enabled = false;
            _cameraZoom.SetZoom();
            
            _statusGame.ExecuteStart();
        }

        private void StartZoom()
        {
            _cameraCutscene.enabled = true;
        }
    }
}