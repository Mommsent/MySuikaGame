using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class VideoSettings : MonoBehaviour
{
    [Header("Resolution Dropdown")]
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    private Resolution[] _resolutions;
    private List<Resolution> _filtredResolutions;
    private double _currentRefreshRate;
    private int _currentResolutionIndex = 0;
    private bool _isFoundRes = false;

    private void Start()
    {
        SetStandartResolutionsMenuOptions();
    }

    private void SetStandartResolutionsMenuOptions()
    {
        _resolutions = Screen.resolutions;
        _filtredResolutions = new List<Resolution>();

        _resolutionDropdown.ClearOptions();
        _currentRefreshRate = Screen.currentResolution.refreshRateRatio.value;

        for (int i = 0; i < _resolutions.Length; i++)
        {
            if (_resolutions[i].refreshRateRatio.value == _currentRefreshRate)
            {
                _filtredResolutions.Add(_resolutions[i]);
            }
        }

        List<string> options = new List<string>();

        for (int i = 0; i < _filtredResolutions.Count; i++)
        {
            string option = $"{_filtredResolutions[i].width} X {_filtredResolutions[i].height} {_filtredResolutions[i].refreshRateRatio.value} Ghz";
            options.Add(option);
            if (_filtredResolutions[i].width == Screen.width && _filtredResolutions[i].height == Screen.height)
            {
                _currentResolutionIndex = i;
                SetResolution(_currentResolutionIndex);
                _isFoundRes = true;
            }
        }
        if (_isFoundRes == false)
        {
            _currentResolutionIndex = _filtredResolutions.Count - 1;
            SetResolution(_currentResolutionIndex);
        }

        _resolutionDropdown.AddOptions(options);
        SetResolution(_currentResolutionIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _filtredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, _isFullScreen);
        _resolutionDropdown.value = resolutionIndex;
    }

    [Header("FullScreen Toggle")]
    [SerializeField] private Toggle _fullScreenToggle;
    private bool _isFullScreen = true;

    private void OnEnable()
    {
        _fullScreenToggle.onValueChanged.AddListener((v) =>
        {
            SetFullScreen(v);
        });
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        isFullScreen = !isFullScreen;
        _isFullScreen = isFullScreen;
        Debug.Log(_isFullScreen);
    }


    public void GraphicsApplay()
    {
        PlayerPrefs.SetInt("masterFullscreen", (_isFullScreen == true ? 1 : 0));
    }
}
