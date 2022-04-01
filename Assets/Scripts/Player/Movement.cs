using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum TargetSide
    {
        Left, Right
    }
    
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _speedToSide;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _maxDistanceToSide = 4.5f;

        private Movement _movement;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _movement.enabled = false;
        }

        private void Update()
        {
            MoveForward();
        }

        public void StartMove()
        {
            _movement.enabled = true;
        }

        public void StopMove()
        {
            _movement.enabled = false;
        }

        private void MoveForward()
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }

        public void MoveToSide(TargetSide target)
        {
            switch (target)
            {
                case TargetSide.Left:

                    float targetLeft = _speedToSide * Time.deltaTime;
                    float offsetLeft = transform.localPosition.z - targetLeft;

                    if (offsetLeft > -_maxDistanceToSide)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, offsetLeft);
                    }
                    
                    break;
                
                case TargetSide.Right:
                    
                    float targetRight = _speedToSide * Time.deltaTime;
                    float offsetRight = transform.localPosition.z + targetRight;

                    if (offsetRight < _maxDistanceToSide)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, offsetRight);
                    }
                    
                    break;
            }
        }
    }
}