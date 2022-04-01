using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private ArrowSpawn _arrowSpawn;

        private Vector2 _startPos;
        private Vector2 _direction;
        private float _minDistanceTouch = 3f;
        private float _deceleration = 350f;
        
        private void Awake()
        {
            //_arrowPosition.AddArrows(1);
        }

        private void LateUpdate()
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
                //StartAllMovements();
                //_arrowSpawn.RemoveArrow(1);
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
                        break;
                }
            }
        }

        private void CheckMousePosition()
        {
            Vector2 mousePos = Input.mousePosition;
            _direction = (mousePos - _startPos) / _deceleration;

            float distanceMouse = Vector2.Distance(_startPos, mousePos);
            if (distanceMouse > _minDistanceTouch)
            {
                if (_direction.x > 0)
                {
                    _movement.MoveToSide(TargetSide.Right);
                }
                else
                {
                    _movement.MoveToSide(TargetSide.Left);
                }
            }
        }

        private void StartAllMovements()
        {
            
        }
    }
}
