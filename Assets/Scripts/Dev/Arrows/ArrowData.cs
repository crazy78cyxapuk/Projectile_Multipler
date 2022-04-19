using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Arrow
{
    [CreateAssetMenu]
    public class ArrowData : ScriptableObject
    {
        [SerializeField] private StatusGame _statusGame;
        
        private List<ArrowFly> _allArrowFly = new List<ArrowFly>();
        private List<GameObject> _allLastArrows = new List<GameObject>();

        [HideInInspector] public ArrowGrid arrowGrid;

        public void Reset()
        {
            _allArrowFly.Clear();
            _allLastArrows.Clear();
        }
        
        public void AddArrowFly(ArrowFly arrowFly)
        {
            if (_allArrowFly.Contains(arrowFly) == false)
            {
                _allArrowFly.Add(arrowFly);
            }
        }

        public void DisableArrowFly()
        {
            for (int i = 0; i < _allArrowFly.Count; i++)
            {
                _allArrowFly[i].enabled = false;
            }
        }

        public void AddArrowLast(GameObject arrow)
        {
            if (_allLastArrows.Contains(arrow) == false)
            {
                _allLastArrows.Add(arrow);
            }
        }

        public void RemoveLastArrow(GameObject arrow)
        {
            arrowGrid.DestroyArrow(arrow.transform);
            
            if (_allLastArrows.Contains(arrow))
            {
                _allLastArrows.Remove(arrow);

                if (_allLastArrows.Count == 0)
                {
                    _statusGame.ExecuteLose();
                }
            }
        }
    }
}
