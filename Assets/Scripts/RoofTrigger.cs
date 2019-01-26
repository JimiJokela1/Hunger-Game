using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofTrigger : MonoBehaviour {

	public AudioClip environmentAudio;
	public Renderer environmentRoof;

	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Collision with " + collision);
		if (collision.tag != "Player")
			return;

		environmentRoof.enabled = false;
		//environmentAudio.Play()
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Exit with " + other);

		if (other.tag != "Player")
			return;

		environmentRoof.enabled = true;
	}
}
