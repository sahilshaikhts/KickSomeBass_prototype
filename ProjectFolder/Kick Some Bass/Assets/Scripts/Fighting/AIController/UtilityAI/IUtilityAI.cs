using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Only inherit an ability from IUtilityAI if the ability will be used by AI at any point.
public interface IUtilityAI
{
    float EvaulateAbilityUtility();
}
