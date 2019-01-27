using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisciplineBar : StatusBar
{
	[Header("Reference to stats text component")]
	public Text stats;

	public override void Start()
	{
		base.Start();
		timerIsRunning = false;
	}

	void Update()
	{
		if (!timerIsRunning)
		{
			stats.text = "Find the children!";
			return;
		}

		ChangeValue(ChangedValuePerFrame());
		SetValue(currentValue, maxValue);

		// Show how many children have been grounded
		if (SkillsHandler.skillsHandler.hasUsedGroundingSkill)
		{
			int grounded = 0;
			foreach (var child in ChildManager.childManager.allChildren)
			{
				if (child.GetComponent<Child>().childState == Child.ChildState.Grounded)
				{
					grounded++;
				}
				stats.text = string.Format("{0} / {1} children, {2} grounded", ChildManager.childManager.childrenAtHome.Count, ChildManager.childManager.allChildren.Count, grounded);
			}
		}
		// Show how many children are at home
		else
		{
			// <X> children - or - children
			stats.text = string.Format("{0} {1}", ChildManager.childManager.childrenAtHome.Count, ChildManager.childManager.childrenAtHome.Count > 1 ? "children" : "child");
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
