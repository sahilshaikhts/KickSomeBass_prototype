using UnityEngine;
using AbilitySpace;
using UnityEngine.Assertions;

public class ShootAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;
    
    GameObject prfb_projectile;
   

    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
    {
        //Material mPrefab = (Material)Resources.Load("Assets/mat");
        //    UnityEngine.Object pPrefab  = Resources.Load("Assets/prfb_projectile");

        //Debug.Log(GetAbilityName());

        //Assert.IsNotNull(fighter);

        //if (!fighter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))
        //{
        //    //Use gun socket for position later
        //    {
        //        GameObject projectile = (GameObject)Instantiate(pPrefab, fighter.transform.position + fighter.transform.forward + fighter.transform.up, Quaternion.identity);

        //        projectile.GetComponent<Rigidbody>().velocity = fighter.transform.forward * 5;

        //        fighter.ChangeStamina(-m_staminaConsumption);
        //    }
        //}
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
