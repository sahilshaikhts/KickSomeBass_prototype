using AbilitySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IFighterCharacter : MonoBehaviour
{
    [SerializeField] GameObject m_opponent;

    [SerializeField] int m_health = 100, m_maxHealth = 100;
    [SerializeField] float m_stamina;
    [SerializeField] float m_speed, m_maxSpeed;

    private bool m_IsDead = false;

    public abstract Vector3 GetMovementDirection();
    public abstract void ExecuteAction(IFightAbility fightAbility);

    public void DealDamage(int amount) 
    {
        m_health -= amount; 
        if (m_health <= 0) { m_IsDead = true; } 
    }

    public void Heal(int healAmount)
    {
        m_health += healAmount;
        if(m_health >= m_maxHealth) { m_health = m_maxHealth; }
    }

    #region getters

    public float GetHealth() { return m_health; }
    public float GetStamina() { return m_stamina; }
    public bool IsDead() { return m_IsDead;}
    public float GetMoveSpeed() { return m_speed; }
    public float GetMaxMoveSpeed() { return m_maxSpeed; }
    public GameObject GetOpponent() { return m_opponent; }

    #endregion
}
