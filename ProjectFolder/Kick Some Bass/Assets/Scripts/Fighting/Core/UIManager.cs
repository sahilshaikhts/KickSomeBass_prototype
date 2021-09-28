using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] ui_stats_bars;
    [SerializeField] GameObject ui_screen_victory;
    [SerializeField] GameObject ui_screen_loose;


    public void PlayerWon()
    {
        ToggleStatBars(false);
        ui_screen_loose.SetActive(false);

        ui_screen_victory.SetActive(true);
    }

    public void PlayerLost()
    {
        ToggleStatBars(false);
        ui_screen_victory.SetActive(false);

        ui_screen_loose.SetActive(true);
    }

    void ToggleStatBars(bool state)
    {
        for (int i = 0; i < ui_stats_bars.Length; i++)
        {
            ui_stats_bars[i].SetActive(state);
        }
    }

}
