using AbilitySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IFighterCharacter : MonoBehaviour
{
    [SerializeField] GameObject m_opponent;
    [SerializeField] protected GameObject m_controller;

    [SerializeField] protected Slider m_healthBar;
    [SerializeField] protected Slider m_staminaBar;

    [SerializeField] int m_health = 100, m_maxHealth = 100;
    [SerializeField] float m_stamina = 100, m_maxStamina = 100;
    [SerializeField] float m_speed, m_maxSpeed;

    private bool m_IsDead = false;
    protected bool m_disableabilites = false;

    public abstract Vector3 GetMovementDirection();

    public abstract void ExecuteAction(IFightAbility fightAbility, AbilityState abilityState);

    public void DisableAbilityUsage() { m_disableabilites = true; }

    public void ChangeHealth(int amount)
    {
        m_health += amount;

        if (m_health <= 0)
        {
            m_IsDead = true;
            m_disableabilites = true;
            Cursor.lockState = CursorLockMode.None;

            if (!GetComponent<PlayerFighterCharacter>())
            {
                GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().PlayerWon();
                Debug.Log(name+m_health);
            }
            else
            {
                Debug.Log(name+m_health);
                GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().PlayerLost();
            }
        }

        if (m_health >= m_maxHealth){m_health = m_maxHealth;}

        m_healthBar.value = (float)m_health / m_maxHealth;
    }

    public void ChangeStamina(float amount)
    {
        m_stamina += amount;
        if (m_stamina <= 0) { m_stamina = 0; }
        if (m_stamina >= m_maxStamina) { m_stamina = m_maxStamina; }

        m_staminaBar.value = (float)m_stamina / m_maxStamina;

        if (amount < 0)
        {
            m_staminaBar.gameObject.GetComponent<Animator>().SetTrigger("flashRed");
        }
    }

    #region getters

    public float GetHealth() { return m_health; }
    public float GetMaxHealth() { return m_maxHealth; }

    public float GetStamina() { return m_stamina; }
    public float GetMaxStamina() { return m_maxStamina; }

    public bool IsDead() { return m_IsDead; }
    public float GetMoveSpeed() { return m_speed; }
    public float GetMaxMoveSpeed() { return m_maxSpeed; }
    public GameObject GetOpponent() { return m_opponent; }
    public GameObject GetController() { return m_controller; }


    #endregion
}
