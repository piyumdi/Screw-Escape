using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject[] levels; // All levels in the Hierarchy (Visibility Unticked)
    [SerializeField] private GameObject nextLevelUIPanel; // UI Panel for Next Level
    private int currentLevelIndex = 0; // Track current level

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextLevelUI()
    {
        
        Invoke("ShowNextLevelPanel", 5f);
    }

    private void ShowNextLevelPanel()
    {
        if (nextLevelUIPanel != null)
        {
            nextLevelUIPanel.SetActive(true);
        }
    }

    public void LoadNextLevel()
    {
        if (levels.Length == 0)
        {
            Debug.LogError("No levels assigned in the inspector!");
            return;
        }

        // Hide UI Panel before switching level
        if (nextLevelUIPanel != null)
        {
            nextLevelUIPanel.SetActive(false);
        }

        // Hide current level and show the next one
        levels[currentLevelIndex].SetActive(false);
        currentLevelIndex++;

        if (currentLevelIndex < levels.Length)
        {
            levels[currentLevelIndex].SetActive(true);
            Debug.Log("Activated Level: " + (currentLevelIndex + 1));

            // Reset the timer for the new level
            GameTimer timer = FindObjectOfType<GameTimer>();
            if (timer != null)
            {
                timer.ResetTimer();
            }
        }
        else
        {
            Debug.Log("No more levels! Game Completed.");
        }
    }

}
