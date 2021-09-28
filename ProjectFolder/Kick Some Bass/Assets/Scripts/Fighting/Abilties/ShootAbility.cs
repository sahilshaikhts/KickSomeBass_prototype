using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;
using UtilityAIHelpers;

public class ShootAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    GameObject prfb_projectile;

    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
    {
        m_staminaConsumption = 40.0f;

        prfb_projectile = (GameObject)Resources.Load("prfb_projectile");
        Debug.Log(GetAbilityName());

        Assert.IsNotNull(fighter);

        if (prfb_projectile && m_state == AbilityState.Stopped)
        {
            fighter.ChangeStamina(-m_staminaConsumption);
            m_state = AbilityState.running;

            //Use gun socket for position later
            GameObject projectile = Instantiate(prfb_projectile, fighter.transform.position + fighter.transform.forward + fighter.transform.up, Quaternion.identity);

            projectile.GetComponent<projectile>().SetShooter(fighter);

            projectile.GetComponent<Rigidbody>().velocity = fighter.transform.forward * 15;

            fighter.gameObject.GetComponent<Rigidbody>().AddForce(-fighter.transform.forward * Time.deltaTime * 200, ForceMode.VelocityChange);

            fighter.ChangeStamina(-m_staminaConsumption);


            StartCoroutine(SwitchStateWithDelay(AbilityState.Stopped, 2));
        }
    }

    public override void Animation(IFighterCharacter fighter)
    {
    }

    public override string GetAbilityName()
    {
        return "Shoot";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        float[] scores = new float[2];

        float distance = Vector3.Distance(Fighter.GetOpponent().transform.position, Fighter.transform.position);
        if (distance < 4.0f) { return -1; }
        scores[0] = 1;

        Consideration fighterHealth = new Consideration(CurveTypes.InverseLogistic, 100000.0f, 0.5f, -0.5f, 0.37f);
        scores[1] = ResponseCurve.GetOutputValue(fighterHealth, Fighter.GetHealth() / Fighter.GetMaxHealth());

        //Debug.Log("fighterhealth score :" + (scores[0] + scores[1]) / 2.0f + " AI Health : " + Fighter.GetHealth());

        return (scores[0] + scores[1]) / 2.1f;

    }

    public bool GetVeto() { return m_veto; }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<ShootAbility>();
    }
}
