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