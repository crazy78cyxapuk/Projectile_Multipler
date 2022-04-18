using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Extension
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private CinemachineVirtualCamera _vcam;
        [SerializeField] private float _timerShake = 0.5f;
        [SerializeField] private float _powerShake = 1;

        private CinemachineBasicMultiChannelPerlin _noise;

        private CameraShake _cameraShake;
        
        private void Awake()
        {
            _cameraShake = GetComponent<CameraShake>();
            _cameraData.SetCameraShake(_cameraShake);

            _noise = _vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void TurnShake()
        {
            StopAllCoroutines();

            StartCoroutine(Shake());
        }

        IEnumerator Shake()
        {
            _noise.m_AmplitudeGain = _powerShake;
            _noise.m_FrequencyGain = _powerShake;

            yield return new WaitForSeconds(_timerShake);
            
            _noise.m_AmplitudeGain = 0;
            _noise.m_FrequencyGain = 0;
        }
    }
}