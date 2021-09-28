using UnityEngine;
using System;

public class AIFighterController : MonoBehaviour
{
    [SerializeField] protected string[] m_enemyAbilitiesName;
    [SerializeField] IFighterCharacter m_enemyAI;


    [SerializeField] AbilitySpace.IFightAbility[] m_fightAbilities;

    [SerializeField]float m_decisionDelay = 1.5f;

    private float m_delayTimer; 

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
    }

//Will run the algorithm to get appropriate action for specific AI.
public string EvaluateAppropriateAction()
    {
        Tuple<float, string> priorityMove = new Tuple<float, string>(0.0f, "Null");

        foreach (AbilitySpace.IFightAbility fightAbility in m_fightAbilities)
        {
            IUtilityAI AIAbility = (IUtilityAI)fightAbility;

            float utilityScore = AIAbility.EvaulateAbilityUtility(m_enemyAI);

            //Break immediately if someused veto.
            if(AIAbility.GetVeto())
            {
                priorityMove = new Tuple<float, string>(utilityScore, fightAbility.GetAbilityName());
                break;
            }

            if (utilityScore > priorityMove.Item1)
            {
                priorityMove = new Tuple<float, string>(utilityScore, fightAbility.GetAbilityName());
            }
        }
        return priorityMove.Item2;
    }

    public virtual void Update()
    {
        m_enemyAI.ChangeStamina((int)(125 * Time.deltaTime));


        m_delayTimer -= Time.deltaTime;

        if (m_delayTimer <= 0.0f)
        {
            m_delayTimer = m_decisionDelay;

            string currentActionName = EvaluateAppropriateAction();

            PerformAction(currentActionName);

        }
        
        PerformAction("Movement");
    }

    private void PerformAction(string abilityName,AbilitySpace.AbilityState abilityState= AbilitySpace.AbilityState.Enter)
    {
        if (abilityName == "Null") { abilityName = "Idle"; }

        for(int i = 0; i < m_enemyAbilitiesName.Length; i++)
        {
            if(abilityName == m_enemyAbilitiesName[i])
            {
                m_enemyAI.ExecuteAction(m_fightAbilities[i], abilityState);
                break;
            }
        }
    }

    public Vector3 GetMovementDirection()
    {
        return Vector3.zero;
    }
}