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
    }

    Destroy(gameObject); // Remove the original board

    // Ensure LevelManager exists before calling LoadNextLevel
    if (LevelManager.Instance != null)
    {
        LevelManager.Instance.LoadNextLevel();
    }
    else
    {
        Debug.LogError("LevelManager instance is null! Make sure it's in the scene.");
    }
}


    IEnumerator LoadNextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelManager.Instance.LoadNextLevel();
    }

}