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
        rb.isKinematic = true; // Keep the plank still at the start
    }

    public void ScrewRemoved(bool isLeftScrew)
    {
        if (isLeftScrew)
            hasLeftScrew = false;
        else
            hasRightScrew = false;

        // If only one screw remains, attach hinge there
        if (hasLeftScrew && !hasRightScrew)
        {
            AttachHinge(leftScrewPos.position); // Rotate around left screw
        }
        else if (!hasLeftScrew && hasRightScrew)
        {
            AttachHinge(rightScrewPos.position); // Rotate around right screw
        }
        else if (!hasLeftScrew && !hasRightScrew)
        {
            DropPlank(); // No screws left → free fall
        }
    }

    void AttachHinge(Vector2 anchorPosition)
    {
        if (hinge != null) Destroy(hinge); // Remove any previous hinge

        rb.isKinematic = false; // Enable physics
        rb.gravityScale = 3f; // Apply realistic movement

        hinge = gameObject.AddComponent<HingeJoint2D>();
        hinge.autoConfigureConnectedAnchor = false;

        // Convert world position to local space for precise attachment
        hinge.anchor = transform.InverseTransformPoint(anchorPosition);
        
        // Slow down swinging effect
        JointMotor2D motor = new JointMotor2D
        {
            motorSpeed = 0,
            maxMotorTorque = 10f
        };
        hinge.useMotor = true;
        hinge.motor = motor;
    }

    void DropPlank()
    {
        if (hinge != null) Destroy(hinge); // Remove hinge so it falls freely
        rb.isKinematic = false;
        rb.gravityScale = 5f; // Falls freely with gravity
    }
}
