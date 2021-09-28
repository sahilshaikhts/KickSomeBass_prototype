using UnityEngine.Assertions;
using UnityEngine;
using AbilitySpace;
using System.Collections;

public class BlockPunchAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;
    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
    {
        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);

        if (actionState == AbilityState.Begin)
        {
            GameObject blockColliderObj = GetPunchBlockCollider(fighter);

            if (blockColliderObj)
            {
                blockColliderObj.SetActive(true);
            }
            Animation(fighter);
        }

        if (actionState == AbilityState.Stopped)
        {
            GameObject blockColliderObj = GetPunchBlockCollider(fighter);

            if (blockColliderObj)
            {
                blockColliderObj.SetActive(false);
                if (fighter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BlockPunch"))
                {
                    StopAnimation(fighter);
                    fighter.ChangeStamina(-m_staminaConsumption);
                }
            }
        }
    }
    
    GameObject GetPunchBlockCollider(IFighterCharacter aFighter)
    {
        for (int i = 0; i < aFighter.transform.childCount; i++)
        {
            if (aFighter.transform.GetChild(i).name == "PunchBlocker")
            {
                return aFighter.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }

    public override void Animation(IFighterCharacter fighter)
    {
        fighter.GetComponent<Animator>().SetBool("BlockPunch", true);
    }

    public void StopAnimation(IFighterCharacter fighter)
    {
        fighter.GetComponent<Animator>().SetBool("BlockPunch",false);
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

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<BlockPunchAbility>();
    }

}