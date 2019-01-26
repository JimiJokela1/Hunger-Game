using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaProperties : MonoBehaviour
{
	/// <summary>
	/// List reference to children who are carried by Grandma
	/// </summary>
	public List<Child> carriedChildren;

    public GrandmaStats grandmaStats;

	private void Awake()
	{
		carriedChildren = new List<Child>();
        grandmaStats = new GrandmaStats();
    }

    /// <summary>
    /// Returns whether Grandma is carrying a child
    /// </summary>
    public bool CarriesChild
	{
		get { return carriedChildren.Count > 0; }
	}
}

[System.Serializable]
public class GrandmaStats
{
    public int score;
    public bool canUseGrandmaSenseSkill;
    //public GrandmaSenseSkill grandmaSenseSkill;
    //public GroundingSkill groundSkill;
    //public LeapOfFaith leapOfFaith;
}


//[System.Serializable]
//public class GrandmaSenseSkill
//{
//    public bool canUse;
//}

//[System.Serializable]
//public class GroundingSkill
//{
//    public bool canUse;
//}

//[System.Serializable]
//public class LeapOfFaith
//{
//    public bool canUse;
//}
