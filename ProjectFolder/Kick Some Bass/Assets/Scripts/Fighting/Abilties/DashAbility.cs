using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;

public class DashAbility : IFightAbility
{
    public override void PerformAction(GameObject aObject)
    {
        Assert.IsNotNull(aObject.GetComponent<BaseFighterCharacter>());
        Assert.IsNotNull(aObject.GetComponent<Rigidbody>());


        //If not already dashing
        if (!aObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Dash"))
        {
            Vector3 moveDirection = (aObject.transform.right * aObject.GetComponent<BaseFighterCharacter>().GetMovementDirection().x) + (aObject.transform.forward * aObject.GetComponent<BaseFighterCharacter>().GetMovementDirection().z);

            if (aObject.GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
            {
                aObject.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * 20, ForceMode.VelocityChange);
                Animation(aObject);
            }
        }
    }

    public override void Animation(GameObject aObject)
    {
        aObject.GetComponent<Animator>().SetTrigger("Dash");
    }

    public override string GetAbilityName()
    {
        return "Dash";
    }
}
