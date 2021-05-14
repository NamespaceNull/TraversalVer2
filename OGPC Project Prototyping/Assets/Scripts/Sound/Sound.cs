using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public Sound(AudioSource source, AudioClip clip, float volume)
    {
        this.source = source;
        this.source.clip = clip;
        this.source.volume = volume;
        this.source.pitch = 1;
        this.source.loop = false;
        this.source.playOnAwake = true;
    }

    [HideInInspector]
    public string name;
    
    public AudioClip clip;

    [HideInInspector]
    public bool playOnAwake;

    [HideInInspector]
    [Range(0f, 1f)]
    public float volume;

    [HideInInspector]
    public float pitch = 1;

    [HideInInspector]
    public bool loop = true;

    [HideInInspector]
    public AudioSource source;

}
