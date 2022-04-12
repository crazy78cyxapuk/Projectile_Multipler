using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Extension
{
    public class AnimationScale : MonoBehaviour
    {
        [SerializeField] private Vector3 _targetScale;
        [SerializeField] private float _speed;

        private AnimationScale _animationScale;

        private void Awake()
        {
            _animationScale = GetComponent<AnimationScale>();
            transform.localScale = Vector3.zero;
        }

        private void Update()
        {
            IncreaseScale();
        }

        private void IncreaseScale()
        {
            if (transform.localScale.x < _targetScale.x)
            {
                Vector3 dir = new Vector3(1, 1, 1) * _speed * Time.deltaTime;
                transform.localScale += dir;
            }
            else
            {
                transform.localScale = _targetScale;
                _animationScale.enabled = false;
            }
        }
    }
}