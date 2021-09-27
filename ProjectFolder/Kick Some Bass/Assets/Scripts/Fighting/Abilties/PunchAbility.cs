using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;

public class PunchAbility : IFightAbility, IUtilityAI
{

    public override void PerformAction(IFighterCharacter fighter)
    {
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
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(fighter.transform.forward * 20, ForceMode.Impulse);
                    hit.collider.gameObject.GetComponent<IFighterCharacter>().DealDamage(20);

                }
            }

            fighter.ChangeStamina(-10);
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
}
