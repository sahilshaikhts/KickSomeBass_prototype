using UnityEngine;

namespace AbilitySpace
{ 

public abstract class IFightAbility : MonoBehaviour
{
    public abstract string GetAbilityName();

    public abstract void PerformAction(GameObject aObject);
    public abstract void Animation(GameObject aObject);
}

}