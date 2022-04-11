using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [SerializeField] private StatusGame _statusGame;
    [SerializeField] private int _countEnemies;

    public void Reset()
    {
        _countEnemies = 0;
    }

    public void Kill()
    {
        _countEnemies -= 1;

        if (_countEnemies <= 0)
        {
            _statusGame.ExecuteWin();
        }
    }

    public void AddEnemy()
    {
        _countEnemies += 1;
    }

    public bool IsEnemyLife()
    {
        return _countEnemies > 0;
    }
}
