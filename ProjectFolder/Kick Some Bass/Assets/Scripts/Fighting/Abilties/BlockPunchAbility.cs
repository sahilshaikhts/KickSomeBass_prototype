using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;

public class BlockPunchAbility : IFightAbility
{
    public override void PerformAction(GameObject aObject)
    {
        Assert.IsNotNull(aObject.GetComponent<BaseFighterCharacter>());

        if (!aObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BlockPunch"))
        {
            Animation(aObject);
        }
    }

    public override void Animation(GameObject aObject)
    {
        aObject.GetComponent<Animator>().SetTrigger("BlockPunch");
    }

    public override string GetAbilityName()
    {
        return "BlockPunch";
    }
}
