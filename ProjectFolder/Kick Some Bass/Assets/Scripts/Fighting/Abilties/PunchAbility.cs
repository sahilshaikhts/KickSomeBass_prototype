using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;

public class PunchAbility : IFightAbility
{

    public override void PerformAction(GameObject aObject)
    {
        Assert.IsNotNull(aObject.GetComponent<BaseFighterCharacter>());
        Debug.Log("Punch");

        if (!aObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))
        {
            Animation(aObject);

            //Check if in arm range
            RaycastHit hit;
            Ray ray = new Ray(aObject.transform.position + aObject.transform.up, aObject.transform.forward);

            if (Physics.SphereCast(ray,0.5f,out hit,1.5f))
            {
                if (hit.collider.gameObject == aObject.GetComponent<BaseFighterCharacter>().GetOpponent())
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(aObject.transform.forward * 20, ForceMode.Impulse);
                    hit.collider.gameObject.GetComponent<BaseFighterCharacter>().DealDamage(20);
                }
            }

        }

    }
    public override void Animation(GameObject aObject)
    {
        aObject.GetComponent<Animator>().SetTrigger("Punch");

    }

    public override string GetAbilityName()
    {
        return "Punch";
    }
}
