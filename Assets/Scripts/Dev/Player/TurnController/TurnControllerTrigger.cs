using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using UnityEngine;

public class TurnControllerTrigger : MonoBehaviour
{
    [SerializeField] private TurnController _turnController;

    public void ExecuteTurnController()
    {
        _turnController.ExecuteTurnController();
    }
}
