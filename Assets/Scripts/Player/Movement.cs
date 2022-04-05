using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public enum TargetSide
    {
        Left, Right
    }
    
    public class Movement : MonoBehaviour
    {
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private float _speed;
        [SerializeField] private float _speedToSide;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _maxDistanceToSide = 4.5f;
        [SerializeField] private float _minDistanceY, _maxDistanceY;

        private Movement _movement;
        
        private UnityAction _startGame, _stopGame;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _movement.enabled = false;

            _startGame += StartMove;
            _stopGame += StopMove;
            
            _statusGame.AddActionStart(_startGame);
            _statusGame.AddActionLose(_stopGame);
            _statusGame.AddActionWin(_stopGame);
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

        public void MoveToSide(Vector2 direction)
        {
            if (direction.x > 0)
            {
                float targetRight = _speedToSide * Time.deltaTime;
                float offsetRight = transform.localPosition.z + targetRight;

                if (offsetRight < _maxDistanceToSide)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, offsetRight);
                }
            }
            else
            {
                float targetLeft = _speedToSide * Time.deltaTime;
                float offsetLeft = transform.localPosition.z - targetLeft;

                if (offsetLeft > -_maxDistanceToSide)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, offsetLeft);
                }
            }

            if (direction.y > 0)
            {
                float targetUp = _speedToSide * Time.deltaTime;
                float offsetUp = transform.localPosition.y + targetUp;

                if (offsetUp < _maxDistanceY)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, offsetUp, transform.localPosition.z);
                }
            }
            else
            {
                float targetDown = _speedToSide * Time.deltaTime;
                float offsetDown = transform.localPosition.y - targetDown;

                if (offsetDown > _minDistanceY)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, offsetDown, transform.localPosition.z);
                }
            }
        }
    }
}