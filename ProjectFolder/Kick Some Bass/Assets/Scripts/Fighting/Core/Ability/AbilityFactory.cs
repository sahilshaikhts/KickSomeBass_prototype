using System.Collections.Generic;
using AbilitySpace;

static class AbilitiesFactory
{
    //Array to store string literal associated with ability pointer.
    public static Dictionary<string, IFightAbility> abilityList = new Dictionary<string, IFightAbility>();

    public static void AddFightAbility(string abilityName, IFightAbility fightAbility) { abilityList.Add(abilityName, fightAbility); }
    public static IFightAbility GetAbility(string abilityName) { return abilityList[abilityName]; }
}
