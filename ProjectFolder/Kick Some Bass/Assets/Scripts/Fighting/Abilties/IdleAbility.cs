using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;

public class IdleAbility : IFightAbility
{
    public override void PerformAction(GameObject aObject)
    {
        Debug.Log("Idle");
    }

    public override void Animation(GameObject aObject)
    {
    }

    public override string GetAbilityName()
    {
        return "Idle";
    }
}
