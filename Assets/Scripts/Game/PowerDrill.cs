
using UnityEngine;

public class PowerDrill : MonoBehaviour
{
    public void UsePowerDrill()
    {
        PlankController[] planks = FindObjectsOfType<PlankController>();

        if (planks.Length > 0)
        {
            // Remove one screw from EACH plank (one per plank)
            foreach (PlankController plank in planks)
            {
                plank.RemoveOneScrew();
            }
        }
    }
}
