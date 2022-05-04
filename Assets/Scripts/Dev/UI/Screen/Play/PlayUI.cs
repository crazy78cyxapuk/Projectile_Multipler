using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayUI : MonoBehaviour
{
    [SerializeField] private TurnController _turnController;
    [SerializeField] private GameObject _helpPanel;

    private UnityAction _turnHelpPanel;

    private void Awake()
    {
        _turnHelpPanel += TurnHelpPanel;
        _turnController.AddAction(_turnHelpPanel);
    }

    public void RepeatLevel()
    {
        SceneManager.LoadScene(SceneNames.GetNameGameScene());
    }

    private void TurnHelpPanel()
    {
        _helpPanel.SetActive(true);
    }
}
