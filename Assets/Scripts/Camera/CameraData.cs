using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Extension;
using UnityEngine;

[CreateAssetMenu]
public class CameraData : ScriptableObject
{
    private CameraShake _cameraShake;
    
    public CameraZoom cameraZoom;

    public void SetCameraShake(CameraShake cameraShake)
    {
        _cameraShake = cameraShake;
    }
    
    public void TurnShake()
    {
        _cameraShake.TurnShake();
    }

    public void SetParent(Transform target)
    {
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
