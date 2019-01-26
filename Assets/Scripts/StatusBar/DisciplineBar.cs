using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisciplineBar : StatusBar
{
    public override void Start()
    {
        base.Start();
        timerIsRunning = false;
    }

    public override void Update()
    {
        if (!timerIsRunning)
            return;

        ChangeValue(ChangedValuePerFrame());
        SetValue(currentValue, maxValue);
    }

    public override void ChangeValue(float changedAmount)
    {
        base.ChangeValue(changedAmount);
    }

    public override void SetValue(float cur, float max)
    {
        base.SetValue(cur, max);
    }


    public float ChangedValuePerFrame()
    {
        float i = 0;
        foreach (var childAtHome in ChildManager.childManager.childrenAtHome)
        {
            if (childAtHome.childState != Child.ChildState.Grounded)
            {
                i += childModifier;
            }
        }
        return i;
    }
}
