using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour
{
    private int totalPlanks;

    [SerializeField] private GameObject brokenBoardPrefab; // Broken board pieces

    [SerializeField] private CharacterAnimation characterAnimation;

    void Start()
    {
        totalPlanks = transform.childCount; // Count planks attached to the board
    }

    public void PlankRemoved()
    {
        totalPlanks--;

        if (totalPlanks <= 0)
        {
            Debug.Log("All planks removed! The board will break in 1 second.");
            StartCoroutine(BreakBoardAfterDelay(1f)); // Wait 1 second before breaking
        }
    }

    IEnumerator BreakBoardAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        BreakBoard();
    }
    
    void BreakBoard()
    {
        if (brokenBoardPrefab != null)
        {
            GameObject brokenPieces = Instantiate(brokenBoardPrefab, transform.position, transform.rotation);
            brokenPieces.transform.localScale = transform.localScale;
            brokenPieces.transform.SetParent(null);

            // Find the Canvas (StartUI/GameUI) and set as parent
            Transform canvasTransform = GameObject.Find("Canvas").transform;
            if (canvasTransform != null)
            {
                brokenPieces.transform.SetParent(canvasTransform, false);
                Debug.Log("Broken pieces added to Canvas.");

                // Change position manually (adjust values as needed)
                RectTransform rectTransform = brokenPieces.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    rectTransform.anchoredPosition = new Vector2(0, -200); // Adjust X and Y position
                }
                else
                {
                    brokenPieces.transform.position = new Vector3(0, -2, 0); // Adjust world position
                }
            }
            else
            {
                Debug.LogError("Canvas not found! Ensure there is a Canvas in the scene.");
            }

            // Bring the broken pieces forward in UI layer
            brokenPieces.transform.SetAsLastSibling();

            Debug.Log("Board broke into pieces!");

            if (characterAnimation != null)
            {
                characterAnimation.StartJumping();
            }
            else
            {
                Debug.LogError("CharacterAnimation is not assigned in the Inspector!");
            }
        }
        else
        {
            Debug.LogError("brokenBoardPrefab is not assigned in the Inspector!");
        }

        Destroy(gameObject); // Remove the original board

        // Wait 3 seconds, then show the Next Level UI
        LevelManager.Instance.LoadNextLevelUI();
    }




    IEnumerator LoadNextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelManager.Instance.LoadNextLevel();
    }

}