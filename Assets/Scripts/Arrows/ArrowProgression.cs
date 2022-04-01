using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class ArrowProgression : MonoBehaviour
    {
        [SerializeField] private ArrowSpawn _arrowSpawn;

        private int _maxArrows, _minArrows;
        [SerializeField] private float _scaleMultiplier = 0.7f;
        [SerializeField] private float _scaleLimit = 0.25f;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            ArrowSpawn.ArrowsChanged += ChangeCollision;
        }

        private void OnDisable()
        {
            ArrowSpawn.ArrowsChanged -= ChangeCollision;
        }

        private void Init()
        {
            _maxArrows = _arrowSpawn.GetMaxCountArrows();
            _minArrows = _arrowSpawn.GetMinCountArrows();
        }

        public void ChangeCollision(int currentCount)
        {
            if (currentCount > _maxArrows)
            {
                return;
            }
            else
            {
                float scaleSize = Mathf.InverseLerp(_minArrows, _maxArrows, (float) currentCount)
                                  * _scaleMultiplier;
                BoxCollider collider = gameObject.GetComponent<BoxCollider>();
                if (scaleSize > _scaleLimit)
                {
                    collider.size = new Vector3(scaleSize, collider.size.y, collider.size.z);
                }
            }
        }
    }
}