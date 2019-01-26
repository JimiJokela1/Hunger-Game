using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSystem : MonoBehaviour
{
	public AudioSource backgroundMusic;

	public AudioMixer audioMixer;

	private static SoundSystem _instance;
	public static SoundSystem Instance {
		get
		{
			return _instance = _instance ?? FindObjectOfType<SoundSystem>();
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		backgroundMusic.Play();
	}

	public void PlaySound(AudioSource audio)
	{
		audio.Play();
	}
}
