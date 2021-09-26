using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class IdleAbility : IFightAbility, IUtilityAI
{
    public override void PerformAction()
    {
        Debug.Log("Standing Idle...;(");
    }

    public override void Animation()
    {

    }

    public override string GetAbilityName()
    {
        return "Idle";
    }

    public float EvaulateAbilityUtility()
    {
        throw new System.NotImplementedException();
    }
}
