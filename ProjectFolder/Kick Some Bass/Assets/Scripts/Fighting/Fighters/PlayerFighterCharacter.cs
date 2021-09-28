using UnityEngine;
using AbilitySpace;

public class PlayerFighterCharacter : IFighterCharacter
{

    public override void ExecuteAction(IFightAbility fightAbility,AbilityState abilityState=AbilityState.Enter)
    {
        if(!m_disableabilites)
        {
            if (GetStamina() < fightAbility.GetRequiredStamina()) { return; }

            fightAbility.PerformAction(this, abilityState);
        }
    }

    public override Vector3 GetMovementDirection()
    {
        return m_controller.GetComponent<PlayerFighterController>().GetMovementDirection();
    }
}
