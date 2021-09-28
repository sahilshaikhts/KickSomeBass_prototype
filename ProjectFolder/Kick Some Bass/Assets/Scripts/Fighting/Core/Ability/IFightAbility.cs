using UnityEngine;


namespace AbilitySpace
{ 
public enum AbilityState
{
    Enter,
    Exit
}

public abstract class IFightAbility : MonoBehaviour
{

    [SerializeField]protected float m_staminaConsumption = 10;
    public abstract string GetAbilityName();

    public abstract void PerformAction(IFighterCharacter fighter, AbilityState actionState = AbilityState.Enter);
    public abstract void Animation(IFighterCharacter fighter);

    public abstract IFightAbility GetInstance(GameObject Owner);

    public float GetRequiredStamina() { return m_staminaConsumption; }
}

}