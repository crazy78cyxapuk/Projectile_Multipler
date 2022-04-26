using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Extension
{
    public class RotateToAngle : MonoBehaviour
    {
        [SerializeField] private Transform _model;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _targetAngle, _speed;

        private RotateToAngle _rotateToAngle;

        private float _currentAngle;

        private void Awake()
        {
            _rotateToAngle = GetComponent<RotateToAngle>();
            _rotateToAngle.enabled = false;

            if (_model == null)
            {
                _model = transform;
            }
        }

        private void OnEnable()
        {
            _currentAngle = 0;
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            float angle = _speed * Time.deltaTime;
            _currentAngle += angle;

            if (_currentAngle >= _targetAngle)
            {
                //_model.localEulerAngles += _direction * _targetAngle;
                _rotateToAngle.enabled = false;
            }
            else
            {
                _model.localEulerAngles += _direction * angle;
            }
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetAngle(float angle)
        {
            _targetAngle = angle;
        }
    }
}
