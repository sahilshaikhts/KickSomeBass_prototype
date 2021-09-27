using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;

public class JumpAbility : IFightAbility
{
    public override void PerformAction(GameObject aObject)
    {
        Assert.IsNotNull(aObject.GetComponent<BaseFighterCharacter>());
        Assert.IsNotNull(aObject.GetComponent<Rigidbody>());
        if (CheckIfOnGround(aObject))
        {
            aObject.GetComponent<Rigidbody>().AddForce(aObject.transform.up * 10, ForceMode.VelocityChange);
        }
    }


    bool CheckIfOnGround(GameObject aObject)
    {
        Ray ray = new Ray(aObject.transform.position+Vector3.up, Vector3.down);

        LayerMask mask = 1 << LayerMask.NameToLayer("Ground");

        if (Physics.Raycast(ray,1, mask))
        {
            return true;
        }

        return false;
    }

    public override void Animation(GameObject aObject)
    {
    }

    public override string GetAbilityName()
    {
        return "Jump";
    }
}
