using UnityEngine;
using UnityEngine.UI;

public class ManageSliders : MonoBehaviour
{
    public Slider soundVolumeSlider;
    public Slider mouseSensitivitySlider;

    private static ManageSliders instance;

    void Start()
    {
        // Load saved settings or set default values
        soundVolumeSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);
        mouseSensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 0.5f);
        
        // Apply initial settings
        SetSoundVolume(soundVolumeSlider.value);
        SetMouseSensitivity(mouseSensitivitySlider.value);

        // Listen for changes in sliders
        soundVolumeSlider.onValueChanged.AddListener(SetSoundVolume);
        mouseSensitivitySlider.onValueChanged.AddListener(SetMouseSensitivity);
    }

    void SetSoundVolume(float volume)
    {
        // Adjust sound volume
        AudioListener.volume = volume;

        // Save the setting
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

    void SetMouseSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
    }
}
