using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public delegate void ValueHadBeenSaved();
    public static event ValueHadBeenSaved HadSaved;

    [SerializeField] private TMP_Text _volumeText;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private float _defaultVolume = 1.0f;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _volumeName;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener((v) =>
        {
            UpdateValueOnChange(v);
        });
    }

    private void Start()
    {
        LoadValues();
    }
    public void UpdateValueOnChange(float value)
    {
        if (_mixer != null)
            _mixer.SetFloat(_volumeName, Mathf.Log(value) * 20f);

        if (_volumeText != null && _volumeSlider != null)
            SetValue(value);
    }

    public void VolumeApply()
    {
        float volumeValue = _volumeSlider.value;
        PlayerPrefs.SetFloat(_volumeName, volumeValue);
        HadSaved?.Invoke();
    }

    public void LoadValues()
    {
        float localSettingsParametr = PlayerPrefs.GetFloat(_volumeName);
        SetValue(localSettingsParametr);
    }

    private void SetValue(float value)
    {
        _volumeText.text = Mathf.Round(value * 100.0f).ToString() + "%";
        _volumeSlider.value = value;
    }
}
