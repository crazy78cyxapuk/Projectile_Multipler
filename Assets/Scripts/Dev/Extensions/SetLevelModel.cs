using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public class SetLevelModel : MonoBehaviour
    {
        [SerializeField] private TurnController _turnController;
        [SerializeField] private Transform _model;

        private void Awake()
        {
            _turnController.allModels = _model;
        }
    }
}
