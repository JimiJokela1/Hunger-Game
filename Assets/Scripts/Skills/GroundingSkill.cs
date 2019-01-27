using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundingSkill : Skill
{
    public AudioClip groundedSound;

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
            var grandmaSource = FindObjectOfType<GrandmaMovement>().GetComponent<AudioSource>();
            grandmaSource.clip = groundedSound;
            grandmaSource.Play();
            FindObjectOfType<SpeechArea>().ShowText("You’re Grounded! Now sit quietly and think about what you’ve done.");
        }
    }

    IEnumerator ChildrenEscapedMessageTimer(string messageText)
    {
        yield return new WaitForSeconds(2);
        if (FindObjectOfType<SpeechArea>().IsTextShowing(messageText))
        {
            FindObjectOfType<SpeechArea>().HideText();
        }
    }

}
