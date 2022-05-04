using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabtale.TTPlugins;

public class AppsFlyerInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        TTPCore.Setup();
    }
}
