using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class BlockPunchAbility : IFightAbility
{
    public override void PerformAction()
    {
        Debug.Log("Block");
    }

    public override void Animation()
    {

    }

    public override string GetAbilityName()
    {
        return "BlockPunch";
    }
}
