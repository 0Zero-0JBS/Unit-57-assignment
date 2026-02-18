using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] MusicSlider musicSlider;
    [SerializeField] SfxSlider sfxSlider;
    [SerializeField] AudioMixer music;
    [SerializeField] AudioMixer sfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMusicVolume", 100));
        SetVolume(PlayerPrefs.GetFloat("SavedSfxVolume", 100));
    }

    public void SetVolume(float _value)
    {
        if(_value < 1)
        {
            _value = .001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMusicVolume", _value);
        music.SetFloat("MusicVolume", Mathf.Log10(-value / 100) * 20f);
        PlayerPrefs.SetFloat("SavedSfxVolume", _value);
        sfx.SetFloat("SfxVolume", Mathf.Log10(-value / 100) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(musicSlider.value);
        SetVolume(sfxSlider.value);
    }

    public void RefreshSlider(float _value)
    {
        musicSlider.value = _value;
        sfxSlider.value = _value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
