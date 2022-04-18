using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public class RotateCanvas : MonoBehaviour
    {
        [SerializeField] private CameraData _cameraData;
        
        private Transform _camera;

        private RotateCanvas m_rotateCanvas;
        
        private void Awake()
        {
            //_camera = Camera.main.transform;
            _camera = _cameraData.cameraZoom.transform;
            m_rotateCanvas = GetComponent<RotateCanvas>();
        }

        void LateUpdate()
        {
            transform.LookAt(_camera);
            transform.Rotate(0, 180, 0);
            //m_rotateCanvas.enabled = false;
        }
    }
}