using UnityEngine;
using AbilitySpace;

public class OpponentFighterCharacter : IFighterCharacter
{
    //make a base class for for controller for both player and enemy?
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
