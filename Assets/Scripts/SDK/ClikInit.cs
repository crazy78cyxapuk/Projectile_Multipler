using System;
using System.Collections;
using System.Collections.Generic;
using Tabtale.TTPlugins;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClikInit : MonoBehaviour
{
    private void Awake()
    {
        //TTPCore.Setup();
        SceneManager.LoadScene(SceneNames.GetNameGameScene());
    }
}
