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

        FindObjectOfType<GrandmaProperties>().grandmaIsAtHome = true;

		if (GrandmaMovement.Instance.Properties.CarriesChild)
		{
			Debug.Log("Grandma brought home children");

			// Return the carried children
			List<Child> childrenReturned = new List<Child>(GrandmaMovement.Instance.Properties.carriedChildren);
			ChildManager.childManager.childrenAtHome.AddRange(childrenReturned);
			foreach(Child child in childrenReturned)
			{
				child.childState = Child.ChildState.AtHome;
			}

			// Remove kids from grandma
			GrandmaMovement.Instance.Properties.carriedChildren.Clear();

			// Give a small bonus to the player --> Fill the hunger bar by x amount
            var hungerBar = FindObjectOfType<HungerBar>();
            hungerBar.currentValue += hungerBar.hungerBonusValue;
            hungerBar.SetValue(hungerBar.currentValue, hungerBar.maxValue);

			// Show text to player saying you brough home children
			string message = "Grandma brought home and fed ";
			for (int i = 0; i < childrenReturned.Count; i++)
			{
				message += childrenReturned[i].ID;
				if (i + 1 < childrenReturned.Count)
				{
					message += ", ";
				}
			}
			SpeechArea.Instance.ShowText(message);

            if (childrenReturned.Count >= 5)
                FindObjectOfType<LevelManager>().LoadLevel("Win");
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

        FindObjectOfType<GrandmaProperties>().grandmaIsAtHome = false;

        // Change to different Audio environment...(?)

        // Hide message for bringing children home
        SpeechArea.Instance.HideText();

        if(ChildManager.childManager.childrenAtHome.Count > 0)// && !SkillsHandler.skillsHandler.hasUsedGroundingSkill)
        {
            FindObjectOfType<DisciplineBar>().timerIsRunning = true;
        }

    }


}
