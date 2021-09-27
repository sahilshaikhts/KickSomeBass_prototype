using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class KickAbility : IFightAbility
{
    public override void PerformAction(IFighterCharacter fighter)
    {
        Debug.Log("Kicked!!! Baam");
    }

    public override void Animation(IFighterCharacter fighter)
    {

    }

    public override string GetAbilityName()
    {
        return "Kick";
    }
}
