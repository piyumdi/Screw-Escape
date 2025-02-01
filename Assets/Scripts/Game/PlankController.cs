using UnityEngine;

public class PlankController : MonoBehaviour
{
    private int leftScrews = 0;
    private int rightScrews = 0;
    private Rigidbody2D rb;
    private HingeJoint2D hinge;
    private bool isPivoting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Prevent movement initially

        // Count screws
        foreach (ScrewInteraction screw in FindObjectsOfType<ScrewInteraction>())
        {
            if (screw.isLeftScrew) leftScrews++;
            else rightScrews++;
        }
    }

    public void ScrewRemoved(bool isLeftScrew)
    {
        if (isLeftScrew)
            leftScrews--;
        else
            rightScrews--;

        if ((leftScrews == 0 && rightScrews > 0) || (rightScrews == 0 && leftScrews > 0))
        {
            AttachHinge(); // Attach hinge to the remaining screw
        }
        else if (leftScrews == 0 && rightScrews == 0)
        {
            DropPlank(); // No screws left, let it fall
        }
    }


    void AttachHinge()
    {
        if (isPivoting) return; // Prevent multiple hinges
        isPivoting = true;

        rb.isKinematic = false; // Enable physics so the plank can move
        rb.gravityScale = 30f;   // Apply gravity for a natural swing

        // Remove any existing hinge
        if (hinge != null) Destroy(hinge);

        // Find the remaining screw position
        Vector3 remainingScrewPosition;
        if (leftScrews > 0)
            remainingScrewPosition = FindScrewPosition(true); // Left screw remains
        else if (rightScrews > 0)
            remainingScrewPosition = FindScrewPosition(false); // Right screw remains
        else
            return; // No screws left, so don't add a hinge

        // Create a new hinge joint
        hinge = gameObject.AddComponent<HingeJoint2D>();
        hinge.autoConfigureConnectedAnchor = false;
        hinge.connectedBody = null; // Attach to world, not another object

        // Set hinge anchor at the remaining screw's position
        hinge.anchor = transform.InverseTransformPoint(remainingScrewPosition);

        // Allow free swinging motion
        hinge.useLimits = false;
    }


    void DropPlank()
    {
        if (hinge != null)
        {
            Destroy(hinge);
        }
        rb.isKinematic = false;
        rb.gravityScale = 30f;
    }

    Vector3 FindScrewPosition(bool isLeft)
    {
        foreach (ScrewInteraction screw in FindObjectsOfType<ScrewInteraction>())
        {
            if (screw.isLeftScrew == isLeft)
            {
                return screw.transform.position;
            }
        }
        return transform.position;
    }
}
