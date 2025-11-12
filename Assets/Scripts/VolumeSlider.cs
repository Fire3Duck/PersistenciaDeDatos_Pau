using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    private Slider _volumeSlider;
    [SerializeField] private Toggle _muteToggle;
    private bool muted;
    [SerializeField] private string _volumeParameter;

    void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);

        _muteToggle = GetComponentInChildren<Toggle>();
        _muteToggle.onValueChanged.AddListener(Mute);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float volume = PlayerPrefs.GetFloat(_volumeParameter, 1);

        _audioMixer.SetFloat(_volumeParameter, Mathf.Log10(volume) * 20);
        _volumeSlider.value = volume;

        string mutedValue = PlayerPrefs.GetString(_volumeParameter + "Mute", "False");

        if (mutedValue == "False")
        {
            muted = false;
        }
        else if (mutedValue == "True")
        {
            muted = true;
        }

        _muteToggle.isOn = !muted;
    }

    void ChangeVolume(float value)
    {
        _audioMixer.SetFloat(_volumeParameter, Mathf.Log10(value) * 20);
        _muteToggle.isOn = true;
    }

    void Mute(bool soundEnabled)
    {
        if (soundEnabled)
        {
            float lastVolume = PlayerPrefs.GetFloat(_volumeParameter, 1);
            _audioMixer.SetFloat(_volumeParameter, Mathf.Log(lastVolume) * 20);
            muted = false;
        }
        else
        {
            PlayerPrefs.SetFloat(_volumeParameter, _volumeSlider.value);
            _audioMixer.SetFloat(_volumeParameter, Mathf.Log(_volumeSlider.minValue) * 20);
            muted = true;
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _volumeSlider.value);
        PlayerPrefs.SetString(_volumeParameter + "Mute", muted.ToString());
    }
}
