using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Arrow;
using UnityEngine;

namespace Extension
{
    public class Floor : MonoBehaviour
    {
        [SerializeField] private ArrowData _arrowData;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Arrow"))
            {
                //other.gameObject.SetActive(false);
                _arrowData.RemoveLastArrow(other.gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}