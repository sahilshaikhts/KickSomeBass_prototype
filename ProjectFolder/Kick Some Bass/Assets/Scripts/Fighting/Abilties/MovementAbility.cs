using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class MovementAbility : IFightAbility
{
    public override void PerformAction()
    {
        Debug.Log("I'm Moving!!!");
    }

    public override void Animation()
    {

    }

    public override string GetAbilityName()
    {
        return "Movement";
    }
}
