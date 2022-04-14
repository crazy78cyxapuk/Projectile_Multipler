using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class ArrowGrid : MonoBehaviour
    {
        [SerializeField] private ArrowData _arrowData;
        [SerializeField] private float x_Space, y_Space;
        [SerializeField] private int _columnLength, _rowLength;

        [SerializeField] private List<Transform> _allArrows = new List<Transform>();

        private float x_Start = 0, y_Start = 0;

        private float _minX_Space = 0.1f, _maxX_Space = 3.5f;
        
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
            
            _arrowData.DisableArrowFly();

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

        public void EditSpace(Vector2 target)
        {
            float spaceTargetX = x_Space + target.x;

            if (spaceTargetX < _minX_Space)
            {
                x_Space = _minX_Space;
            }
            else
            {
                if (spaceTargetX > _maxX_Space)
                {
                    x_Space = _maxX_Space;
                }
                else
                {
                    x_Space = spaceTargetX;
                }
            }
            
            float spaceTargetY = y_Space + target.y;
            
            if (spaceTargetY < _minX_Space)
            {
                y_Space = _minX_Space;
            }
            else
            {
                if (spaceTargetY > _maxX_Space)
                {
                    y_Space = _maxX_Space;
                }
                else
                {
                    y_Space = spaceTargetY;
                }
            }
        }
    }
}
