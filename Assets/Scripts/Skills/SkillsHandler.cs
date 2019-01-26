using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsHandler : MonoBehaviour
{
    public static SkillsHandler skillsHandler;

    public bool canUseGrandmaSenseSkill;
    public bool canUseGroundingSkill;

    public float grandmaSenseRange;

    internal Transform target;

    void Awake()
    {
        skillsHandler = this;
    }

    private void Start()
    {
        InvokeRepeating("FindChild", .5f, .5f);
    }

    public virtual void FindChild()
    {
        if (!canUseGrandmaSenseSkill)
            return;

        foreach (GameObject child in ChildManager.childManager.allChildren)
        {
            if (child != null && Vector3.Distance(child.transform.position, this.transform.position) <= grandmaSenseRange)
            {
                target = child.transform;

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
        // Ground collected children
    }
}
