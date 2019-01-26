using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaSenseSkill : Skill
{
    public override void Start()
    {
        base.Start();
        skillIsPassive = true;
    }

    public override void ActivateSkill()
    {
        base.ActivateSkill();
        SkillsHandler.skillsHandler.canUseGrandmaSenseSkill = true;
    }
}
