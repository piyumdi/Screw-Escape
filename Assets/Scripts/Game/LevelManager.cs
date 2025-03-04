
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject[] levelPrefabs; 
    [SerializeField] private Transform levelContainer;  
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
        LoadLevel(currentLevelIndex); 
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
            Destroy(currentLevel); 
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

        
        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer != null)
        {
            timer.IncreaseTimer(2);
        }
    }
}
