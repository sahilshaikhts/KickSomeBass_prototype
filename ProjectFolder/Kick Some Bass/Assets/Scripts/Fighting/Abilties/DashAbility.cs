using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;

public class DashAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;
    public override void PerformAction(IFighterCharacter fighter, AbilityState m_actionState)
    {
        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);
        Assert.IsNotNull(fighter.GetComponent<Rigidbody>());

        //If not already dashing
        if (!fighter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Dash"))
        {
            Vector3 moveDirection = (fighter.transform.right * fighter.GetMovementDirection().x) + (fighter.transform.forward * fighter.GetMovementDirection().z);

            if (fighter.GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
            {
                fighter.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * (fighter.GetMaxMoveSpeed() * 1.5f) * Time.deltaTime, ForceMode.VelocityChange);
                Animation(fighter);
            }
        }
    }

    public override void Animation(IFighterCharacter fighter)
    {
        fighter.GetComponent<Animator>().SetTrigger("Dash");
    }

    public override string GetAbilityName() { return "Dash"; }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        return 0;
    }

    public bool GetVeto() { return m_veto; }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<DashAbility>();
    }
}
