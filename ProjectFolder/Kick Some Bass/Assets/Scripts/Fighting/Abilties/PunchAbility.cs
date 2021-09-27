using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;

public class PunchAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter, AbilityState m_actionState)
    {
        if(fighter.GetStamina() < m_staminaConsumption) { return; }

        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);

        if (!fighter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))
        {
            Animation(fighter);

            //Check if in arm range
            RaycastHit hit;
            Ray ray = new Ray(fighter.transform.position + fighter.transform.up, fighter.transform.forward);

            if (Physics.SphereCast(ray, 0.5f, out hit, 1.5f))
            {
                if (hit.collider.gameObject == fighter.GetOpponent())
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(fighter.transform.forward * 2000 * Time.deltaTime, ForceMode.VelocityChange);
                    hit.collider.gameObject.GetComponent<IFighterCharacter>().ChangeHealth(-10);

                }
            }

            fighter.ChangeStamina(-m_staminaConsumption);
        }

    }

    public override void Animation(IFighterCharacter fighter)
    {
        fighter.GetComponent<Animator>().SetTrigger("Punch");

    }

    public override string GetAbilityName()
    {
        return "Punch";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        return 0;
    }

    public bool GetVeto() { return m_veto; }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<PunchAbility>();
    }
}
