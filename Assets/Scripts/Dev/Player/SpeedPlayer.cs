using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpeedPlayer : ScriptableObject
{
    [Header("Скорость на взлёте")]
    [SerializeField] public float speedStart;
    
    [Header("Скорость на прямой")]
    [SerializeField] public float speedInLine;
    
    [Header("Скорость при посадке")]
    [SerializeField] public float speedFinish;
}
