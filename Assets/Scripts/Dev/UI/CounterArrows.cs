using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CounterArrows : MonoBehaviour
{
    [SerializeField] private TurnController _turnController;
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private TMP_Text _textCount;

    private ArrowSpawn _arrowSpawn;

    private Camera _cam;

    private UnityAction _disableCounter;
    
    private void Awake()
    {
        _playerUI.counterArrows = GetComponent<CounterArrows>();

        _disableCounter += DisableCounter;
        _turnController.AddAction(_disableCounter);
    }

    private void OnEnable()
    {
        _cam = Camera.main;
        _arrowSpawn = _playerUI.GetArrowSpawn();
    }

    private void FixedUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector2 pos = _cam.WorldToScreenPoint(_arrowSpawn.transform.position);
        transform.position = pos + _offset;
    }

    public void UpdateTextCount(int count)
    {
        _textCount.SetText(count.ToString());
    }

    private void DisableCounter()
    {
        gameObject.SetActive(false);
    }
}
