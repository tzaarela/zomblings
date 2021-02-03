using UnityEngine.Audio;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public Sound[] Sounds;
    void Awake()
    {
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Update()
    {
        
    }
}
