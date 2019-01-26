using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays the AudioSource attached to this gameObject when player enters the area
/// </summary>
public class AudioArea : MonoBehaviour
{
    public enum AudioType {Music, Overlap};

    AudioSource thisAudioSource;

    public AudioClip audioClip;

    public AudioType audioType;

    private void Awake()
    {
        if (audioType == AudioType.Overlap)
        {
            if (thisAudioSource == null)
            {
                thisAudioSource = gameObject.AddComponent<AudioSource>();
            }
            thisAudioSource.playOnAwake = false;
            thisAudioSource.loop = true;
            thisAudioSource.clip = audioClip;            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log(this.GetType().FullName + ": Collision with " + collision);
        if (collision.tag != "Player")
            return;

        if (audioType == AudioType.Music)
            AudioManager.audioManager.ChangeTrack(audioClip);

        if (audioType == AudioType.Overlap)
            thisAudioSource.Play();
    }

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Exit with " + other);

		if (other.tag != "Player")
			return;

        if (audioType == AudioType.Overlap)
            thisAudioSource.Stop();

        if (audioType == AudioType.Music)
            AudioManager.audioManager.ChangeTrack(AudioManager.audioManager.mainTheme);
	}
}
