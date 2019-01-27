using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundingSkill : Skill
{
    public override void Start()
    {
        base.Start();
        skillIsPassive = false;
    }

    public override void ActivateSkill()
    {
        if (FindObjectOfType<GrandmaProperties>().grandmaIsAtHome)
        {
            SkillsHandler.skillsHandler.GroundCollectedChildren();
            SpeechArea.Instance.ShowText("You’re Grounded! Now sit quietly and think about what you’ve done.");
        }
    }

    IEnumerator ChildrenEscapedMessageTimer(string messageText)
    {
        yield return new WaitForSeconds(2);
        if (SpeechArea.Instance.IsTextShowing(messageText))
        {
            SpeechArea.Instance.HideText();
        }
    }

}
