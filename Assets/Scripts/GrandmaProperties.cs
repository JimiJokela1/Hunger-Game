using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaProperties : MonoBehaviour
{
	/// <summary>
	/// List reference to children who are carried by Grandma
	/// </summary>
	public List<Child> carriedChildren;

    public GameObject pressEInstruction;

    public int score;

    public bool grandmaIsAtHome;

    public GameObject grandmaSenseGraphic;


	private void Awake()
	{
		carriedChildren = new List<Child>();

        pressEInstruction.SetActive(false);

        grandmaSenseGraphic.SetActive(false);
    }

    /// <summary>
    /// Returns whether Grandma is carrying a child
    /// </summary>
    public bool CarriesChild
	{
		get { return carriedChildren.Count > 0; }
	}
}


