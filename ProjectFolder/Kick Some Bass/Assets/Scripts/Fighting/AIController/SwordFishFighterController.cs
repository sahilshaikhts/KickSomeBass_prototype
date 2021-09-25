using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFishFighterController : AIFighterController
{
    public override string EvaluateAppropriateAction()
    {
        return enemyAbilities[0];
    }
}
