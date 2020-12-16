using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterSoundManager : MonoBehaviour
{
    // setting all the clips of the player
    public AudioClip audioDamage;
    public AudioClip audioFist;
    public AudioClip audioKick;
    public AudioClip audioShoot; 
    public AudioClip audioThrow;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Methos to play all the clips of the player when in case
    public void PlayAudioDamage()
    {
        audioSource.PlayOneShot(audioDamage);
    }
    public void PlayAudioFist()
    {
        audioSource.PlayOneShot(audioFist);
    }
    public void PlayAudioKick()
    {
        audioSource.PlayOneShot(audioKick);
    }
    public void PlayAudioShoot()
    {
        audioSource.PlayOneShot(audioShoot);
    }
    public void PlayAudioThrow()
    {
        audioSource.PlayOneShot(audioThrow);
    }
}
