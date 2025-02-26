
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Slider timerSlider;
    public GameObject gameOverUI;
    
    [Header("UI Panels")]
    public GameObject settingsUIPanel;
    public GameObject powerDrillUIPanel;
    public GameObject timeFreezerUIPanel;
    public GameObject rustRemoverUIPanel;

    private float timeLeft;
    private bool isRunning = true;
    private bool isTimeFrozen = false;
    private float baseTime = 15f;  

    void Start()
    {
        ResetTimer(); 
    }

    void Update()
    {
        if (settingsUIPanel.activeSelf || powerDrillUIPanel.activeSelf || timeFreezerUIPanel.activeSelf || rustRemoverUIPanel.activeSelf)
        {
            PauseTimer();
        }
        else
        {
            if (isRunning && !isTimeFrozen)
            {
                timeLeft -= Time.deltaTime;
                timerSlider.value = timeLeft / baseTime;

                if (timeLeft <= 0)
                {
                    GameOver();
                }
            }
        }
    }

    public void ResetTimer()
    {
        timeLeft = baseTime;  
        isRunning = true;
        isTimeFrozen = false;
        timerSlider.value = 1;
        gameOverUI.SetActive(false);
    }

    public void IncreaseTimer(int seconds)
    {
        baseTime += seconds;  
        ResetTimer();  
    }

    void GameOver()
    {
        isRunning = false;
        gameOverUI.SetActive(true);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StopTimer()
    {
        isRunning = false;
        gameOverUI.SetActive(false);
    }

    public void ToggleTimeFreeze()
    {
        isTimeFrozen = !isTimeFrozen;
    }

    private void PauseTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
    }

    
    public void OnCloseUI()
    {
       
        ResumeTimer();
    }
}
