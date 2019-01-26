using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    public static ChildManager childManager;

    public List<Child> childrenAtHome;

    public List<GameObject> allChildren;

    private void Awake()
    {
        childManager = this;
    }

    void Start()
    {
        childrenAtHome = new List<Child>();


        var children = FindObjectsOfType<Child>();
        allChildren = new List<GameObject>();
        foreach (var child in children)
        {
            allChildren.Add(child.gameObject);
        }
    }

    /// <summary>
	/// Removes all children from home and resets them to hiding in their hidey-holes
	/// </summary>
	public void ReleaseChildren()
    {
        foreach (Child child in childrenAtHome)
        {
            child.childState = Child.ChildState.Hiding;
        }

        childrenAtHome.Clear();
    }
}
