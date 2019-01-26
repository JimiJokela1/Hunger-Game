using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeArea : MonoBehaviour
{


	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Home entered by " + collision);
		if (collision.tag != "Player")
			return;

		if (GrandmaMovement.Instance.Properties.CarriesChild)
		{
			// TODO: Return the carried children and play sounds
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Home Exit by " + other);

		if (other.tag != "Player")
			return;

		// Change to different Audio environment...(?)

		// TODO: Trigger countdown for children escaping(?)
	}
}
