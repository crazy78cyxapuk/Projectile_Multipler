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
}
