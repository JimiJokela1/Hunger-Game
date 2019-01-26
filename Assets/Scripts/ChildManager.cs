using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    public static ChildManager childManager;
    public List<GameObject> allChildren;

    private void Awake()
    {
        childManager = this;
    }

    void Start()
    {
        var children = FindObjectsOfType<Child>();

        allChildren = new List<GameObject>();
        foreach (var child in allChildren)
        {
            allChildren.Add(child.gameObject);
        }
    }
}
