using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private List<Movement> _allMovements = new List<Movement>();
        [SerializeField] private ArrowSpawn _arrowSpawn;

        private void Awake()
        {
            //_arrowPosition.AddArrows(1);
        }

        private void LateUpdate()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetMouseButton(0))
            {
                //StartAllMovements();
                _arrowSpawn.AddArrows(1);
            }
            
            if (Input.GetMouseButton(1))
            {
                //StartAllMovements();
                _arrowSpawn.RemoveArrow(1);
            }
        }

        private void StartAllMovements()
        {
            for (int i = 0; i < _allMovements.Count; i++)
            {
                _allMovements[i].StartMove();
            }
        }
    }
}
