using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;

public class BlockPunchAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter)
    {
        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);

        if (!fighter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BlockPunch"))
        {
            Animation(fighter);
        }
    }

    public override void Animation(IFighterCharacter fighter)
    {
        fighter.GetComponent<Animator>().SetTrigger("BlockPunch");
    }

    public override string GetAbilityName()
    {
        return "BlockPunch";
    }
    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        return 0;
    }
    public bool GetVeto() { return m_veto; }
}