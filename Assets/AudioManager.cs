using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource source;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip music;
    public AudioClip opening;

    public void Awake()
    {
        instance = this;
    }

    public void StopSound()
    {
        source.Stop();
        source.loop = false;
    }

    public void PlaySound(AudioClip clip, bool looped)
    {
        source.clip = clip;
        source.loop = looped;
        source.Play();
    }
}
