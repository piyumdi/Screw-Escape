using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public GameObject helpUI2;
    public GameObject PowerDrillUI;
    public GameObject TimeFreezeUI;



    public void ShowgameUI()
    {
        gameUI.SetActive(true);
    }

    public void ShowHelpUI()
    {
        helpUI.SetActive(true);
    }

    public void ShowHelpUI2()
    {
        helpUI.SetActive(false);
        helpUI2.SetActive(true);
    }
    
    public void ShowSettingsUI()
    {
        settingsUI.SetActive(true);
    }

    public void HideHelpUI()
    {
        helpUI.SetActive(false);
    }

    public void HideHelpUI2()
    {
        helpUI2.SetActive(false);
    }

    public void HideSettingsUI()
    {
        settingsUI.SetActive(false);
    }

    public void ShowPowerDrillUI()
    {
        PowerDrillUI.SetActive(true);
    }

    public void ShowTimeFreezeUI()
    {
        TimeFreezeUI.SetActive(true);
    }

    public void HidePowerDrillUI()
    {
        PowerDrillUI.SetActive(false);
    }

    public void HideTimeFreezeUI()
    {
        TimeFreezeUI.SetActive(false);
     }

    public void ShowStartUI()
    {
        startUI.SetActive(true);
        gameUI.SetActive(false);
        gameOverUI.SetActive(false);
        nextLevelUI.SetActive(false);
        settingsUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
