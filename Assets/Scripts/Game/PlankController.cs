using UnityEngine;

public class PlankController : MonoBehaviour
{
    private Rigidbody2D rb;
    private HingeJoint2D hinge;

    private bool hasLeftScrew = true;
    private bool hasRightScrew = true;

    [SerializeField] private Transform leftScrewPos;
    [SerializeField] private Transform rightScrewPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Keep plank still at the start
    }

    public void ScrewRemoved(bool isLeftScrew)
    {
        if (isLeftScrew)
            hasLeftScrew = false;
        else
            hasRightScrew = false;

        if (hasLeftScrew && !hasRightScrew)
        {
            AttachHinge(leftScrewPos);
        }
        else if (!hasLeftScrew && hasRightScrew)
        {
            AttachHinge(rightScrewPos);
        }
        else if (!hasLeftScrew && !hasRightScrew)
        {
            DropPlank();
        }
    }

    void AttachHinge(Transform screwTransform)
    {
        if (hinge != null) Destroy(hinge); // Remove previous hinge

        rb.isKinematic = false; // Enable physics
        rb.gravityScale = 30f;

        // Temporarily lock X position to prevent shifting
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;

        hinge = gameObject.AddComponent<HingeJoint2D>();
        hinge.autoConfigureConnectedAnchor = false;

        // Set correct local anchor point to avoid shifting
        hinge.anchor = transform.InverseTransformPoint(screwTransform.position);

        // Ensure hinge is correctly positioned in world space
        hinge.connectedAnchor = screwTransform.position;

        //Allow rotation & free movement after hinge is set
        rb.constraints = RigidbodyConstraints2D.None; // Remove all constraints
    }

    void DropPlank()
    {
        if (hinge != null) Destroy(hinge); // Remove hinge so it falls freely
        rb.isKinematic = false;
        rb.gravityScale = 30f;
        rb.constraints = RigidbodyConstraints2D.None; // Allow free fall
    }
}
