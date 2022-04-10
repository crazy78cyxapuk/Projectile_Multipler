using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Rocket
{
    public class RocketMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rb;
        private Transform _target;

        private RocketMovement _rocketMovement;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rocketMovement = GetComponent<RocketMovement>();
            _rocketMovement.enabled = false;
        }

        private void FixedUpdate()
        {
            MoveToTarget();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _rocketMovement.enabled = true;
        }
        
        private void MoveToTarget()
        {
            _rb.velocity = transform.forward * _speed;
        }
    }
}