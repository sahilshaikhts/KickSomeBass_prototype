using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class KickAbility : IFightAbility
{
    public override void PerformAction()
    {
        Debug.Log("Kicked!!! Baam");
    }

    public override void Animation()
    {

    }

    public override string GetAbilityName()
    {
        return "Kick";
    }
}
