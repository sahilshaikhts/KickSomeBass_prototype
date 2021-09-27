using UnityEngine;
using System;

public class AIFighterController : MonoBehaviour
{
    [SerializeField] protected string[] enemyAbilities;
    [SerializeField] IFighterCharacter EnemyAI;

    //Will run the algorithm to get appropriate action for specific AI.
    public string EvaluateAppropriateAction()
    {
        Tuple<float, string> priorityMove = new Tuple<float, string>(0.0f, "Null");

        foreach (string fightAbility in enemyAbilities)
        {
            if (AbilitiesFactory.GetAbility(fightAbility) is IUtilityAI)
            {
                IUtilityAI AIAbility = (IUtilityAI)AbilitiesFactory.GetAbility(fightAbility);

                float utilityScore = AIAbility.EvaulateAbilityUtility(EnemyAI);

                if (utilityScore > priorityMove.Item1)
                {
                    priorityMove = new Tuple<float, string>(utilityScore, fightAbility);
                }
            }
        }
        return priorityMove.Item2;
    }

    public virtual void Update()
    {
        string currentActionName = EvaluateAppropriateAction();
        ExecuteAction(currentActionName);


        ExecuteAction("Movement");
    }

    private void ExecuteAction(string abilityName)
    {
        if (abilityName == "Null") { abilityName = "Idle"; }

        EnemyAI.ExecuteAction(AbilitiesFactory.GetAbility(abilityName));
    }

    public Vector3 GetMovementDirection()
    {
        return Vector3.zero;
    }
}