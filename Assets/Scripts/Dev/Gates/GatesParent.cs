using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gates
{
    public class GatesParent : MonoBehaviour
    {
        [SerializeField] private Transform _trueGate, _falseGate;
        [SerializeField] private Transform _trueCanvas, _falseCanvas;
        [SerializeField] private bool _isRandomPosition;

        private void Awake()
        {
            if (_isRandomPosition)
            {
                int rand = UnityEngine.Random.Range(0, 100);

                if (rand > 50)
                {
                    SwapGatesPosition();
                }
            }
        }

        private void SwapGatesPosition()
        {
            //(_trueGate.position, _falseGate.position) = (_falseGate.position, _trueGate.position);
            _trueGate.localEulerAngles = -_trueGate.localEulerAngles;
            _falseGate.localEulerAngles = -_falseGate.localEulerAngles;

            _falseCanvas.localEulerAngles = -_falseCanvas.localEulerAngles;
            _falseCanvas.localPosition -= new Vector3(0, .001f, 0);
            
            _trueCanvas.localEulerAngles = -_trueCanvas.localEulerAngles;
            _trueCanvas.localPosition -= new Vector3(0, .0015f, 0);
        }
    }
}