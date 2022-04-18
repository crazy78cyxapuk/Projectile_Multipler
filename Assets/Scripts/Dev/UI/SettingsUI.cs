using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject _menu, _settings;
    
    [SerializeField] private Button _soundBtn, _vibroBtn;

    [SerializeField] private GameObject _enableAudio, _disableAudio, _enableVibro, _disableVibro;
    [SerializeField] private TMP_Text _textAudio, _textVibro;

    private string _enableAudioText = "Sound: on",
        _disableAudioText = "Sound: off",
        _enableVibroText = "Haptic: on",
        _disableVibroText = "Haptic: off";

    private void Awake()
    {
        _soundBtn.onClick.AddListener(TurnAudio);
        _vibroBtn.onClick.AddListener(TurnVibro);
        
        UpdateUI();
    }

    public void OpenSettings()
    {
        _menu.SetActive(false);
        _settings.SetActive(true);
    }

    public void CloseSettings()
    {
        _menu.SetActive(true);
        _settings.SetActive(false);
    }
    
    private void TurnAudio()
    {
        SettingsData.SwapSettingAudio();
        UpdateUI();
    }

    private void TurnVibro()
    {
        SettingsData.SwapSettingVibro();
        UpdateUI();
    }

    private void UpdateUI()
    {
        CheckAudio();
        CheckVibro();
    }

    private void CheckAudio()
    {
        if (SettingsData.IsEnableAudio())
        {
            _enableAudio.SetActive(false);
            _disableAudio.SetActive(true);
            _textAudio.SetText(_disableAudioText);
        }
        else
        {
            _enableAudio.SetActive(true);
            _disableAudio.SetActive(false);
            _textAudio.SetText(_enableAudioText);
        }
    }

    private void CheckVibro()
    {
        if (SettingsData.IsEnableVibro())
        {
            _enableVibro.SetActive(false);
            _disableVibro.SetActive(true);
            _textVibro.SetText(_disableVibroText);
        }
        else
        {
            _enableVibro.SetActive(true);
            _disableVibro.SetActive(false);
            _textVibro.SetText(_enableVibroText);
        }
    }
}
