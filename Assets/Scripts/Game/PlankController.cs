/*
using UnityEngine;

public class PlankController : MonoBehaviour
{
    private Rigidbody2D rb;
    private HingeJoint2D hinge;
    private BoardManager boardManager; // Reference to BoardManager


    private bool hasLeftScrew = true;
    private bool hasRightScrew = true;

    [SerializeField] private Transform leftScrewPos;
    [SerializeField] private Transform rightScrewPos;

    private float fallThresholdY = -10f; // If plank falls below this, it's gone



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Keep plank still at the start

        boardManager = GetComponentInParent<BoardManager>(); // Get reference to the board

    }

    void Update()
    {
        if (transform.position.y < fallThresholdY)
        {
            boardManager.PlankRemoved();
            Destroy(gameObject); // Remove plank from scene
        }
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

        
        // Allow rotation & free movement after hinge is set
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
*/

using UnityEngine;

public class PlankController : MonoBehaviour
{
    private Rigidbody2D rb;
    private HingeJoint2D hinge;
    private BoardManager boardManager; // Reference to BoardManager

    private bool hasLeftScrew = true;
    private bool hasRightScrew = true;

    [SerializeField] private Transform leftScrewPos;
    [SerializeField] private Transform rightScrewPos;

    private float fallThresholdY = -10f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Keep plank still at the start

        boardManager = GetComponentInParent<BoardManager>(); // Get reference to the board
    }

    void Update()
    {
        if (transform.position.y < fallThresholdY)
        {
            boardManager.PlankRemoved();
            Destroy(gameObject); // Remove plank from scene
        }
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
        if (hinge != null) Destroy(hinge);

        rb.isKinematic = false; 
        rb.gravityScale = 30f;

        rb.constraints = RigidbodyConstraints2D.FreezePositionX;

        hinge = gameObject.AddComponent<HingeJoint2D>();
        hinge.autoConfigureConnectedAnchor = false;

        hinge.anchor = transform.InverseTransformPoint(screwTransform.position);
        hinge.connectedAnchor = screwTransform.position;

        rb.constraints = RigidbodyConstraints2D.None; 
    }

    void DropPlank()
    {
        if (hinge != null) Destroy(hinge);
        rb.isKinematic = false;
        rb.gravityScale = 30f;
        rb.constraints = RigidbodyConstraints2D.None;
    }

    // NEW FUNCTION: Remove one screw when Power Drill is used
    public void RemoveOneScrew()
    {
        if (hasLeftScrew && hasRightScrew)
        {
            if (Random.value < 0.5f)
                ScrewRemoved(true);
            else
                ScrewRemoved(false);
        }
        else if (hasLeftScrew)
        {
            ScrewRemoved(true);
        }
        else if (hasRightScrew)
        {
            ScrewRemoved(false);
        }
    }
}
