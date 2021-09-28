using UnityEngine;
using System.Collections;


namespace AbilitySpace
{

    public enum AbilityState
{
    Begin,
    running,
    Stopped
}

public abstract class IFightAbility : MonoBehaviour
{

    protected AbilityState m_state= AbilityState.Stopped;

    [SerializeField]protected float m_staminaConsumption = 10;
    public abstract string GetAbilityName();

    public abstract void PerformAction(IFighterCharacter fighter, AbilityState actionState = AbilityState.Begin);
    public abstract void Animation(IFighterCharacter fighter);

    public abstract IFightAbility GetInstance(GameObject Owner);

    public float GetRequiredStamina() { return m_staminaConsumption; }

         protected  IEnumerator SwitchStateWithDelay(AbilityState newState, float timer) { yield return new WaitForSeconds(timer); m_state = newState; }

    }
}

