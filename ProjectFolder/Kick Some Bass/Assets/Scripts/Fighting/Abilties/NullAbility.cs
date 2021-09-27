using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;

public class NullAbility : IFightAbility, IUtilityAI
{
    public override void PerformAction(IFighterCharacter fighter)
    {
        Debug.Log(GetAbilityName());
    }
    public override void Animation(IFighterCharacter fighter)
    {
    }

    public override string GetAbilityName()
    {
        return "Null";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        return 0;
    }

    public bool GetVeto() { return false; }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<NullAbility>();
    }
}
