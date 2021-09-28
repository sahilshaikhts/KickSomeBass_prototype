using UnityEngine;
using AbilitySpace;

public class IdleAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
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
