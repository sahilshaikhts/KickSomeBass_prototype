using UnityEngine;

namespace AbilitySpace
{ 
public abstract class IFightAbility : MonoBehaviour
{
    public abstract string GetAbilityName();
    public abstract void PerformAction();
    public abstract void Animation();
}
}