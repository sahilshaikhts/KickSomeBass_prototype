using UnityEngine;
using AbilitySpace;
using UtilityAIHelpers;
using System.Collections;

public class HealAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter, AbilityState actionState)
    {
        if (fighter.GetStamina() < m_staminaConsumption) { return; }

        Debug.Log(GetAbilityName());

        fighter.ChangeHealth(10);
        fighter.ChangeStamina(-m_staminaConsumption);
    }

    public override void Animation(IFighterCharacter fighter)
    {

    }

    public override string GetAbilityName()
    {
        return "Heal";
    }

    public override IFightAbility GetInstance(GameObject Owner)
    {
        return Owner.AddComponent<HealAbility>();
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        if(Fighter.GetHealth() / Fighter.GetMaxHealth() >= 1){ return -1; }

        Consideration playerHealth = new Consideration(CurveTypes.Logistic, 7.5f, 1.0f, 0.0f, 0.6f);

        float score = ResponseCurve.GetOutputValue(playerHealth, Fighter.GetHealth()/ Fighter.GetMaxHealth());

        return score;
    }

    public bool GetVeto() { return m_veto; }

    
}
