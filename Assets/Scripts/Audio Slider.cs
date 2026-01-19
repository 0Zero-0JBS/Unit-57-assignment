using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private TMPro.TextMeshProUGUI ValueText;
    [SerializeField]
    private AudioMixMode MixMode;
    [SerializeField]
    private AudioSource AudioSource1;
    [SerializeField]
    private AudioSource AudioSource2;
    [SerializeField]
    private AudioSource AudioSource3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }
    public void OnChangeSlider(float Value)
    {
        ValueText.SetText($"{Value.ToString("N4")}");

        switch (MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = Value;
                break;
            case AudioMixMode.LinearMixerVolume:
                Mixer.SetFloat("Volume", (-80 + Value * 100));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                break;
        }

        PlayerPrefs.SetFloat("Music Volume", Value);
        PlayerPrefs.Save();

        Mixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20));
    }
}
