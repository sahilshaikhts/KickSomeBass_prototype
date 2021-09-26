using UnityEngine;

public abstract class AIFighterController : MonoBehaviour
{
    [SerializeField] protected string[] enemyAbilities;
    [SerializeField] BaseFighterCharacter EnemyAI;

    //Will run the algorithm to get appropriate action for specific AI.
    public abstract string EvaluateAppropriateAction();

    public virtual void Update()
    {

        string currentActionName = EvaluateAppropriateAction();
        ExecuteAction(currentActionName);
    }

    private void ExecuteAction(string abilityName)
    {
        if(abilityName == "No Action") { abilityName = "Idle"; }

        EnemyAI.ExecuteAction(AbilitiesFactory.GetAbility(abilityName));
    }

    public abstract Vector3 GetMovementDirection();
}
