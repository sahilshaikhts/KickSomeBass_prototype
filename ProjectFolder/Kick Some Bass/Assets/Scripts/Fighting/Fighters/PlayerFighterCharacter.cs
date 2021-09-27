using UnityEngine;
using AbilitySpace;

public class PlayerFighterCharacter : IFighterCharacter
{
    [SerializeField] PlayerFighterController m_controller;
    
    public override void ExecuteAction(IFightAbility fightAbility)
    {
        fightAbility.PerformAction(this);
    }

    public override Vector3 GetMovementDirection()
    {
        return m_controller.GetMovementDirection();
    }
}
