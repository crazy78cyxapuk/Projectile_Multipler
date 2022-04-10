using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public interface IPoolable
    {
        void OnSpawn();
        void OnDespawn();
    }
}