using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableAudio : MonoBehaviour
{
    public AudioClip sound;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play() {
        _audioSource.PlayOneShot(sound, 1f);
    }
}
