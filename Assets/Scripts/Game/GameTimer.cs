using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Slider timerSlider; 
    public GameObject gameOverUI; 
    private float timeLeft = 8f; 
    private bool isRunning = false; 
    private bool isTimeFrozen = false;

    public GameObject gameUIPanel;

    void Start()
    {
        ResetTimer(); 
    }

    void Update()
    {
        if (!isRunning && gameUIPanel.activeSelf)
        {
            isRunning = true;
        }
        if (isRunning && !isTimeFrozen)
        {
            timeLeft -= Time.deltaTime;
            timerSlider.value = timeLeft / 8f; 

            if (timeLeft <= 0)
            {
                GameOver();
            }
        }
    }

    public void ResetTimer()
    {
        timeLeft = 8f;
        isRunning = false;
        isTimeFrozen = false;
        timerSlider.value = 1; 
        gameOverUI.SetActive(false); 
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
}
