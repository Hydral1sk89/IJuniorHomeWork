using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup Mixer;
    [SerializeField] private string MixerName;

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
            Mixer.audioMixer.SetFloat(MixerName, 0);
        else
            Mixer.audioMixer.SetFloat(MixerName, -80);
    }

    public void ChangeVolume(float volume)
    { 
        Mixer.audioMixer.SetFloat(MixerName, Mathf.Log10(volume) * 20);
    }
}