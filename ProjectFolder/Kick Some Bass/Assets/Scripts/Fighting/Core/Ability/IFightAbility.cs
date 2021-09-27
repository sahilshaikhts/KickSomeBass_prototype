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

    [SerializeField]protected int m_staminaConsumption = 10;
    public abstract string GetAbilityName();

    public abstract void PerformAction(IFighterCharacter fighter, AbilityState m_actionState = AbilityState.Enter);
    public abstract void Animation(IFighterCharacter fighter);

    public abstract IFightAbility GetInstance(GameObject Owner);
}

}