using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Arrow
{
    [CreateAssetMenu]
    public class ArrowData : ScriptableObject
    {
        private List<ArrowFly> _allArrowFly = new List<ArrowFly>();
        private UnityAction _actionForStart;

        public void Reset()
        {
            _allArrowFly.Clear();
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
    }
}
