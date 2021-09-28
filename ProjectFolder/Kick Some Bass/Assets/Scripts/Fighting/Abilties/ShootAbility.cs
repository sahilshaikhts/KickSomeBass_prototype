using UnityEngine;
using UnityEditor;
using AbilitySpace;
using UnityEngine.Assertions;
using System.Collections;

public class ShootAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    GameObject prfb_projectile;

    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
    {
        m_staminaConsumption = 40.0f;

        prfb_projectile = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Fighting/prfb_projectile.prefab", typeof(GameObject));
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

            fighter.gameObject.GetComponent<Rigidbody>().AddForce(-fighter.transform.forward * Time.deltaTime * 600, ForceMode.VelocityChange);

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
        return 0;
    }

    public bool GetVeto() { return m_veto; }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<ShootAbility>();
    }
}
