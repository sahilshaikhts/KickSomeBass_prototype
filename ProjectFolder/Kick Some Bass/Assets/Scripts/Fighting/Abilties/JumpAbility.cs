using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;

public class JumpAbility : IFightAbility
{
    public override void PerformAction(IFighterCharacter fighter)
    {
        Assert.IsNotNull(fighter);
        Assert.IsNotNull(fighter.GetComponent<Rigidbody>());
        if (CheckIfOnGround(fighter))
        {
            fighter.GetComponent<Rigidbody>().AddForce(fighter.transform.up * 10, ForceMode.VelocityChange);
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
}
