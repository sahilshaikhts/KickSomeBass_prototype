using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;
using System.Collections;

public class JumpAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
    {
        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);
        Assert.IsNotNull(fighter.GetComponent<Rigidbody>());

        if (CheckIfOnGround(fighter))
        {
            Debug.LogWarning("jjj");

            fighter.GetComponent<Rigidbody>().AddForce(fighter.transform.up*Time.fixedDeltaTime *510, ForceMode.VelocityChange);
        }
    }


    bool CheckIfOnGround(IFighterCharacter fighter)
    {
        Ray ray = new Ray(fighter.transform.position+Vector3.up, Vector3.down);

        LayerMask mask = 1 << LayerMask.NameToLayer("Ground");

        if (Physics.Raycast(ray,1, mask))
        {
            return true;
        }

        return false;
    }

    public override void Animation(IFighterCharacter fighter)
    {
    }

    public override string GetAbilityName()
    {
        return "Jump";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        return 0;
    }
    public bool GetVeto() { return m_veto; }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<JumpAbility>();
    }
    
}
