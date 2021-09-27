using UnityEngine;
using AbilitySpace;

public class OpponentFighterCharacter : IFighterCharacter
{
    public override void ExecuteAction(IFightAbility fightAbility)
    {
        if (!m_disableabilites)
        {
            fightAbility.PerformAction(this);
        }
    }

    public override Vector3 GetMovementDirection()
    {
        return m_controller.GetComponent<AIFighterController>().GetMovementDirection();
    }
}
