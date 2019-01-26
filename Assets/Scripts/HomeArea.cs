using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeArea : MonoBehaviour
{
	private List<Child> childrenAtHome = new List<Child>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Home entered by " + collision);
		if (collision.tag != "Player")
			return;

		if (GrandmaMovement.Instance.Properties.CarriesChild)
		{
			Debug.Log("Grandma brought home children");

			// Return the carried children
			childrenAtHome.AddRange(GrandmaMovement.Instance.Properties.carriedChildren);
			foreach(Child child in childrenAtHome)
			{
				child.childState = Child.ChildState.AtHome;
			}

			// Remove kids from grandma
			GrandmaMovement.Instance.Properties.carriedChildren.Clear();
			

			// TODO:  and play sounds
            // TODO: Give a small bonus to the player --> Fill the hunger bar by x amount
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

	/// <summary>
	/// Removes all children from home and resets them to hiding in their hidey-holes
	/// </summary>
	public void ReleaseChildren()
	{
		foreach(Child child in childrenAtHome)
		{
			child.childState = Child.ChildState.Hiding;
		}

		childrenAtHome.Clear();
	}
}
