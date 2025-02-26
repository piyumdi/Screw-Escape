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
