using UnityEngine;
using AbilitySpace;

public class FighterCharacter : MonoBehaviour
{
    public void ExecuteAction(IFightAbility fightAbility)
    {
        fightAbility.PerformAction();
    }
}
