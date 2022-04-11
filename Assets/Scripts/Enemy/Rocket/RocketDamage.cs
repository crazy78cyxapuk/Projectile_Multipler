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
        [SerializeField] private int _damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ArrowProgression arrowProgression))
            {
                arrowProgression.TakeDamage(TypeGate.Subtraction, _damage);
                _rocketExplosion.Explosion();
            }
        }
    }
}
