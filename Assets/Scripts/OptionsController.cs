using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle fullscreenToggle;
    public TMP_Text musicValueText;
    public TMP_Text sfxValueText;

    [Header("UI References")]
    public GameObject optionsPanel;

    void Start()
    {
        // Load PlayerPrefs' values
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 1f);
        bool isFull = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        // Apply volume directly 
        AudioManager.instance.SetMusicVolume(musicVol);
        AudioManager.instance.SetSFXVolume(sfxVol);

        // Fullscreen
        Screen.fullScreen = isFull;

        // Update sliders 
        // SetValueWithoutNotify won't trigger OnValueChanged
        musicSlider.SetValueWithoutNotify(musicVol);
        sfxSlider.SetValueWithoutNotify(sfxVol);
        fullscreenToggle.SetIsOnWithoutNotify(isFull);

        // Update texts
        musicValueText.text = (musicVol * 100).ToString("0");
        sfxValueText.text = (sfxVol * 100).ToString("0");

        // Add listeners after assigning initial values
        musicSlider.onValueChanged.AddListener(AudioManager.instance.SetMusicVolume);
        musicSlider.onValueChanged.AddListener(UpdateMusicText);

        sfxSlider.onValueChanged.AddListener(AudioManager.instance.SetSFXVolume);
        sfxSlider.onValueChanged.AddListener(UpdateSFXText);

        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }


    void UpdateMusicText(float value)
    {
        musicValueText.text = (value * 100).ToString("0");
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    void UpdateSFXText(float value)
    {
        sfxValueText.text = (value * 100).ToString("0");
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    { 
        optionsPanel.SetActive(false); 
    }

    private void SetMusicVolume(float value)
    {
        AudioManager.instance.SetMusicVolume(value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    private void SetSFXVolume(float value)
    {
        AudioManager.instance.SetSFXVolume(value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);

    }

}
