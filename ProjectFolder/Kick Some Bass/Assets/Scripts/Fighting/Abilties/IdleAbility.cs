using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;

public class IdleAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter)
    {
        Debug.Log(GetAbilityName());
    }

    public override void Animation(IFighterCharacter fighter)
    {
    }

    public override string GetAbilityName()
    {
        return "Idle";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        return 0;
    }

    public bool GetVeto() { return m_veto; }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<IdleAbility>();
    }
}
