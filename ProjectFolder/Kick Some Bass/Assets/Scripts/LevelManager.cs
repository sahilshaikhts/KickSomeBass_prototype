using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEnums;

public class LevelManager : MonoBehaviour
{
    PlayerStates m_playerState;

    [SerializeField]player m_player;

    private void Start()
    {
        m_playerState = PlayerStates.onIsland;
    }


    public void ChangePlayerState(PlayerStates newState)
    {

    }

    public PlayerStates GetPlayerState()
    {
        return m_playerState;
    }
}
