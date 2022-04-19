using System;
using System.Collections;
using System.Collections.Generic;
using Extension;
using UnityEngine;
using UnityEngine.Events;

namespace Rocket
{
    public class RocketExplosion : MonoBehaviour
    {
        [SerializeField] private PoolObject _poolObject;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private TurnController _turnController;

        private UnityAction _explosion;

        private void Awake()
        {
            _explosion += () => Explosion(false);
            _turnController.AddAction(_explosion);
        }

        public void Explosion(bool isTurnShake)
        {
            gameObject.SetActive(false);
            _poolObject.AddExplosionFX(transform.position);

            if (isTurnShake)
            {
                _cameraData.TurnShake();
            }
        }
    }
}
