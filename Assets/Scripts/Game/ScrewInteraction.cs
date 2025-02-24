
using UnityEngine;
using UnityEngine.UI;

public class ScrewInteraction : MonoBehaviour
{
    public PlankController plank; // Reference to the plank
    public bool isLeftScrew; // Check if this is the left screw

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RemoveScrew);
    }

    void RemoveScrew()
    {
        plank.ScrewRemoved(isLeftScrew);
        Destroy(gameObject);  // Destroy the screw GameObject when removed
    }
}
