using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFishFighterController : AIFighterController
{
    public override string EvaluateAppropriateAction()
    {
        return "Movement";
    }

    public override Vector3 GetMovementDirection()
    {
        return Vector3.zero;
    }
}
