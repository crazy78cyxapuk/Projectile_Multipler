using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUI : MonoBehaviour
{
    public void RepeatLevel()
    {
        SceneManager.LoadScene(0);
    }
}
