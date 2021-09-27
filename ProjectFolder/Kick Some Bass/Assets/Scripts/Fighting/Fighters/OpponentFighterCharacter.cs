using UnityEngine;
using AbilitySpace;

public class OpponentFighterCharacter : IFighterCharacter
{
    [SerializeField] AIFighterController m_controller;

    public override void ExecuteAction(IFightAbility fightAbility)
    {
        fightAbility.PerformAction(this);
    }

    public override Vector3 GetMovementDirection()
    {
        return m_controller.GetMovementDirection();
    }
}
