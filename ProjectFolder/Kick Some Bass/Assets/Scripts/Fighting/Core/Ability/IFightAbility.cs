using UnityEngine;

namespace AbilitySpace
{ 

public abstract class IFightAbility : MonoBehaviour
{
    public abstract string GetAbilityName();

    public abstract void PerformAction(IFighterCharacter fighter);
    public abstract void Animation(IFighterCharacter fighter);
}

}