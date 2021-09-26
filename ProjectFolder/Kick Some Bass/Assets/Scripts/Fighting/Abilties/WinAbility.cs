using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class WinAbility : IFightAbility, IUtilityAI
{
    public override void PerformAction()
    {
        Debug.Log("I Win!!");
    }

    public override void Animation()
    {

    }

    public override string GetAbilityName()
    {
        return "Win";
    }

    public float EvaulateAbilityUtility()
    {
        throw new System.NotImplementedException();
    }
}
