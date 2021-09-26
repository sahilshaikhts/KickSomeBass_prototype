using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class NullAbility : IFightAbility, IUtilityAI
{
    public override void PerformAction()
    {
        Debug.Log("Null Ability Called!");
    }

    public override void Animation()
    {

    }

    public override string GetAbilityName()
    {
        return "Null";
    }

    public float EvaulateAbilityUtility()
    {
        throw new System.NotImplementedException();
    }
}
