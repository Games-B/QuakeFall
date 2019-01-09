﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public AudioMixer audioMixer;
    [SerializeField] private AudioMixerGroup _audioGroup;

    // Use this for initialization
    void Awake () {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = _audioGroup;
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
	}
    private void Start()
    {
        Play("Music");
    }

    //FindObjectOfType<AudioManager>().Play("AudioName");

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
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
