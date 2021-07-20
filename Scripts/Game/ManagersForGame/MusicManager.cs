using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip music;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        if(source != null)
        {
            source.clip = music;
            source.playOnAwake = true;
            source.loop = true;
            source.Play();
        }
    }
}
