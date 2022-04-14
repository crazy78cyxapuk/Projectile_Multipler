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

        [SerializeField] private Transform _targetForward;
        
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
                MoveForward();
            }
        }

        private void StopFollow()
        {
            transform.parent = null;
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

        private void MoveForward()
        {
            Vector3 myPos = new Vector3(transform.position.x, 0, 0);
            Vector3 target = new Vector3(_targetForward.position.x, 0, 0);
            float dist = Vector3.Distance(myPos, target);

            if (dist > 3f)
            {
                transform.position -= new Vector3(5, 0, 0) * Time.deltaTime;
            }
        }
    }
}
