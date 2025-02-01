using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject startUI;
    public GameObject gameUI;
    public GameObject settingsUI;
    public GameObject nextLevelUI;
    public GameObject gameOverUI;
    public GameObject helpUI;
    public GameObject PowerDrillUI;
    public GameObject RustRemoverUI;
    public GameObject TimeFreezeUI;



    public void ShowgameUI()
    {
        gameUI.SetActive(true);
    }

    public void ShowHelpUI()
    {
        helpUI.SetActive(true);
    }

    
    public void ShowSettingsUI()
    {
        settingsUI.SetActive(true);
    }

    public void HideHelpUI()
    {
        helpUI.SetActive(false);
    }


    public void HideSettingsUI()
    {
        settingsUI.SetActive(false);
    }

    public void ShowPowerDrillUI()
    {
        PowerDrillUI.SetActive(true);
    }

    public void ShowRustRemoverUI()
    {
        RustRemoverUI.SetActive(true);
    }

    public void ShowTimeFreezeUI()
    {
        TimeFreezeUI.SetActive(true);
    }

    public void HidePowerDrillUI()
    {
        PowerDrillUI.SetActive(false);
    }

    public void HideRustRemoverUI()
    {
        RustRemoverUI.SetActive(false);
    }

    public void HideTimeFreezeUI()
    {
        TimeFreezeUI.SetActive(false);
     }


}
