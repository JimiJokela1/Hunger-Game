using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerBar : StatusBar
{
    public override void Start()
    {
        base.Start();
        timerIsRunning = true;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void ChangeValue(float changedAmount)
    {
        base.ChangeValue(changedAmount);
    }

    public override void SetValue(float cur, float max)
    {
        base.SetValue(cur, max);
    }
}
