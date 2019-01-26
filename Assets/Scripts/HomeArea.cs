using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeArea : MonoBehaviour
{
	//private List<Child> childrenAtHome = new List<Child>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Home entered by " + collision);
		if (collision.tag != "Player")
			return;

		if (GrandmaMovement.Instance.Properties.CarriesChild)
		{
			Debug.Log("Grandma brought home children");

			// Return the carried children
			ChildManager.childManager.childrenAtHome.AddRange(GrandmaMovement.Instance.Properties.carriedChildren);
			foreach(Child child in ChildManager.childManager.childrenAtHome)
			{
				child.childState = Child.ChildState.AtHome;
			}

			// Remove kids from grandma
			GrandmaMovement.Instance.Properties.carriedChildren.Clear();

            var hungerBar = FindObjectOfType<HungerBar>();
            hungerBar.currentValue += hungerBar.hungerBonusValue;
            hungerBar.SetValue(hungerBar.currentValue, hungerBar.maxValue);
			// TODO:  and play sounds
			// TODO: Give a small bonus to the player --> Fill the hunger bar by x amount

			// Show text to player saying you brough home children
			string message = "Grandma brought home and fed ";
			for (int i = 0; i < ChildManager.childManager.childrenAtHome.Count; i++)
			{
				message += ChildManager.childManager.childrenAtHome[i].ID;
				if (i + 1 < ChildManager.childManager.childrenAtHome.Count)
				{
					message += ", ";
				}
			}
			SpeechArea.Instance.ShowText(message);

            // TODO:  and play sounds
        }

        //  If there are children in the house, set the discipline to Max
        if (ChildManager.childManager.childrenAtHome.Count > 0)
        {
            var disciplineBar = FindObjectOfType<DisciplineBar>();
            disciplineBar.timerIsRunning = false;
            disciplineBar.currentValue = disciplineBar.maxValue;
            disciplineBar.SetValue(disciplineBar.currentValue, disciplineBar.maxValue);
        }
    }

    void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Home Exit by " + other);

		if (other.tag != "Player")
			return;

        // Change to different Audio environment...(?)

		// Hide message for bringing children home

		SpeechArea.Instance.HideText();

        if(ChildManager.childManager.childrenAtHome.Count > 0 && !SkillsHandler.skillsHandler.hasUsedGroundingSkill)
        {
            FindObjectOfType<DisciplineBar>().timerIsRunning = true;
            Debug.LogWarning("As it is now, grounding the kids will freeze the discipline bar forever");
        }

    }


}
