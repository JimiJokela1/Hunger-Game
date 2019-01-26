using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsHandler : MonoBehaviour
{
    public static SkillsHandler skillsHandler;

    public bool canUseGrandmaSenseSkill;
    public bool hasUsedGroundingSkill;

    public float grandmaSenseRange;

    internal Transform target;

    void Awake()
    {
        skillsHandler = this;
    }

    private void Start()
    {
        canUseGrandmaSenseSkill = true;
        InvokeRepeating("FindChild", .5f, .5f);
    }

    public virtual void FindChild()
    {
        if (!canUseGrandmaSenseSkill)
            return;

        foreach (GameObject child in ChildManager.childManager.allChildren)
        {
            if (child != null && Vector3.Distance(child.GetComponent<Child>().childWorldPosition.position, this.transform.position) <= grandmaSenseRange)
            {
                target = child.GetComponent<Child>().childWorldPosition;

                Debug.Log("My Grandma sense in tingling!!!");
                //TODO: Show a visual indicator that the kid is close
            }
        }

        if (target == null)
            return;

        if (Vector3.Distance(target.position, this.transform.position) > grandmaSenseRange)
        {
            target = null;
        }
    }

    public void GroundCollectedChildren()
    {
        if (hasUsedGroundingSkill)
            return;

        bool noUngroundedChildrenAtHome = true;
        foreach (var child in ChildManager.childManager.childrenAtHome)
        {
            if (child.childState != Child.ChildState.Grounded)
            {
                noUngroundedChildrenAtHome = false;
            }
        }

        if (noUngroundedChildrenAtHome)
            return;


        foreach (var childAtHome in ChildManager.childManager.childrenAtHome)
        {
            if (childAtHome.childState != Child.ChildState.Grounded)
                childAtHome.childState = Child.ChildState.Grounded;
        }

        hasUsedGroundingSkill = true;
    }
}
