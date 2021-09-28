using UnityEngine;
using System;

public class AIFighterController : MonoBehaviour
{
    [SerializeField] protected string[] m_enemyAbilitiesName;
    [SerializeField] IFighterCharacter m_enemyAI;


    [SerializeField] AbilitySpace.IFightAbility[] m_fightAbilities;

    [SerializeField] float m_decisionDelay = 1.5f;
    private bool m_move = false;
    private float m_delayTimer;
    private float m_keepMovingTimer;
    private float moveDirection = 0.0f;

    private void InitializeFightAbilities()
    {
        m_fightAbilities = new AbilitySpace.IFightAbility[m_enemyAbilitiesName.Length];

        for (int i = 0; i < m_enemyAbilitiesName.Length; i++)
        {
            m_fightAbilities[i] = AbilitiesFactory.GetAbility(m_enemyAbilitiesName[i]).GetInstance(gameObject);
        }
    }

    private void Start()
    {
        InitializeFightAbilities();
        m_delayTimer = m_decisionDelay;
        m_keepMovingTimer = m_decisionDelay;
    }

//Will run the algorithm to get appropriate action for specific AI.
public string EvaluateAppropriateAction()
    {
        Tuple<float, AbilitySpace.IFightAbility> priorityMove = new Tuple<float, AbilitySpace.IFightAbility>(0.0f, null);

        foreach (AbilitySpace.IFightAbility fightAbility in m_fightAbilities)
        {
            IUtilityAI AIAbility = (IUtilityAI)fightAbility;

            float utilityScore = AIAbility.EvaulateAbilityUtility(m_enemyAI);

            //Break immediately if someused veto.
            if (AIAbility.GetVeto())
            {
                priorityMove = new Tuple<float, AbilitySpace.IFightAbility>(utilityScore, fightAbility);
                break;
            }

            if (utilityScore > priorityMove.Item1)
            {
                priorityMove = new Tuple<float, AbilitySpace.IFightAbility>(utilityScore, fightAbility);
            }
        }

        if (priorityMove.Item2.GetAbilityName() == "Movement")
        {
            float score = priorityMove.Item1;

            moveDirection = (score * 2) - 1;

            m_move = true;

            float verySmall = 0.35f;

            if (moveDirection <= verySmall && moveDirection >= -verySmall)
            {
                moveDirection *= 2.2f;
            }
        }

        return priorityMove.Item2.GetAbilityName();
    }

    public virtual void Update()
    {
        m_enemyAI.ChangeStamina((int)(300 * Time.deltaTime));

        m_delayTimer -= Time.deltaTime;

        if (m_delayTimer <= 0.0f)
        {
            m_delayTimer = m_decisionDelay;

            string currentActionName = EvaluateAppropriateAction();

            PerformAction(currentActionName);
        }

        if (m_move)
        {
            m_keepMovingTimer -= Time.deltaTime;

            PerformAction("Movement");

            if (m_delayTimer <= 0.0f)
            {
                m_move = false;
                moveDirection = 0.0f;
            }
        }

        if (Vector3.Distance(m_enemyAI.transform.position, m_enemyAI.GetOpponent().transform.position) <= 3.0f)
        {
            m_move = false;
            moveDirection = 0.0f;
        }

        if (!m_move)
        {
            PerformAction("Movement");
        }
    }

    private void PerformAction(string abilityName,AbilitySpace.AbilityState abilityState= AbilitySpace.AbilityState.Enter)
    {
        if (abilityName == "Null") { abilityName = "Idle"; }

        for (int i = 0; i < m_enemyAbilitiesName.Length; i++)
        {
            if (abilityName == m_enemyAbilitiesName[i])
            {
                m_enemyAI.ExecuteAction(m_fightAbilities[i], abilityState);
                break;
            }
        }
    }

    public Vector3 GetMovementDirection()
    {
        Vector3 moveDir = new Vector3(0.0f, 0.0f, moveDirection);
        Debug.Log("AI Moved :" + moveDirection);

        return moveDir;
    }
}