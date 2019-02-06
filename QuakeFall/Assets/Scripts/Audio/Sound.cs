using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound {


    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [SerializeField] private bool _loop;

    [HideInInspector]
    public AudioSource source;

    public bool IsLoop()
    {
        return _loop;
    }
}
