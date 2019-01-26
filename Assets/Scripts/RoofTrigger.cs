using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofTrigger : MonoBehaviour {

	public Renderer environmentRoof;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Collision with " + collision);
		if (collision.tag != "Player")
			return;

		environmentRoof.enabled = false;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Exit with " + other);

		if (other.tag != "Player")
			return;

		environmentRoof.enabled = true;
	}
}
