using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;

public class LoseAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter)
    {
        Debug.Log(GetAbilityName());

        fighter.DisableAbilityUsage();

        Debug.Log("Should play fall/lose animation!");
    }

    public override void Animation(IFighterCharacter fighter)
    {

    }

    public override string GetAbilityName()
    {
        return "Lose";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        if(Fighter.IsDead())
        {
            m_veto = true;
        }

        return 0;
    }

    public bool GetVeto() { return m_veto; }


    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<LoseAbility>();
    }
}
