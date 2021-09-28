using UnityEngine;
using AbilitySpace;

public class OpponentFighterCharacter : IFighterCharacter
{
    public override void ExecuteAction(IFightAbility fightAbility,AbilityState abilityState)
    {
        if (!m_disableabilites)
        {
            fightAbility.PerformAction(this, abilityState);
        }
    }

    public override Vector3 GetMovementDirection()
    {
        return m_controller.GetComponent<AIFighterController>().GetMovementDirection();
    }
}
