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
        gameObject.SetActive(false); // Hide the screw after removal
        plank.ScrewRemoved(isLeftScrew);
    }
}
