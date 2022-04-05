using System.Collections;
using System.Collections.Generic;
using Arrow;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu]
public class PlayerUI : ScriptableObject
{
    private ArrowSpawn _arrowSpawn;

    [HideInInspector] public CounterArrows counterArrows;

    public void SetArrowSpawn(ArrowSpawn arrowSpawn)
    {
        _arrowSpawn = arrowSpawn;
    }

    public ArrowSpawn GetArrowSpawn()
    {
        return _arrowSpawn;
    }

    public void UpdateCounter()
    {
        if (counterArrows != null)
        {
            counterArrows.UpdateTextCount(_arrowSpawn.GetCountArrows());
        }
    }
}
