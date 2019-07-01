using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundClick : MonoBehaviour
{

    public AudioClip clip;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();

        source.clip = clip;
        source.playOnAwake = false;
    }
    public void PlaySound()
    {
        source.PlayOneShot(source.clip);
    }
}
