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
        base.ActivateSkill();

        SkillsHandler.skillsHandler.GroundCollectedChildren();
    }
}
