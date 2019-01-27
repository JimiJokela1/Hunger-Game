using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    public static ChildManager childManager;

    public List<Child> childrenAtHome;

    public List<GameObject> allChildren;

    public float childrenEscapedMessageShowTime = 3f;

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
    /// Removes all children who are not grounded from home and resets them to hiding in their hidey-holes
    /// </summary>
    public void ReleaseChildren()
    {
        List<Child> childrenEscaped = new List<Child>();
        List<Child> childrenAtHomeCopy = new List<Child>(childrenAtHome);
        foreach (Child child in childrenAtHomeCopy)
        {
            if (child.childState != Child.ChildState.Grounded)
            {
                child.childState = Child.ChildState.Hiding;
                childrenEscaped.Add(child);
                childrenAtHome.Remove(child);
            }
        }

        if (childrenEscaped.Count == 0)
        {
            return;
        }

        // Show text to player saying you brough home children
        string message = "";
        for (int i = 0; i < childrenEscaped.Count; i++)
        {
            message += childrenEscaped[i].ID;
            if (i + 2 < childrenEscaped.Count)
            {
                message += ", ";
            }
            else if (i + 1 < childrenEscaped.Count)
            {
                message += " and ";
            }
        }

        if (childrenEscaped.Count == 1)
        {
            message += " wandered off! Time to get that naughty grandkid back.";
        }
        else
        {
            message += " wandered off! Time to get those naughty grandkids back.";
        }
        
        SpeechArea.Instance.ShowText(message);

        DisciplineBar disciplineBar = FindObjectOfType<DisciplineBar>();
        disciplineBar.timerIsRunning = false;
        disciplineBar.currentValue = disciplineBar.maxValue;
        disciplineBar.SetValue(disciplineBar.currentValue, disciplineBar.maxValue);

        StartCoroutine(ChildrenEscapedMessageTimer(message));
    }

    IEnumerator ChildrenEscapedMessageTimer(string messageText)
    {
        yield return new WaitForSeconds(childrenEscapedMessageShowTime);
        if (SpeechArea.Instance.IsTextShowing(messageText))
        {
            SpeechArea.Instance.HideText();
        }
    }
}
