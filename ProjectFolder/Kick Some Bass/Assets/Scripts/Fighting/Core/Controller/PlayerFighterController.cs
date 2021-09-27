//Doesn't support multiple keys for single actions.

using UnityEngine;
using UnityEngine.Assertions;

public class PlayerFighterController : MonoBehaviour
{
    [System.Serializable]
    struct InputKey
    {
        public enum InputType
        {
            KeyPressedOnce,
            KeyPressed,
            KeyUp,
        };

        public KeyCode m_keyCode;
        public InputType m_inputType;
    }


    [SerializeField] string[] playerAbilities;
    [SerializeField] InputKey[] m_playerInput;

    [SerializeField] PlayerFighterCharacter player;

    void Update()
    {
        player.ExecuteAction(AbilitiesFactory.GetAbility("Movement"));

        PerformAction();
    }

    void PerformAction()
    {
        //Require to associate the Ability action with equivalent Input key.
        Assert.AreEqual(playerAbilities.Length, m_playerInput.Length);

        for (uint i = 0; i < m_playerInput.Length; i++)
        {
            if (m_playerInput[i].m_inputType == InputKey.InputType.KeyPressedOnce)
            {
                if (Input.GetKeyDown(m_playerInput[i].m_keyCode))
                {
                    player.ExecuteAction(AbilitiesFactory.GetAbility(playerAbilities[i]));
                }
            }
            else if (m_playerInput[i].m_inputType == InputKey.InputType.KeyPressed)
            {
                if (Input.GetKey(m_playerInput[i].m_keyCode))
                {
                    player.ExecuteAction(AbilitiesFactory.GetAbility(playerAbilities[i]));
                }
            }
            else if (m_playerInput[i].m_inputType == InputKey.InputType.KeyUp)
            {
                if (Input.GetKeyUp(m_playerInput[i].m_keyCode))
                {
                    player.ExecuteAction(AbilitiesFactory.GetAbility(playerAbilities[i]));
                }
            }
        }
    }

    public Vector3 GetMovementDirection()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }
}
