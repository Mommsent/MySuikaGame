using UnityEngine;
using UnityEngine.UI;

public class LoadPrefs : MonoBehaviour
{
    [Header("Fullscreen Settings")]
    [SerializeField] private Toggle _fullScreenToggle;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("masterFullscreen"))
        {
            int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");

            if (localFullscreen == 1)
            {
                Screen.fullScreen = true;
                _fullScreenToggle.isOn = true;
            }
            else
            {
                Screen.fullScreen = false;
                _fullScreenToggle.isOn = false;
            }
        }
    }
}
