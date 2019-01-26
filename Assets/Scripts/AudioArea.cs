﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays the AudioSource attached to this gameObject when player enters the area
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioArea : MonoBehaviour
{

	//AudioSource environmentAudio;
 //   A

    public AudioClip audioClip;

	//private void Awake()
	//{
	//	//environmentAudio = GetComponent<AudioSource>();
	//}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        AudioManager.audioManager.ChangeTrack(audioClip);

        Debug.Log(this.GetType().FullName + ": Collision with " + collision);
        if (collision.tag != "Player")
            return;

        //environmentAudio.Play();
    }

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Exit with " + other);

		if (other.tag != "Player")
			return;

        AudioManager.audioManager.ChangeTrack(AudioManager.audioManager.mainTheme);
		//environmentAudio.Stop();
	}
}
