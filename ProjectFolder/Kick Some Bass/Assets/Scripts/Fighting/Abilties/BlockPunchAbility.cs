using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;

public class BlockPunchAbility : IFightAbility
{
    public override void PerformAction(IFighterCharacter fighter)
    {
        Assert.IsNotNull(fighter);

        if (!fighter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BlockPunch"))
        {
            Animation(fighter);
        }
    }

    public override void Animation(IFighterCharacter fighter)
    {
        fighter.GetComponent<Animator>().SetTrigger("BlockPunch");
    }

    public override string GetAbilityName()
    {
        return "BlockPunch";
    }
}
