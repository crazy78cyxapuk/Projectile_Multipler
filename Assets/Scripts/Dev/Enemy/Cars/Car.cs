using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
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
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private ArrowData _arrowData;
        [SerializeField] private Transform _centerEnemy;

        private bool _isDie = false;
        
        private void Awake()
        {
            _enemyData.AddEnemy(transform);

            if (_centerEnemy != null)
            {
                _enemyData.centerEnemy = _centerEnemy;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Arrow"))
            {
                if (_isDie == false)
                {
                    Explosion();

                    float countDamage = 10;
                    _healthBar.TakeDamage(countDamage);

                    if (_healthBar.IsZeroHP())
                    {
                        Die();
                    }
                }

                //other.gameObject.SetActive(false);
                _arrowData.RemoveLastArrow(other.gameObject);
                Destroy(other.gameObject);
            }
        }

        private void Explosion()
        {
            _poolObject.AddExplosionFX(transform.position);
        }

        private void Die()
        {
            _isDie = true;
            
            _model.SetActive(false);

            if (_hole != null)
            {
                _hole.SetActive(true);
            }
            
            _enemyData.Kill();
        }
    }
}