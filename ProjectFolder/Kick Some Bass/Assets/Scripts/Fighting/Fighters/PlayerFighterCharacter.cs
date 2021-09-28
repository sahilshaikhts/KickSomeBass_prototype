using UnityEngine;
using AbilitySpace;

public class PlayerFighterCharacter : IFighterCharacter
{

    public override void ExecuteAction(IFightAbility fightAbility,AbilityState abilityState=AbilityState.Begin)
    {
        if(!m_disableabilites)
        {
            //if low Stamina and action type isn't exit,do nothing
            if (GetStamina() < fightAbility.GetRequiredStamina()) 
            {
                m_staminaBar.gameObject.GetComponent<Animator>().SetTrigger("flashRed");

                if (abilityState == AbilityState.Stopped)
                {
                    fightAbility.PerformAction(this, AbilityState.Stopped);
                
                }
                return; 
            }

            fightAbility.PerformAction(this, abilityState);
        }
    }

    public override Vector3 GetMovementDirection()
    {
        return m_controller.GetComponent<PlayerFighterController>().GetMovementDirection();
    }
}
