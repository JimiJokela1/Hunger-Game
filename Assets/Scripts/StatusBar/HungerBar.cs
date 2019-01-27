using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : StatusBar
{
    public float hungerBonusValue;
    public float initialDropValue;

	[Header("Reference to stats text")]
	public Text stats;

    public override void Start()
    {
        base.Start();
        timerIsRunning = true;
    }

    void Update()
    {
		stats.text = string.Format("{0} still hungry", ChildManager.childManager.allChildren.Count - ChildManager.childManager.childrenAtHome.Count);

		if (!timerIsRunning)
            return;

        ChangeValue(-ChangedValuePerFrame());
        SetValue(currentValue, maxValue);

		if (currentValue <= .1f)
        {
            FindObjectOfType<LevelManager>().LoadLevel("Lose");
        }
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
