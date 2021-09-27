using UnityEngine.Assertions;
using UnityEngine;
using AbilitySpace;

public class BlockPunchAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;
    public override void PerformAction(IFighterCharacter fighter, AbilityState m_actionState)
    {
        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);

        if (!fighter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BlockPunch"))
        {
            GameObject punchBlocker = Instantiate(new GameObject("OBJ_PunchBlock"));

            punchBlocker.AddComponent<BoxCollider>();

            punchBlocker.transform.position = Vector3.up*5;//fighter.transform.position + fighter.transform.forward+fighter.transform.up*1.5f;

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

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<BlockPunchAbility>();
    }
}