using System;
using System.Collections;
using System.Collections.Generic;
using Extension;
using UnityEngine;

namespace Enemy
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private PoolObject _poolObject;
        [SerializeField] private GameObject _hole;
        [SerializeField] private GameObject _model;

        private bool _isDie = false;
        
        private void Awake()
        {
            _enemyData.AddEnemy();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Arrow") && _isDie == false)
            {
                _isDie = true;
                
                other.gameObject.SetActive(false);

                Explosion();
            }
        }

        private void Explosion()
        {
            _poolObject.AddExplosionFX(transform.position);
            _model.SetActive(false);

            if (_hole != null)
            {
                _hole.SetActive(true);
            }
            
            _enemyData.Kill();
        }
    }
}