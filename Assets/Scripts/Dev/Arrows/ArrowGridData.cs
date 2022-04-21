using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    [CreateAssetMenu]
    public class ArrowGridData : ScriptableObject
    {
        [Header("Минимальный радиус")] public float minGridRadius;
        [Header("Максимальный радиус")] public float maxGridRadius;
    }
}
