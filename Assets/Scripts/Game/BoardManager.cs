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
            // Instantiate broken pieces at the board's position and rotation, without parenting them to the board
            GameObject brokenPieces = Instantiate(brokenBoardPrefab, transform.position, transform.rotation);

            // If necessary, reset scale to match the original board's scale
            brokenPieces.transform.localScale = transform.localScale;

            // Optionally, you can move the broken pieces to a specific "scene root" to prevent accidental parenting
            brokenPieces.transform.SetParent(null); // This ensures the pieces are independent of the board

            Debug.Log("Board broke into pieces!");

            if (characterAnimation != null)
            {
                characterAnimation.StartJumping();  // Make the character jump!
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
    }

}
