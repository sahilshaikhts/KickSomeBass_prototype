using UnityEngine;
using UnityEngine.Assertions;
using AbilitySpace;
using UtilityAIHelpers;
using System.Collections;

public class MovementAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
    {
        Assert.IsNotNull(fighter);
        Assert.IsNotNull(fighter.GetComponent<Rigidbody>());

        Rigidbody fighterRigidBody = fighter.GetComponent<Rigidbody>();

        RotateTowardsaOpponent(fighter);

        if (fighter.GetMovementDirection().sqrMagnitude > 0)
        {
            Vector3 inputDirection = fighter.GetMovementDirection();
            Vector3 moveDirection = (fighter.transform.right * fighter.GetMovementDirection().x) + (fighter.transform.forward * fighter.GetMovementDirection().z);

            moveDirection *= fighter.GetMoveSpeed();

            //ToDo write movement that add drag in the direction opposite to velocity and other things in actual project code
            float maxSpeed = fighter.GetMaxMoveSpeed();

            if (inputDirection.x > 0 && fighterRigidBody.velocity.x > maxSpeed) moveDirection.x = 0;
            if (inputDirection.x < 0 && fighterRigidBody.velocity.x < -maxSpeed) moveDirection.x = 0;
            if (inputDirection.z > 0 && fighterRigidBody.velocity.z > maxSpeed) moveDirection.z = 0;
            if (inputDirection.z < 0 && fighterRigidBody.velocity.z < -maxSpeed) moveDirection.z = 0;

            fighterRigidBody.AddForce(moveDirection * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    void RotateTowardsaOpponent(IFighterCharacter fighter)
    {
        Quaternion lookTowards = Quaternion.LookRotation((fighter.GetOpponent().transform.position - fighter.transform.position));

        lookTowards.x = 0;
        lookTowards.z = 0;

        fighter.GetComponent<Rigidbody>().rotation = Quaternion.Lerp(fighter.GetComponent<Rigidbody>().rotation, lookTowards.normalized,4*Time.deltaTime);
    }

    public override void Animation(IFighterCharacter fighter)
    {

    }

    public override string GetAbilityName()
    {
        return "Movement";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        float[] scores = new float[2];

        float distance = Vector3.Distance(Fighter.GetOpponent().transform.position, Fighter.transform.position);

        if (distance < 5.0f) { return 0; }


        Consideration fighterStamina = new Consideration(CurveTypes.Logistic, 10.0f, 1.3f, 0.0f, 0.46f);
        scores[0] = 1 - ResponseCurve.GetOutputValue(fighterStamina, Fighter.GetStamina() / Fighter.GetMaxStamina());

        Consideration fighterHealth = new Consideration(CurveTypes.Logistic, 10.0f, 1.3f, 0.0f, 0.46f);
        scores[1] = 1 - ResponseCurve.GetOutputValue(fighterHealth, Fighter.GetHealth() / Fighter.GetMaxHealth());

        //Debug.Log("Stamina: " + Fighter.GetStamina() + " Stamina Score: " + scores[0]);
        //Debug.Log("Health: " + Fighter.GetHealth() + " Health Score: " + scores[1]);
        //Debug.Log("Total Score: " + (scores[0] + scores[1]) / 3.0f);

        return (scores[0] + scores[1]) / 3.0f;
    }

    public bool GetVeto() { return m_veto; }



    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<MovementAbility>();
    }

    

}
