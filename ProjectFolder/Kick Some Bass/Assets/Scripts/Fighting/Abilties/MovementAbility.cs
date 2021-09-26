using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class MovementAbility : IFightAbility, IUtilityAI
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
