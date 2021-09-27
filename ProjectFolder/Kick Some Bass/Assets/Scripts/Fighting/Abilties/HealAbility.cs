using UnityEngine;
using AbilitySpace;
using UtilityAIHelpers;

public class HealAbility : IFightAbility, IUtilityAI
{
    bool m_veto = false;

    public override void PerformAction(IFighterCharacter fighter)
    {
        Debug.Log(GetAbilityName());
    }

    public override void Animation(IFighterCharacter fighter)
    {

    }

    public override string GetAbilityName()
    {
        return "Heal";
    }

    public float EvaulateAbilityUtility(IFighterCharacter Fighter)
    {
        Consideration playerHealth = new Consideration(CurveTypes.Linear, -1.5f, 1, 1, 0);

        Fighter.DealDamage(1);
        float score = ResponseCurve.GetOutputValue(playerHealth, Fighter.GetHealth() / Fighter.GetMaxHealth());

        Debug.Log("Utility Score : " + score + ", PlayerHealth : " + Fighter.GetHealth());
        return score;
    }

    public bool GetVeto() { return m_veto; }

}
