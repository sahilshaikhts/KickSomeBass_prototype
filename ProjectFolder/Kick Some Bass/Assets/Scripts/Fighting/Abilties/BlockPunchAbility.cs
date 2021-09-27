using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using AbilitySpace;

public class BlockPunchAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;
    [SerializeField] int count=0;
    public override void PerformAction(IFighterCharacter fighter)
    {
        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);

        if (!fighter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BlockPunch"))
        {
            GameObject punchBlocker = Instantiate(new GameObject("OBJ_PunchBlock"));

            punchBlocker.AddComponent<BoxCollider>();

            punchBlocker.transform.position = Vector3.up*5;//fighter.transform.position + fighter.transform.forward+fighter.transform.up*1.5f;

            Animation(fighter);
            count++;
            Debug.Log(fighter.name + "Punch count - " + count);
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

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<BlockPunchAbility>();
    }
}