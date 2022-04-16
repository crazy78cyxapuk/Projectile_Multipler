using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Extension;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class CameraData : ScriptableObject
{
    private CameraShake _cameraShake;
    
    [HideInInspector] public CameraZoom cameraZoom;

    private UnityAction _startArrowFly;

    public void SetCameraShake(CameraShake cameraShake)
    {
        _cameraShake = cameraShake;
    }

    public void SetActionArrowFly(UnityAction action)
    {
        _startArrowFly = action;
    }
    
    public void TurnShake()
    {
        _cameraShake.TurnShake();
    }

    public void SetParent(Transform target)
    {
        _startArrowFly?.Invoke();
        
        _cameraShake.transform.parent = target;

        if (_cameraShake.gameObject.TryGetComponent(out CinemachineVirtualCamera cinemachineVirtualCamera))
        {
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().enabled = false;
        }

        if (_cameraShake.gameObject.TryGetComponent(out LocalMoveToTarget localMoveToTarget))
        {
            localMoveToTarget.enabled = true;
        }
    }
}
