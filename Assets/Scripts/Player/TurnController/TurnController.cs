using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class TurnController : ScriptableObject
{
    [SerializeField] private List<UnityAction> _allTurnAction = new List<UnityAction>();

    public void Reset()
    {
        _allTurnAction.Clear();
    }
    
    public void AddAction(UnityAction action)
    {
        _allTurnAction.Add(action);
    }
    
    public void ExecuteTurnController()
    {
        for (int i = 0; i < _allTurnAction.Count; i++)
        {
            _allTurnAction[i].Invoke();
        }
      
        _allTurnAction.Clear();
    }
}
