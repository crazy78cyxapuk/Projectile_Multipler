using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using UnityEngine;

public class TurnControllerTrigger : MonoBehaviour
{
    [SerializeField] private TurnController _turnController;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ArrowProgression arrowProgression))
        {
            _turnController.ExecuteTurnController();
            gameObject.SetActive(false);
        }
    }
}
