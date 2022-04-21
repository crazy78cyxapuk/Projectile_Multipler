using System;
using System.Collections;
using System.Collections.Generic;
using MPUIKIT;
using UnityEditor.UIElements;
using UnityEngine;

namespace Extension
{
    public class ViewHealthBar : MonoBehaviour
    {
        private enum TypeMode
        {
            colorUp, colorDown, decrease
        }
        
        [SerializeField] private MPImage _image;
        [SerializeField] private float _speedDecrease, _speedColor;
        [SerializeField] private List<MPImage> _allImages = new List<MPImage>();

        private ViewHealthBar m_viewHealthBar;

        private float _targetCount;
        private float _totalHP;
        
        private TypeMode _currentMode;
        private float _timerForColorDown = 1f;

        private void Awake()
        {
            m_viewHealthBar = GetComponent<ViewHealthBar>();
            m_viewHealthBar.enabled = false;
            
            _image.fillAmount = 1f;
            _currentMode = TypeMode.colorUp;
            
            for (int i = 0; i < _allImages.Count; i++)
            {
                Color color = _allImages[i].color;
                color.a = 0;
                _allImages[i].color = color;
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void FixedUpdate()
        {

            switch (_currentMode)
            {
                case TypeMode.colorUp:
                    SwapColorUp();
                    break;
                
                case TypeMode.colorDown:
                    SwapColorDown();
                    break;
                
                 case TypeMode.decrease:
                    DecreaseFill();
                    break;
            }
        }

        public void SetTotalHP(float totalHP)
        {
            _totalHP = totalHP;
        }

        public void SetTarget(float target)
        {
            _targetCount = target;

            if (m_viewHealthBar == null)
            {
                m_viewHealthBar = GetComponent<ViewHealthBar>();
            }

            _currentMode = TypeMode.colorUp;
            m_viewHealthBar.enabled = true;
        }

        private void SwapColorUp()
        {
            for (int i = 0; i < _allImages.Count; i++)
            {
                Color color = _allImages[i].color;
                color.a += _speedColor * Time.deltaTime;
                _allImages[i].color = color;
            }

            bool allAlpha = true;
            for (int i = 0; i < _allImages.Count; i++)
            {
                if (_allImages[i].color.a < 1)
                {
                    allAlpha = false;
                }
            }

            if (allAlpha)
            {
                _currentMode = TypeMode.decrease;
            }
        }

        private void SwapColorDown()
        {
            for (int i = 0; i < _allImages.Count; i++)
            {
                Color color = _allImages[i].color;
                color.a -= _speedColor * Time.deltaTime;
                _allImages[i].color = color;
            }

            bool allAlpha = true;
            for (int i = 0; i < _allImages.Count; i++)
            {
                if (_allImages[i].color.a > 0)
                {
                    allAlpha = false;
                }
            }

            if (allAlpha)
            {
                for (int i = 0; i < _allImages.Count; i++)
                {
                    Color color = _allImages[i].color;
                    color.a = 0;
                    _allImages[i].color = color;
                }
                        
                m_viewHealthBar.enabled = false;
            }
        }

        private void DecreaseFill()
        {
            if (_image.fillAmount > _targetCount / _totalHP)
            {
                _image.fillAmount -= _speedDecrease * Time.deltaTime;
            }
            else
            {
                DisableFill();
            }
        }

        private void DisableFill()
        {
            _image.fillAmount = (_targetCount) / (_totalHP);

            StartCoroutine(WaitForColorDown());
        }

        IEnumerator WaitForColorDown()
        {
            yield return new WaitForSeconds(_timerForColorDown);
            
            _currentMode = TypeMode.colorDown;
        }
    }
}