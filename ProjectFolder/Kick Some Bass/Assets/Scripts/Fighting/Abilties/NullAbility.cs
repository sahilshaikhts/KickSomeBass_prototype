using UnityEngine;
using AbilitySpace;
using System.Collections;

public class NullAbility : IFightAbility, IUtilityAI
{
    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
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
