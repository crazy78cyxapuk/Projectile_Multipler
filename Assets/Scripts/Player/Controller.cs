using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private TurnController _turnController;
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private Movement _movement;
        [SerializeField] private ArrowSpawn _arrowSpawn;

        [SerializeField] private ArrowGrid _arrowGrid;

        private Vector2 _startPos;
        private Vector2 _direction;
        private float _minDistanceTouch = 2f;
        private float _deceleration = 350f;

        private UnityAction _swapController, _enableController, _stopGame;

        private Controller _controller;

        private bool _isMoveToSide = true;

        private void Awake()
        {
            _swapController += SwapController;
            _turnController.AddAction(_swapController);

            _enableController += StartController;
            _statusGame.AddActionStart(_enableController);

            _stopGame += StopController;
            _statusGame.AddActionWin(_stopGame);
            _statusGame.AddActionLose(_stopGame);
            
            _controller = GetComponent<Controller>();
            _controller.enabled = false;
        }

        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            // if (Input.GetMouseButtonDown(0))
            // {
            //     _startPos = Input.mousePosition;
            // }
            //
            // if (Input.GetMouseButton(0))
            // {
            //     CheckMousePosition();
            // }
            
            CheckInputMobile();
            
            if (Input.GetMouseButton(1))
            {
                _arrowSpawn.AddArrows(1);
            }
        }

        private void CheckInputMobile()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _startPos = Input.mousePosition;
                        break;
                    
                    case TouchPhase.Moved:
                        CheckMousePosition();
                        break;
                    
                    case TouchPhase.Stationary:
                        _startPos = Input.mousePosition;
                        //_movement.StopMoveToSide();
                        break;
                    
                    // case TouchPhase.Ended:
                    //     case TouchPhase.Canceled:
                    //         
                    //     _movement.StopMoveToSide();
                    //     
                    //     break;
                }
            }
        }

        private void CheckMousePosition()
        {
            Vector2 mousePos = Input.mousePosition;
            _direction = (mousePos - _startPos);
            _direction = CheckMaxDirection(_direction);

            float distanceMouse = Vector2.Distance(_startPos, mousePos);
            if (distanceMouse > _minDistanceTouch)
            {
                // if (_direction.x > 0)
                // {
                //     _movement.MoveToSide(TargetSide.Right);
                // }
                // else
                // {
                //     _movement.MoveToSide(TargetSide.Left);
                // }

                if (_isMoveToSide)
                {
                    _movement.MoveToSide(_direction, true);
                }
                else
                {
                    //_arrowGrid.EditSpace(_direction / 100);
                    _arrowGrid.EditSpace(_direction.x / 100);
                }
            }
            
            _startPos = mousePos;
        }

        private Vector2 CheckMaxDirection(Vector2 direction)
        {
            float max = 20f;
            
            if (Mathf.Abs(direction.x) > max)
            {
                if (direction.x < 0)
                {
                    direction.x = -max;
                }
                else
                {
                    direction.x = max;
                }
            }

            if (Mathf.Abs(direction.y) > max)
            {
                if (direction.y < 0)
                {
                    direction.y = -max;
                }
                else
                {
                    direction.y = max;
                }
            }

            return direction;
        }

        private void SwapController()
        {
            _isMoveToSide = false;
        }

        private void StartController()
        {
            _controller.enabled = true;
        }

        private void StopController()
        {
            _controller.enabled = false;
        }
    }
}
