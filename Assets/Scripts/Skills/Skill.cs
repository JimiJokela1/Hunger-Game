using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    internal GrandmaProperties grandmaProperties;
    public bool skillIsPassive;

    public virtual void Start()
    {
        grandmaProperties = FindObjectOfType<GrandmaProperties>();
    }

    /// <summary>
    /// Called by the pressed button
    /// </summary>
    public virtual void ActivateSkill()
    {
        //  Do something
    }

    public virtual void Update()
    {
        if (!skillIsPassive)
            return;
    }


}
