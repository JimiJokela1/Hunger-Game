using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager audioManager;

    public AudioSource audioSource;
    public AudioClip mainTheme;

    void Awake()
    {
        if (audioManager)
        {
            DestroyImmediate(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            audioManager = this;
        }
    }

    public void ChangeTrack(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
