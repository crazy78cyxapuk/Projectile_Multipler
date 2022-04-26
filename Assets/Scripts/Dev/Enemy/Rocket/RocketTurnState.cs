using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using Extension;
using UnityEngine;
using UnityEngine.Events;

namespace Rocket
{
    public class RocketTurnState : MonoBehaviour
    {
        [SerializeField] private RocketExplosion _rocketExplosion;
        [SerializeField] private RocketMovement _rocketMovement;
        [SerializeField] private SmoothTurn _smoothTurn;
        [SerializeField] private float _smallRadius;
        
        private bool _isActivate;

        private float _timerExplosion = 15f;

        private void OnEnable()
        {
            _isActivate = false;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ArrowSpawn arrowSpawn))
            {
                if (_isActivate == false)
                {
                    ActivateAttack(arrowSpawn);
                }
                else
                {
                    _smoothTurn.enabled = false;
                    StartCoroutine(WaitExplosion());
                }
            }
        }

        IEnumerator WaitExplosion()
        {
            yield return new WaitForSeconds(_timerExplosion);
            
            _rocketExplosion.Explosion(false);
        }

        IEnumerator WaitActivateAttack()
        {
            yield return new WaitForSeconds(0.5f);

            _isActivate = true;
        }

        public void ActivateAttack(ArrowSpawn arrowSpawn)
        {
            GetComponent<SphereCollider>().radius = _smallRadius;
            Transform target = arrowSpawn.transform;
            _rocketMovement.SetTarget(target);
            _smoothTurn.SetTarget(target);
            _isActivate = true;
        }

        private void ActivateAttack()
        {
            GetComponent<SphereCollider>().radius = _smallRadius;
            _isActivate = true;
        }
    }
}