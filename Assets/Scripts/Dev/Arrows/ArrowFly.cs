using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Arrow
{
    public class ArrowFly : MonoBehaviour
    {
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private ArrowData _arrowData;
        [SerializeField] private float _minOffset, _maxOffset;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _minSpeed, _maxSpeed;
        [SerializeField] private bool _isFirstArrow = false;

        private float _currentSpeed;
        private float _currentOffset;

        private bool _isForward;

        private ArrowFly _arrowFly;

        private UnityAction _startArrow;
        
        private void OnEnable()
        {
            Init();
        }

        private void Update()
        {
            Move();
        }

        private void Init()
        {
            _currentSpeed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);

            if (UnityEngine.Random.Range(0, 10) > 5)
            {
                _isForward = true;
            }
            else
            {
                _isForward = false;
            }

            _currentOffset = GetOffset();

            _arrowFly = GetComponent<ArrowFly>();
            _arrowData.AddArrowFly(_arrowFly);
        }

        private void Move()
        {
            if (_isForward)
            {
                if (transform.localPosition.z < _currentOffset)
                {
                    transform.localPosition += _direction * _currentSpeed * Time.deltaTime;
                }
                else
                {
                    SwapData();
                }
            }
            else
            {
                if (transform.localPosition.z > _currentOffset)
                {
                    transform.localPosition -= _direction * _currentSpeed * Time.deltaTime;
                }
                else
                {
                    SwapData();
                }
            }
        }

        private void SwapData()
        {
            _isForward = !_isForward;
            _currentOffset = GetOffset();
            _currentSpeed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
        }

        public void SetFirstArrow()
        {
            _arrowFly.enabled = false;
            _startArrow += StartFirstArrow;
            //_statusGame.AddActionStart(_startArrow);
            _cameraData.SetActionArrowFly(_startArrow);
        }
        
        private void StartFirstArrow()
        {
            _arrowFly.enabled = true;
        }
        
        private float GetOffset()
        {
            if (_isForward)
            {
                float offset = UnityEngine.Random.Range(transform.localPosition.z, _maxOffset) + 1;
                return offset;
            }
            else
            {
                float offset = UnityEngine.Random.Range(_minOffset, transform.localPosition.z) - 1;
                return offset;
            }
        }
    }
}
