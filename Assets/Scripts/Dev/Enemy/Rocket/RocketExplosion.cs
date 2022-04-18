using System.Collections;
using System.Collections.Generic;
using Extension;
using UnityEngine;

namespace Rocket
{
    public class RocketExplosion : MonoBehaviour
    {
        [SerializeField] private PoolObject _poolObject;
        [SerializeField] private CameraData _cameraData;
        
        public void Explosion()
        {
            gameObject.SetActive(false);
            _poolObject.AddExplosionFX(transform.position);
            
            _cameraData.TurnShake();
        }
    }
}
