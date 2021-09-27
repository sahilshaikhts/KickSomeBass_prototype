using AbilitySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IFighterCharacter : MonoBehaviour
{
    [SerializeField] GameObject m_opponent;
    [SerializeField] protected GameObject m_controller;

    [SerializeField] Slider m_healthBar;
    [SerializeField] Slider m_staminaBar;

    [SerializeField] int m_health = 100, m_maxHealth = 100;
    [SerializeField] int m_stamina=100,m_maxStamina=100;
    [SerializeField] float m_speed, m_maxSpeed;

    private bool m_IsDead = false;
    protected bool m_disableabilites = false;

    public abstract Vector3 GetMovementDirection();
    public abstract void ExecuteAction(IFightAbility fightAbility);
    public void DisableAbilityUsage() { m_disableabilites = true; }

    public void DealDamage(int amount) 
    {
        m_health -= amount;
        m_healthBar.value = (float)m_health / m_maxHealth;
        
        if (m_health <= 0) { m_IsDead = true; } 
    }
    
    public void ChangeStamina(int amount)
    {
        m_stamina += amount;
        if (m_stamina <= 0) { m_stamina=0; } 

        m_staminaBar.value = (float)m_stamina / m_maxStamina;
    }

    public void Heal(int healAmount)
    {
        m_health += healAmount;
        if(m_health >= m_maxHealth) { m_health = m_maxHealth; }
    }


    #region getters

    public float GetHealth() { return m_health; }
    public float GetMaxHealth() { return m_maxHealth; }

    public float GetStamina() { return m_stamina; }
    public bool IsDead() { return m_IsDead; }
    public float GetMoveSpeed() { return m_speed; }
    public float GetMaxMoveSpeed() { return m_maxSpeed; }
    public GameObject GetOpponent() { return m_opponent; }
    public GameObject GetController() { return m_controller; }


    #endregion
}
