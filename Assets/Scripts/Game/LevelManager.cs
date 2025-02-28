/* prefabs
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject[] levels; 
    [SerializeField] private GameObject nextLevelUIPanel; 
    private int currentLevelIndex = 0; 

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

        
        if (nextLevelUIPanel != null)
        {
            nextLevelUIPanel.SetActive(false);
        }

       
        levels[currentLevelIndex].SetActive(false);
        currentLevelIndex++;

        if (currentLevelIndex < levels.Length)
        {
            levels[currentLevelIndex].SetActive(true);
            Debug.Log("Activated Level: " + (currentLevelIndex + 1));

           
            GameTimer timer = FindObjectOfType<GameTimer>();
            if (timer != null)
            {
                timer.IncreaseTimer(5); 
            }
        }
        else
        {
            Debug.Log("No more levels! Game Completed.");
        }
    }


}
*/

using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject[] levelPrefabs; // Assign level prefabs in Inspector
    [SerializeField] private Transform levelContainer;  // Parent object under GameUI > UI
    [SerializeField] private GameObject nextLevelUIPanel;
    
    private GameObject currentLevel;
    private int currentLevelIndex = 0;

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
    }

    private void Start()
    {
        LoadLevel(currentLevelIndex); // Load the first level at the start
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
        if (nextLevelUIPanel != null)
        {
            nextLevelUIPanel.SetActive(false);
        }

        if (currentLevel != null)
        {
            Destroy(currentLevel); // Remove the current level
        }

        currentLevelIndex++;

        if (currentLevelIndex < levelPrefabs.Length)
        {
            LoadLevel(currentLevelIndex);
        }
        else
        {
            Debug.Log("No more levels! Game Completed.");
        }
    }

    private void LoadLevel(int index)
    {
        if (index >= levelPrefabs.Length)
        {
            Debug.LogError("Level index out of range!");
            return;
        }

        currentLevel = Instantiate(levelPrefabs[index], levelContainer);
        Debug.Log("Loaded Level: " + (index + 1));

        // Optional: Increase timer when new level is loaded
        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer != null)
        {
            timer.IncreaseTimer(5);
        }
    }
}
