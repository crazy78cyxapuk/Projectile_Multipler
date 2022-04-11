using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;

namespace Extension
{
    public class TypeFX : MonoBehaviour
    {
        [SerializeField] private PoolObject _poolObject;
        [SerializeField] private PoolType _currentType;
        
        [SerializeField] private GameObject _targetObj;

        [SerializeField] public bool isCoroutineDeactivate = false;
        [SerializeField] public float timer;
        
        private void OnEnable()
        {
            if (isCoroutineDeactivate)
            {
                StartCoroutine(WaitDeactivate());
            }
        }

        private void OnParticleSystemStopped()
        {
            Hide();
        }

        private void Hide()
        {
            if (_targetObj == null)
            {
                _poolObject.RemoveObject(_currentType, gameObject);
            }
            else
            {
                _poolObject.RemoveObject(_currentType, _targetObj);
            }
        }

        IEnumerator WaitDeactivate()
        {
            yield return new WaitForSeconds(timer);
            
            Hide();
        }
    }
    
    // [CustomEditor(typeof(TypeFX))]
    // public class MyScriptEditor : Editor
    // {
    //     public override void OnInspectorGUI()
    //     {
    //         var myScript = target as TypeFX;
    //
    //         myScript.isCoroutineDeactivate = GUILayout.Toggle(myScript.isCoroutineDeactivate, "Is Coroutine Deactivate");
    //
    //         if (myScript.isCoroutineDeactivate)
    //             myScript.timer = EditorGUILayout.FloatField("Timer field: ", myScript.timer);
    //
    //     }
    // }
}