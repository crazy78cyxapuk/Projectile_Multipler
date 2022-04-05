using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class StatusGame : ScriptableObject
{
    private List<UnityAction> _actionsForCutscene = new List<UnityAction>();
    private List<UnityAction> _actionsForStart = new List<UnityAction>();
    private List<UnityAction> _actionsForWin = new List<UnityAction>();
    private List<UnityAction> _actionsForLose = new List<UnityAction>();

    public void AddActionCutscene(UnityAction action)
    {
        _actionsForCutscene.Add(action);
    }
   
    public void AddActionStart(UnityAction action)
    {
        _actionsForStart.Add(action);
    }
   
    public void AddActionWin(UnityAction action)
    {
        _actionsForWin.Add(action);
    }
   
    public void AddActionLose(UnityAction action)
    {
        _actionsForLose.Add(action);
    }

    public void RemoveActionLose(UnityAction action)
    {
        _actionsForLose.Remove(action);
    }

    public void ExecuteCutscene()
    {
        for (int i = 0; i < _actionsForCutscene.Count; i++)
        {
            _actionsForCutscene[i].Invoke();
        }
      
        _actionsForCutscene.Clear();
    }
   
    public void ExecuteStart()
    {
        for (int i = 0; i < _actionsForStart.Count; i++)
        {
            _actionsForStart[i].Invoke();
        }
      
        _actionsForStart.Clear();
    }
   
    public void ExecuteWin()
    {
        for (int i = 0; i < _actionsForWin.Count; i++)
        {
            _actionsForWin[i].Invoke();
        }
      
        _actionsForWin.Clear();
    }

    public void ExecuteLose()
    {
        for (int i = 0; i < _actionsForLose.Count; i++)
        {
            _actionsForLose[i].Invoke();
        }

        _actionsForLose.Clear();
    }
}
