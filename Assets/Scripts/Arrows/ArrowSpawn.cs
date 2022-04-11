using System;
using System.Collections;
using System.Collections.Generic;
using Extension;
using Gates;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

namespace Arrow
{
    public class ArrowSpawn : MonoBehaviour
    {
        [SerializeField] private StatusGame _statusGame;
        [SerializeField] private CameraData _cameraData;
        [SerializeField] private PlayerUI _playerUI;
        [SerializeField] private Transform _arrow;
        [SerializeField] private int _maxArrowCount = 199;
        [SerializeField] private int _minArrowCount = 33;
        
        [SerializeField] private int _arrowCount;
        [SerializeField] private float _radius = 0.01f;
        [SerializeField] private float _r = 12f;
        [SerializeField] private float _increaseRadius;

        [SerializeField] private TurnController _turnController;
        [SerializeField] private ArrowGrid _arrowGrid;
        
        private UnityAction _sendArrows;
        
        private int _nextArrowCount;

        private List<Transform> _allArrows = new List<Transform>();
        private float _firstRadius;

        public delegate void OnArrowsChanged(int arrowCount);
        public static event OnArrowsChanged ArrowsChanged;

        private void Awake()
        {
            _arrowCount = _minArrowCount;
            _firstRadius = _radius;

            _playerUI.SetArrowSpawn(GetComponent<ArrowSpawn>());

            _sendArrows += SendArrows;
            _turnController.AddAction(_sendArrows);
        }

        private void Start()
        {
            AddArrows(1);
        }

        public void AddArrows(int newArrowsCount)
        {
            int nextArrowCount = _arrowCount + newArrowsCount;

            for (int i = _arrowCount; i < nextArrowCount; i++)
            {
                if (_arrowCount >= _maxArrowCount)
                {
                    _arrowCount = nextArrowCount;

                    UpdateArrowsChanged();
                    return;
                }

                Vector3 rotation = new Vector3(0, 90, 0);
                Transform arrow = Instantiate(_arrow, transform.position, _arrow.rotation, transform);
                arrow.localEulerAngles = rotation;
                
                _allArrows.Add(arrow);

                float theta = i * _r * Mathf.PI / _maxArrowCount;
                float x = Mathf.Sin(theta) * _radius;
                float y = Mathf.Cos(theta) * _radius;

                transform.localScale = Vector3.one;
                arrow.transform.localPosition = new Vector3(x, y, 0); // + transform.position;
                arrow.name = (i - 33).ToString();

                if (i % 33 == 0)
                {
                    //_radius += 0.03f;
                    _radius += _increaseRadius;
                }

                _arrowCount++;
            }

            UpdateArrowsChanged();
        }

        public void RemoveArrow(int removeArrowsCount)
        {
            _nextArrowCount = _arrowCount - removeArrowsCount;

            //GAME OVER!!!

            if (_nextArrowCount <= _minArrowCount - 1)
            {
                _statusGame.ExecuteLose();
                _nextArrowCount = _minArrowCount;
                _radius = _firstRadius;
            }
            
            for (int i = _arrowCount; i > _nextArrowCount; i--)
            {
                if (_arrowCount >= _maxArrowCount)
                {
                    if (_nextArrowCount >= _maxArrowCount)
                    {
                        _arrowCount = _nextArrowCount; 
                        UpdateArrowsChanged();
                        return;
                    }
                    else
                    {
                        _arrowCount--;
                        UpdateArrowsChanged();
                        continue;
                    }
                }
                
                Transform arrow = _allArrows[_allArrows.Count - 1];
                _allArrows.Remove(arrow);
                arrow.gameObject.SetActive(false);

                if (i % 33 == 0 && _radius != _firstRadius)
                {
                    _radius -= _increaseRadius;
                }
                _arrowCount--;
            }

            UpdateArrowsChanged();
        }

        public int GetMaxCountArrows()
        {
            return _maxArrowCount;
        }

        public int GetMinCountArrows()
        {
            return _minArrowCount;
        }

        public int GetCountArrows()
        {
            return _arrowCount - _minArrowCount;
        }

        private void UpdateArrowsChanged()
        {
            ArrowsChanged(_arrowCount);
            _playerUI.UpdateCounter();

            if (_cameraData.cameraZoom != null)
            {
                _cameraData.cameraZoom.Zoom(GetCountArrows());
            }
        }

        private void SendArrows()
        {
            _arrowGrid.SetArrows(_allArrows);
        }
    }
}