using System;
using System.Collections;
using System.Collections.Generic;
using Arrow;
using TMPro;
using UnityEngine;

public class CounterArrows : MonoBehaviour
{
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private TMP_Text _textCount;

    private ArrowSpawn _arrowSpawn;

    private Camera _cam;

    private void Awake()
    {
        _playerUI.counterArrows = GetComponent<CounterArrows>();
    }

    private void OnEnable()
    {
        _cam = Camera.main;
        _arrowSpawn = _playerUI.GetArrowSpawn();
    }

    private void Update()
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
}
