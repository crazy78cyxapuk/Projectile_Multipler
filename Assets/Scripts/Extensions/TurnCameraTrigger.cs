using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using UnityEngine;

namespace Extension
{
    public class TurnCameraTrigger : MonoBehaviour
    {
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private Transform _targetParent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ArrowSpawn arrowSpawn))
            {
                _cameraData.SetParent(_targetParent);
            }
        }
    }
}
