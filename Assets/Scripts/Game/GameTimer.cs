using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Slider timerSlider; 
    public GameObject gameOverUI;
    public GameObject gameUI; // Reference to Game UI
    private float timeLeft = 8f;
    private bool isRunning = false; // Start as false
    private bool isTimeFrozen = false;

    void Start()
    {
        ResetTimer(); 
    }

    void Update()
    {
        // Start the timer only if the Game UI is active
        if (!isRunning && gameUI.activeInHierarchy)
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
        isRunning = false; // Do not start immediately
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
