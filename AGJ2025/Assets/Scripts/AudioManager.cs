using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource musicSource;
    public Slider musicSlider;
    public Slider sfxSlider;

    private const string MusicPrefKey = "MusicVolume";
    private const string SFXPrefKey = "SFXVolume";

    void Start()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicPrefKey, 1f);
        SetMusicVolume(savedMusicVolume);

        float savedSFXVolume = PlayerPrefs.GetFloat(SFXPrefKey, 1f);
        SetSFXVolume(savedSFXVolume);

        // Update slider if present
        if (musicSlider != null)
            musicSlider.value = savedMusicVolume;
        // Update slider if present
        if (sfxSlider != null)
            sfxSlider.value = savedSFXVolume;

        // Start music if not playing
        if (!musicSource.isPlaying)
            musicSource.Play();

        // Hook up slider
        if (musicSlider != null)
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        if (sfxSlider != null)
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat(MusicPrefKey, Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f);
        PlayerPrefs.SetFloat(MusicPrefKey, volume);
        PlayerPrefs.Save();
    }
    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat(SFXPrefKey, Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f);
        PlayerPrefs.SetFloat(SFXPrefKey, volume);
        PlayerPrefs.Save();
    }
}