using System.Collections;
using System.Collections.Generic;
using Gates;
using UnityEngine;

[CreateAssetMenu]
public class GatesData : ScriptableObject
{
    [SerializeField] private List<GateData> _allGateData = new List<GateData>();

    public int GetValue(TypeGate targetType)
    {
        int num = 0;

        for (int i = 0; i < _allGateData.Count; i++)
        {
            if (_allGateData[i].GetType() == targetType)
            {
                num = _allGateData[i].GetRandomNumber();
                return num;
            }
        }

        return num;
    }
}

[System.Serializable]
public class GateData
{
    [SerializeField] private TypeGate _type;
    [SerializeField] private int _minCount, _maxCount;

    public TypeGate GetType()
    {
        return _type;
    }

    public int GetRandomNumber()
    {
        int rand = UnityEngine.Random.Range(_minCount, _maxCount);
        return rand;
    }
}