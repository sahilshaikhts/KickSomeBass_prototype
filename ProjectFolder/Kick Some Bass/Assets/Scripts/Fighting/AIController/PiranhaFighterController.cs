using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaFighterController : AIFighterController
{
    public override string EvaluateAppropriateAction()
    {
        return enemyAbilities[0];
    }

    public override Vector3 GetMovementDirection()
    {
        return Vector3.zero;
    }
}
