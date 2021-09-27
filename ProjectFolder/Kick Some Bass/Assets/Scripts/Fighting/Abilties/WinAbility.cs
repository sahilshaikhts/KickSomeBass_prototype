using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class WinAbility : IFightAbility, IUtilityAI
{
    public override void PerformAction(IFighterCharacter InstigatorObject)
    {
        Debug.Log(GetAbilityName());
    }

    public override void Animation(IFighterCharacter InstigatorObject)
    {

    }

    public override string GetAbilityName()
    {
        return "Win";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        return 0;
    }
}
