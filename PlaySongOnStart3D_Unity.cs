using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
    AudioSource sound;

    public AudioClip song;
    void Start()
    {
        sound = GetComponent<AudioSource>();

        sound.PlayOneShot(song);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
