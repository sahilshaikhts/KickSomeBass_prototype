using AbilitySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IFighterCharacter : MonoBehaviour
{
    [SerializeField] GameObject m_opponent;

    [SerializeField] float m_HP;
    [SerializeField] float m_stamina;
    [SerializeField] float m_speed, m_maxSpeed;

    public abstract Vector3 GetMovementDirection();
    public abstract void ExecuteAction(IFightAbility fightAbility);

    #region Setters
    public void DealDamage(int amount) { m_HP -= amount; if (m_HP <= 0) {/*Inform FightManager fighter died,change game state*/ } }
    #endregion

    #region getters

    public float GetHP() { return m_HP; }

    public float GetStamina() { return m_stamina; }

    public float GetMoveSpeed() { return m_speed; }
    public float GetMaxMoveSpeed() { return m_maxSpeed; }

    public GameObject GetOpponent() { return m_opponent; }

    #endregion
}
