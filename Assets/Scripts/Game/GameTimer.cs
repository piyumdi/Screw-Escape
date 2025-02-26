/*
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Slider timerSlider; 
    public GameObject gameOverUI; 
    private float timeLeft = 15f; 
    private bool isRunning = true; 
    private bool isTimeFrozen = false;

    void Start()
    {
        ResetTimer(); 
    }

    void Update()
    {
        if (isRunning && !isTimeFrozen)
        {
            timeLeft -= Time.deltaTime;
            timerSlider.value = timeLeft / 15f; 

            if (timeLeft <= 0)
            {
                GameOver();
            }
        }
    }

    public void ResetTimer()
    {
        timeLeft = 15f;
        isRunning = true;
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
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Slider timerSlider; 
    public GameObject gameOverUI; 
    private float timeLeft;
    private bool isRunning = true; 
    private bool isTimeFrozen = false;
    private float baseTime = 15f;  // Initial time limit

    void Start()
    {
        ResetTimer(); 
    }

    void Update()
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

    public void ResetTimer()
    {
        timeLeft = baseTime;  // Set time based on increasing baseTime
        isRunning = true;
        isTimeFrozen = false;
        timerSlider.value = 1; 
        gameOverUI.SetActive(false); 
    }

    public void IncreaseTimer(int seconds)
    {
        baseTime += seconds;  // Increase the base time
        ResetTimer();  // Reset with new time
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
