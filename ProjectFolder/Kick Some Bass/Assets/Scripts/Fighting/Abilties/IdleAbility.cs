using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;

public class IdleAbility : IFightAbility
{
    public override void PerformAction(IFighterCharacter fighter)
    {
        Debug.Log("Idle");
    }

    public override void Animation(IFighterCharacter fighter)
    {
    }

    public override string GetAbilityName()
    {
        return "Idle";
    }
}
