//Doesn't support multiple keys for single actions.

using UnityEngine;
using UnityEngine.Assertions;

public class PlayerFighterController : MonoBehaviour
{
    [SerializeField] string[] playerAbilities;
    [SerializeField] KeyCode[] playerInput;

    [SerializeField] FighterCharacter player;

    void Update()
    {
        PerformAction();
    }

    void PerformAction()
    {
        //Require to associate the Ability action with equivalent Input key.
        Assert.AreEqual(playerAbilities.Length, playerInput.Length);

        for(uint i = 0; i < playerAbilities.Length; i++)
        {
            if (Input.GetKeyDown(playerInput[i]))
            {
                player.ExecuteAction(AbilitiesFactory.GetAbility(playerAbilities[i]));
            }
        }
    }

}
