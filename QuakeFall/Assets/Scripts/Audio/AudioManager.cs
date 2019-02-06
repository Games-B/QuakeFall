using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public AudioMixer audioMixer;
    [SerializeField] private AudioMixerGroup _audioGroup;

    //  Use for calling Play();
    // _audioManager = GameObject.Find("MusicVolumeManager").GetComponent<AudioManager>(); - This is for Music.
    // _sfxManager = GameObject.Find("SFXVolumeManager").GetComponent<AudioManager>();     - This is for Sound Effects.

    // Use this for initialization
    void Awake () {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = _audioGroup;
            s.source.clip = s.clip;
            s.source.loop = s.IsLoop();

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
	}

    private void Start()
    {
        Play("Music", false);
    }

    //FindObjectOfType<AudioManager>().Play("AudioName");

    public void Play (string name, bool playOverSelf)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        Debug.Log(s);
        if (playOverSelf || (!playOverSelf && !s.source.isPlaying))
        {
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        Debug.Log(s);
        s.source.Stop();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetSFXVolume(float soundVolume)
    {
        audioMixer.SetFloat("soundVolume", soundVolume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("musicVolume", musicVolume);
    }
}
    