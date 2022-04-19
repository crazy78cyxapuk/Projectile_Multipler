using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using Gates;
using UnityEngine;

namespace Rocket
{
    public class RocketDamage : MonoBehaviour
    {
        [SerializeField] private RocketExplosion _rocketExplosion;
        private int _minDamage = 5, _maxDamage = 30, _damage;

        private void Awake()
        {
            _damage = UnityEngine.Random.Range(_minDamage, _maxDamage);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ArrowProgression arrowProgression))
            {
                arrowProgression.TakeDamage(TypeGate.Subtraction, _damage);
                _rocketExplosion.Explosion(true);
            }
        }
    }
}
