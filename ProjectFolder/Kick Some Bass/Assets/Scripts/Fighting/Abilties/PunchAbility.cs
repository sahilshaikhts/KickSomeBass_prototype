using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;
using UtilityAIHelpers;
using System.Collections;

public class PunchAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
    {

        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);

        if (!fighter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))
        {
            m_state = AbilityState.running;
            StartCoroutine(SwitchStateWithDelay(AbilityState.Stopped,.2f));

            Animation(fighter);

            //Check if opponent in arm range
            RaycastHit hit;
            Ray ray = new Ray(fighter.transform.position + fighter.transform.up, fighter.transform.forward);

            if (Physics.Raycast(ray,out hit,2,~0,QueryTriggerInteraction.Collide))
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
        float[] scores = new float[2];

        float distance = Vector3.Distance(Fighter.GetOpponent().transform.position, Fighter.transform.position);
        if (distance > 3.0f) { return -1; }

        scores[0] = 1;

        Consideration fighterHealth = new Consideration(CurveTypes.InverseLogistic, 100000.0f, 0.5f, -0.5f, 0.37f);
        scores[1] = ResponseCurve.GetOutputValue(fighterHealth, Fighter.GetHealth() / Fighter.GetMaxHealth());

        //Debug.Log("fighterhealth score :" + (scores[0] + scores[1]) / 2.0f + " AI Health : " + Fighter.GetHealth());

        return (scores[0] + scores[1]) / 2.0f;
    }

    public bool GetVeto() { return m_veto; }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<PunchAbility>();
    }
}
