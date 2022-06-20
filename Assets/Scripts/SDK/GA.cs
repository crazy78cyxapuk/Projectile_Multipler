using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

public class GA : MonoBehaviour
{
    public static GA instance;

    private void Awake()
    {
        instance = this;
        
        GameAnalytics.Initialize();

        DontDestroyOnLoad(this);
    }
}
