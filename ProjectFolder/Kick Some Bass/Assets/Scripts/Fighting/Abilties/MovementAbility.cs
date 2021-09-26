using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;

public class MovementAbility : IFightAbility
{
    public override void PerformAction(GameObject aObject)
    {
        Assert.IsNotNull(aObject.GetComponent<BaseFighterCharacter>());
        Assert.IsNotNull(aObject.GetComponent<Rigidbody>());

        RotateTowardsaOpponent(aObject);


        if (aObject.GetComponent<BaseFighterCharacter>().GetMovementDirection().sqrMagnitude > .9f * .9f)
        {
            Vector3 inputDirection = aObject.GetComponent<BaseFighterCharacter>().GetMovementDirection();
            Vector3 moveDirection = (aObject.transform.right * aObject.GetComponent<BaseFighterCharacter>().GetMovementDirection().x) + (aObject.transform.forward * aObject.GetComponent<BaseFighterCharacter>().GetMovementDirection().z);

            moveDirection *= aObject.GetComponent<BaseFighterCharacter>().GetMoveSpeed();

            #region temp 
            //ToDo write movement that add drag in the direction opposite to velocity and other things in actual project code
            float maxSpeed = aObject.GetComponent<BaseFighterCharacter>().GetMaxMoveSpeed();

            if (inputDirection.x > 0 && aObject.GetComponent<Rigidbody>().velocity.x > maxSpeed) moveDirection.x = 0;
            if (inputDirection.x < 0 && aObject.GetComponent<Rigidbody>().velocity.x < -maxSpeed) moveDirection.x = 0;
            if (inputDirection.z > 0 && aObject.GetComponent<Rigidbody>().velocity.z > maxSpeed) moveDirection.z = 0;
            if (inputDirection.z < 0 && aObject.GetComponent<Rigidbody>().velocity.z < -maxSpeed) moveDirection.z = 0;

            #endregion

            aObject.GetComponent<Rigidbody>().AddForce(moveDirection, ForceMode.Acceleration);
        }
        else
        {
            aObject.GetComponent<Rigidbody>().AddForce(-5 * new Vector3(aObject.GetComponent<Rigidbody>().velocity.x, 0, aObject.GetComponent<Rigidbody>().velocity.z).normalized);
     
            return;
        }

    }

    void RotateTowardsaOpponent(GameObject aObject)
    {
        Quaternion lookTowards = Quaternion.LookRotation((aObject.GetComponent<BaseFighterCharacter>().GetOpponent().transform.position - aObject.transform.position));

        lookTowards.x = 0;
        lookTowards.z = 0;

        aObject.GetComponent<Rigidbody>().rotation = Quaternion.Slerp(aObject.GetComponent<Rigidbody>().rotation, lookTowards.normalized,2*Time.deltaTime);
    }

    public override void Animation(GameObject aObject)
    {

    }

    public override string GetAbilityName()
    {
        return "Movement";
    }
}
