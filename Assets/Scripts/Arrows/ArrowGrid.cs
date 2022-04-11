using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class ArrowGrid : MonoBehaviour
    {
        [SerializeField] private float x_Space, y_Space;
        [SerializeField] private int _columnLength, _rowLength;

        [SerializeField] private List<Transform> _allArrows = new List<Transform>();

        private float x_Start = 0, y_Start = 0;

        private float _minX_Space = 0.1f, _maxX_Space = 5f;
        
        private ArrowGrid _arrowGrid;

        private void Awake()
        {
            _arrowGrid = GetComponent<ArrowGrid>();
            _arrowGrid.enabled = false;

            x_Space = _minX_Space;
        }

        private void LateUpdate()
        {
            Grid();
        }

        public void SetArrows(List<Transform> allArrows)
        {
            _allArrows = allArrows;

            _columnLength = _allArrows.Count / 3;

            _arrowGrid.enabled = true;
        }

        private void Grid()
        {
            int count = _allArrows.Count;

            for (int i = 0; i < count - 1; i += 2)
            {
                Vector3 pos = new Vector3(x_Start + (x_Space * (i % _columnLength)),
                    y_Start + (-y_Space * (i / _columnLength)),
                    0);

                _allArrows[i].localPosition = pos;

                if (i + 1 < count)
                {
                    _allArrows[i + 1].localPosition = new Vector3(-pos.x, pos.y, pos.z);
                }
            }
        }

        public void EditSpace(float target)
        {
            float spaceTarget = x_Space + target;

            if (spaceTarget < _minX_Space)
            {
                x_Space = _minX_Space;
                return;
            }

            if (spaceTarget > _maxX_Space)
            {
                x_Space = _maxX_Space;
                return;
            }

            x_Space = spaceTarget;
        }
    }
}
