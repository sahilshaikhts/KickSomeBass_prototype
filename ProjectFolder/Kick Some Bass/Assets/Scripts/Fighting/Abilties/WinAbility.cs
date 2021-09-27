using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class WinAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter InstigatorObject)
    {
        Debug.Log(GetAbilityName());

        Debug.Log("Should play win animation!");

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
        if (Fighter.GetOpponent().GetComponent<IFighterCharacter>().IsDead())
        {
            m_veto = true;
        }

        return 0;
    }

    public bool GetVeto() { return m_veto; }

}
