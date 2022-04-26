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

        [SerializeField] private float _speedRotate;

        private Vector2 _startPos;
        private Vector2 _direction;
        private float _minDistanceTouch = 2f;
        private float _deceleration = 350f;

        private UnityAction _swapController, _enableController, _stopGame;

        private Controller _controller;

        private bool _isMoveToSide = true;

        private Transform _levelModel;

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
#if UNITY_ANDROID
            CheckInputMobile();
#endif

#if  UNITY_EDITOR
            CheckInputEditor();
#endif
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
                        break;
                }
            }
        }

        private void CheckInputEditor()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startPos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                CheckMousePosition();
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
                if (_isMoveToSide)
                {
                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!_movement.MoveToSide(_direction, true);
                    RotateLevelModel(-_direction.x);
                }
                else
                {
                    //_arrowGrid.EditSpace(_direction / 100);
                    _arrowGrid.EditSpace(_direction.x / 50);
                }
            }
            
            _startPos = mousePos;
        }

        private void RotateLevelModel(float direction)
        {
            float speed = direction * _speedRotate * Time.deltaTime;
            Vector3 target = new Vector3(1, 0, 0) * speed;
            //_levelModel.eulerAngles += target;
            _levelModel.Rotate(target);
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
            _levelModel = _turnController.allModels;
            _controller.enabled = true;
        }

        private void StopController()
        {
            _controller.enabled = false;
        }
    }
}
