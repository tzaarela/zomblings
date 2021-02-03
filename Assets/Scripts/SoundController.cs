using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;

    public Sound[] Sounds;

    private void Awake()
    {
        if (Instance != this)
        {
            Instance = this;
        }

        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        PlaySound("BackgroundMusic");
    }

    public void PlaySound(string name)
    {
       Sound s = Array.Find(Sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
        }
        else
            return;
    }
}
