using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance; // Singleton pattern
    [SerializeField] private GameObject[] levels; // Array of level GameObjects in the Hierarchy
    private int currentLevelIndex = 0; // Start from Level 1

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Ensure only Level 1 is active at the start
        for (int i = 1; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
    }

    public void LoadNextLevel()
    {
        if (currentLevelIndex < levels.Length - 1)
        {
            StartCoroutine(ActivateNextLevelAfterDelay(3f));
        }
        else
        {
            Debug.Log("No more levels! Game Completed.");
        }
    }

    IEnumerator ActivateNextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Hide current level
        levels[currentLevelIndex].SetActive(false);
        
        // Show next level
        currentLevelIndex++;
        levels[currentLevelIndex].SetActive(true);
        Debug.Log("Level " + (currentLevelIndex + 1) + " is now visible.");
    }
}
