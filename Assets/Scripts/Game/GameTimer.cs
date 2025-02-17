using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Slider timerSlider; // Assign from Inspector
    public GameObject gameOverUI; // Assign Game Over Panel
    private float timeLeft = 4f; // Timer starts at 4 seconds
    private bool isRunning = true; 

    void Start()
    {
        ResetTimer(); // Reset at start of level
    }

    void Update()
    {
        if (isRunning)
        {
            timeLeft -= Time.deltaTime;
            timerSlider.value = timeLeft / 4f; // Normalize to 0-1 range

            if (timeLeft <= 0)
            {
                GameOver();
            }
        }
    }

    public void ResetTimer()
    {
        timeLeft = 4f;
        isRunning = true;
        timerSlider.value = 1; // Full bar at start
        gameOverUI.SetActive(false); // Hide Game Over screen
    }

    void GameOver()
    {
        isRunning = false;
        gameOverUI.SetActive(true);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads level
    }

    public void StopTimer()
    {
        isRunning = false;
        gameOverUI.SetActive(false); // Ensure Game Over UI does not show
    }

}
