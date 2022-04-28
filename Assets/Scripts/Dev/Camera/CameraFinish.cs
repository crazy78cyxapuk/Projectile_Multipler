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
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private TurnController _turnController;
        [SerializeField] private float _speed;

        [SerializeField] private Transform _targetForward;

       // [SerializeField] private SmoothTurn _smoothTurn;
       [SerializeField] private RotateToAngle _rotateToAngle;
        
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

        private void OnEnable()
        {
            _targetForward = _enemyData.enemy;

            //_smoothTurn.SetSpeed(_cameraData.speedRotationCamera);
            //_smoothTurn.SetTarget(_enemyData.centerEnemy);
            
            _rotateToAngle.SetAngle(_cameraData.targetAngleFinish);
            _rotateToAngle.SetSpeed(_cameraData.speedRotationCamera);
            _rotateToAngle.enabled = true;

            GetComponent<CinemachineVirtualCamera>().enabled = false;
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
