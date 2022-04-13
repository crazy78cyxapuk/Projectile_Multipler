using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Extension
{
    public class LocalMoveToTarget : MonoBehaviour
    {
        [SerializeField] private Vector3 _target;
        [SerializeField] private float _speed;

        private float _minDistance = 1f;

        private LocalMoveToTarget _localMoveToTarget;

        private void Awake()
        {
            _localMoveToTarget = GetComponent<LocalMoveToTarget>();
            _localMoveToTarget.enabled = false;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float dist = Vector3.Distance(transform.localPosition, _target);

            if (dist > _minDistance)
            {
                Vector3 dir = (_target - transform.localPosition).normalized;
                transform.localPosition += dir * _speed * Time.deltaTime;
            }
            else
            {
                _localMoveToTarget.enabled = false;
            }
        }
    }
}
