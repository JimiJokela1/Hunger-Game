using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerBar : StatusBar
{
    public float hungerBonusValue;
    public float initialDropValue;

    public override void Start()
    {
        base.Start();
        timerIsRunning = true;
    }

    void Update()
    {
        if (!timerIsRunning)
            return;

        ChangeValue(-ChangedValuePerFrame());
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
        var i = initialDropValue;
        foreach (var childAtHome in ChildManager.childManager.childrenAtHome)
        {
            i -= childModifier;
        }
        return i;
    }
}
