using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;

public class HealAbility : IFightAbility, IUtilityAI
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
        return "Heal";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        if(Fighter.GetHealth() < 35)
        {

        }
        return 3.0f;
    }

    public bool GetVeto() { return m_veto; }

}
