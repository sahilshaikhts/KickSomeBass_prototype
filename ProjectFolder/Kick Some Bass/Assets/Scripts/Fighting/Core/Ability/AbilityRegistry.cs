using UnityEngine;
using AbilitySpace;

public class AbilityRegistry : MonoBehaviour
{
    private void Start()
    {
        IFightAbility[] fightAbilities = GetComponents<IFightAbility>();

        RegisterToFactory(fightAbilities);
    }

    //Regiters all the string literals with appropriate abilities to Factory
    private void RegisterToFactory(IFightAbility[] fightAbilities)
    {
        foreach(IFightAbility fightAbility in fightAbilities)
        {
            AbilitiesFactory.AddFightAbility(fightAbility.GetAbilityName(), fightAbility);
        }
    }
}