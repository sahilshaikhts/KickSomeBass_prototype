using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class PunchAbility : IFightAbility
{
    public override void PerformAction()
    {
        Debug.Log("Punched!!! Baam");
    }

    public override void Animation()
    {

    }

    public override string GetAbilityName()
    {
        return "Punch";
    }
}
