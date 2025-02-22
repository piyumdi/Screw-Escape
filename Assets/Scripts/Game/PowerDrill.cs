using UnityEngine;

public class PowerDrill : MonoBehaviour
{
    public void UsePowerDrill()
    {
        PlankController[] planks = FindObjectsOfType<PlankController>();

        if (planks.Length > 0)
        {
            // Pick a random plank
            PlankController selectedPlank = planks[Random.Range(0, planks.Length)];
            selectedPlank.RemoveOneScrew();
        }
    }
}
