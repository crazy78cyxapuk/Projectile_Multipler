using System;
using System.Collections;
using System.Collections.Generic;
using Gates;
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Gate gate))
            {
                TakeDamage(gate.GetType(), gate.GetCountBonus());
                gate.HideGate();
            }
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
        
        public void TakeDamage(TypeGate typeGate, int count)
        {
            switch (typeGate)
            {
                case TypeGate.Addition:
                    _arrowSpawn.AddArrows(count);
                    break;
                
                case TypeGate.Division:
                    int targetSub = _arrowSpawn.GetCountArrows() - _arrowSpawn.GetCountArrows() / count;
                    _arrowSpawn.RemoveArrow(targetSub);
                    break;
                
                case TypeGate.Multiplication:
                    int target = _arrowSpawn.GetCountArrows() * count - _arrowSpawn.GetCountArrows();
                    _arrowSpawn.AddArrows(target);
                    break;
                
                case TypeGate.Subtraction:
                    _arrowSpawn.RemoveArrow(count);
                    break;
            }
        }
    }
}