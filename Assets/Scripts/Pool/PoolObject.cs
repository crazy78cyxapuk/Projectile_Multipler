using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using TMPro;

namespace Extension
{
    [CreateAssetMenu]
    public class PoolObject : ScriptableObject
    {
        [SerializeField] private GameObject _explosionFX;
        [SerializeField] private GameObject _shotFX;
        
        [SerializeField] private GameObject _greenMark;
        [SerializeField] private GameObject _crystalUI;

        private Transform _canvas;
        private Vector3 _targetPositionCrystalUI;
        
        private ManagerPool _managerPool = new ManagerPool();
        private List<GameObject> _allFx = new List<GameObject>();

        public void Init()
        {
            _managerPool.Dispose();
            _managerPool.AddPool(PoolType.Fx);
            _allFx.Clear();
        }

        public void InitUI(Transform canvas, Vector3 targetPosCrystalUI)
        {
            _canvas = canvas;
            _targetPositionCrystalUI = targetPosCrystalUI;
        }

        // public void AddCrystalUI(Vector3 spawnPosition)
        // {
        //     _allFx.Add(_managerPool.Spawn(PoolType.Fx, _crystalUI, Vector3.zero, Quaternion.identity));
        //     Transform crystal = _allFx[_allFx.Count - 1].transform;
        //     crystal.parent = _canvas;
        //
        //     Vector3 targetPos = Camera.main.WorldToScreenPoint(spawnPosition);
        //     if (crystal.gameObject.TryGetComponent(out RectTransform rectTransform))
        //     {
        //         rectTransform.position = targetPos;
        //     }
        //
        //     if (crystal.gameObject.TryGetComponent(out MoverToTargetUI moverToTargetUI))
        //     {
        //         moverToTargetUI.SetTargetPosition(_targetPositionCrystalUI);
        //     }
        // }

        public void AddExplosionFX(Vector3 target)
        {
            _allFx.Add(_managerPool.Spawn(PoolType.Fx, _explosionFX, target, Quaternion.identity));
        }

        public void AddShotFX(Vector3 targetPos)
        {
            _allFx.Add(_managerPool.Spawn(PoolType.Fx, _shotFX, targetPos, Quaternion.identity));
            _allFx[_allFx.Count - 1].transform.localEulerAngles = new Vector3(90, 0, 0);
        }

        public void AddGreenMark(Vector3 targetPos)
        {
            _allFx.Add(_managerPool.Spawn(PoolType.Fx, _greenMark, targetPos, Quaternion.identity));
        }
        
        public void RemoveObject(PoolType type, GameObject obj)
        {
            _managerPool.Despawn(type, obj);
        }
    }
}