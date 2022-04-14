using System;
using System.Collections;
using System.Collections.Generic;
using Extension;
using UnityEngine;
using UnityEngine.Events;

namespace Arrow
{
    public class ArrowExplosion : MonoBehaviour
    {
        [SerializeField] private PoolObject _poolObject;
        [SerializeField] private StatusGame _statusGame;
        
        private List<Transform> _allArrows = new List<Transform>();

        private UnityAction _startExplosion;

        private void Awake()
        {
            _startExplosion += ExplosionArrows;
            _statusGame.AddActionWin(_startExplosion);
        }

        public void SetArrows(List<Transform> allArrows)
        {
            _allArrows = allArrows;
        }

        private void ExplosionArrows()
        {
            StartCoroutine(DelayExplosion());
        }

        IEnumerator DelayExplosion()
        {
            for (int i = 0; i < _allArrows.Count; i++)
            {
                if (_allArrows[i].gameObject.activeInHierarchy)
                {
                    _poolObject.AddExplosionFX(_allArrows[i].position);
                    _allArrows[i].gameObject.SetActive(false);

                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
    }
}
