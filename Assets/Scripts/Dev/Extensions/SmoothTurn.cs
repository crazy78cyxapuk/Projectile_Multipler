using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public class SmoothTurn : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private Transform _target;

        [SerializeField] private bool _isBlockX = false;
        [SerializeField] private bool _isInfinitiTMP = false;
        [SerializeField] private bool _isRotateForward = false;

        [SerializeField] private float _maxTMP = 1f;
        
        private float _tmp;

        private SmoothTurn _smoothTurn;

        private Vector3 _targetDirection;

        //[SerializeField] private List<Transform> _allTargets = new List<Transform>();

        private void Awake()
        {
            _smoothTurn = GetComponent<SmoothTurn>();
        }

        private void OnEnable()
        {
            _tmp = 0;
        }

        private void LateUpdate()
        {
            if (_isBlockX)
            {
                Vector3 target = new Vector3(_target.position.x, transform.position.y, _target.position.z);
                var look = Quaternion.LookRotation(target - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, look, _tmp * Time.deltaTime);
            }
            else
            {
                var look = Quaternion.LookRotation(_target.position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, look, _tmp * Time.deltaTime);
            }

            if (_isRotateForward)
            {
                Vector3 euler = transform.localEulerAngles;
                transform.localEulerAngles = new Vector3(euler.x, -euler.y, euler.z);
            }

            if (_isInfinitiTMP)
            {
                _tmp += Time.deltaTime * _speed;
            }
            else
            {
                if (_tmp < _maxTMP)
                {
                    _tmp += Time.deltaTime * _speed;
                }
            }
        }

        private void DisableTurn()
        {
            _smoothTurn.enabled = false;
            _tmp = 0;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _targetDirection = _target.position;

            if (_smoothTurn == null)
            {
                _smoothTurn = GetComponent<SmoothTurn>();
            }
            
            _smoothTurn.enabled = true;
        }

        // public void SetAllTargets(List<Transform> targets)
        // {
        //     _allTargets = targets;
        // }
        //
        // public void SetRandomTarget()
        // {
        //     int count = _allTargets.Count;
        //
        //     if (count > 0)
        //     {
        //         bool isSetTarget = false;
        //         
        //         int rand = UnityEngine.Random.Range(0, count);
        //
        //         Transform target = _allTargets[rand];
        //
        //         if (target.gameObject.TryGetComponent(out EnemyProgress enemyProgress))
        //         {
        //             if(enemyProgress.IsDead())
        //             {
        //                 for (int i = 0; i < _allTargets.Count; i++)
        //                 {
        //                     if (target.gameObject.TryGetComponent(out EnemyProgress enemy))
        //                     {
        //                         if (enemy.IsDead() == false)
        //                         {
        //                             target = _allTargets[i];
        //                             isSetTarget = true;
        //                             break;
        //                         }
        //                     }
        //                 }
        //             }
        //             else
        //             {
        //                 isSetTarget = true;
        //             }
        //         }
        //
        //         if (isSetTarget)
        //         {
        //             SetTarget(target);
        //         }
        //     }
        // }
        //
        // public void RemoveTargets(Transform target)
        // {
        //     _allTargets.Remove(target);
        // }
    }
}