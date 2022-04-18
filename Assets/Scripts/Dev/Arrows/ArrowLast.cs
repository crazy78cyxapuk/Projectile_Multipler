using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class ArrowLast : MonoBehaviour
    {
        [SerializeField] private ArrowData _arrowData;

        private void OnTriggerEnter(Collider other)
        {
            //if()
        }

        private void RemoveArrow()
        {
            _arrowData.RemoveLastArrow(gameObject);
        }
    }
}
