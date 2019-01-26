using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Child : MonoBehaviour
{

	[Header("Name")]
	public string ID;

	[Header("References to Hiding and Carried/AtHome tilemaps")]
	public TilemapRenderer HidingTilemap;
	public TilemapRenderer CarriedTilemap;

	public Transform childWorldPosition;

	bool isTriggeable = false;

    public bool childIsGrounded;

	/// <summary>
	/// Child can be hiding (normally), or can be carried by Grandma or returned to Home (waiting for escape).
	/// </summary>
	public enum ChildState
	{
		Hiding, // Playing at the park or so really, but technically 'hidden'
		Carried, // Grandma found me
		AtHome, // Returned to home
        Grounded // At home and cannot escape
	}

	ChildState _childState;

	/// <summary>
	/// Changing child state automatically sets the proper tilemap graphic for the square
	/// </summary>
	public ChildState childState
	{
		get {
			return _childState;
		}
		set
		{
			_childState = value;

			// Show proper graphic
			HidingTilemap.enabled = _childState == ChildState.Hiding;
			CarriedTilemap.enabled = _childState != ChildState.Hiding;

			// NOTE: Should we also disable Collider2D so that Grandma can now walk to the space where the Child was located?
		}
	}

	private void Awake()
	{
		childState = ChildState.Hiding;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision with " + collision);
		if (collision.gameObject.tag != "Player")
			return;

		// Don't do anything if child is not hiding here
		if (childState != ChildState.Hiding)
		{
			return;
		}

		// If grandma already got us, try to activate again
		if (GrandmaMovement.Instance.Properties.carriedChildren.Contains(this))
		{
			Debug.LogWarning("Grandma already got us... this should not happen");
			return;
		}

		Debug.Log("Trigger Child " + ID + " to be catched if player input is 'E'");
		isTriggeable = true;
	}

	void OnCollisionExit2D(Collision2D other)
	{
		Debug.Log("Exit with " + other);

		if (other.gameObject.tag != "Player")
			return;

		Debug.Log("Trigger Child " + ID + " to non-interactive mode so it doesn't trigger even if player input is 'E'");
		isTriggeable = false;
	}

	void PlayerInteraction()
	{
		if (!isTriggeable)
			return;

		Debug.Log("Grandma found me, " + ID);
		childState = ChildState.Carried;

		// Don't allow duplicate action
		isTriggeable = false;

		GrandmaMovement.Instance.Properties.carriedChildren.Add(this);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			PlayerInteraction();
		}
	}
}

