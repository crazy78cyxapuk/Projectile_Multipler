using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _direction;

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

        }

        private void MoveForward()
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }
    }
}