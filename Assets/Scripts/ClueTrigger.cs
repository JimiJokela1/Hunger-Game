﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    public AudioClip[] speechSounds;    //  Assign on inspector
    public AudioClip clueSound;

    public string ClueText = "";

	bool isTriggeable = false;

    public bool isANonDialogueClue;

	private void Start()
	{
		// TODO: Listen for player input for 'E' and do callback eg. PlayerInteraction
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Collision with " + collision);
		if (collision.tag != "Player")
			return;

		Debug.Log("Trigger clue to interctive mode if player input is 'E'");
		isTriggeable = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Exit with " + other);

		if (other.tag != "Player")
			return;

		Debug.Log("Trigger clue to non-interactive mode so it doesn't trigger even if player input is 'E'");
		isTriggeable = false;

		// Hide whatever clue was shown when exiting the area
		SpeechArea.Instance.HideText();
	}

	void PlayerInteraction()
	{
		if (!isTriggeable)
			return;

		Debug.Log(ClueText);
		SpeechArea.Instance.ShowText(ClueText);

        var audioSource = SpeechArea.Instance.GetComponent<AudioSource>();

        if (!isANonDialogueClue)
        {
            audioSource.clip = speechSounds[(int)Random.Range(0, speechSounds.Length - 1)];
        }
        else
        {
            audioSource.clip = clueSound;
        }
        audioSource.Play();
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			PlayerInteraction();
		}
	}
}
