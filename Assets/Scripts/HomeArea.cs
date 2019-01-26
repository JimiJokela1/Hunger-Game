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


        // TODO: Trigger countdown for children escaping(?)

        if(ChildManager.childManager.childrenAtHome.Count > 0 && !SkillsHandler.skillsHandler.hasUsedGroundingSkill)
        {
            FindObjectOfType<DisciplineBar>().timerIsRunning = true;
            Debug.LogWarning("As it is now, grounding the kids will freeze the discipline bar forever");
        }

    }


}
