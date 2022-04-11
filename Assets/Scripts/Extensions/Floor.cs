using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public class Floor : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Arrow"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}