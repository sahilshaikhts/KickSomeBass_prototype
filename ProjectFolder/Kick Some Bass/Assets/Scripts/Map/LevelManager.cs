using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEnums;

public class LevelManager : MonoBehaviour
{
    [SerializeField] UIManager m_UIManger;
    [SerializeField] GameObject m_player;
    [SerializeField] GameObject m_player_humanoid;
    [SerializeField] GameObject m_fighterPlayer;
    [SerializeField] GameObject m_fighterFish;
    [SerializeField] GameObject m_fighterFish_controller;
    [SerializeField] GameObject m_fighterPlayer_controller;
    [SerializeField] GameObject m_fishingObjectsP;


    private void Start()
    {
        m_UIManger.HideAllUI();     //uncomment for build
     //   StartFighting(); //uncomment for testing
    }

    public void StartFishing()
    {
        m_fishingObjectsP.SetActive(true);
        m_player.SetActive(false);
        m_fighterPlayer.SetActive(false);
        m_fighterFish_controller.SetActive(false);
        m_fighterPlayer_controller.SetActive(false);
        m_fighterFish.SetActive(false);
        m_player_humanoid.SetActive(false);

        m_player_humanoid.GetComponent<MyInterfaces.IControllable>().Deactivate();
    }

    public void StartFighting()
    {
        m_fighterPlayer.SetActive(true);
        m_fighterFish.SetActive(true);
        m_fighterFish_controller.SetActive(true);
        m_fighterPlayer_controller.SetActive(true);

        m_fishingObjectsP.SetActive(false);
        m_player.SetActive(false);
        m_player_humanoid.SetActive(false);
        m_player_humanoid.GetComponent<MyInterfaces.IControllable>().Deactivate();

        m_UIManger.ShowStats();

    }

    public void StartRoaming()
    {
        m_player.SetActive(true);
        m_fighterPlayer.SetActive(false);
        m_fighterFish.SetActive(false);
        m_player_humanoid.SetActive(true);
        m_fishingObjectsP.SetActive(false);
        m_fighterFish_controller.SetActive(false);
        m_fighterPlayer_controller.SetActive(false);
        m_player_humanoid.GetComponent<MyInterfaces.IControllable>().Initialize();
        m_player_humanoid.transform.position = m_player.transform.position;
    }
}


