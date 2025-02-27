

using UnityEngine;

public class PlankController : MonoBehaviour
{
    private Rigidbody2D rb;
    private HingeJoint2D hinge;
    private BoardManager boardManager;

    private bool hasLeftScrew = true;
    private bool hasRightScrew = true;

    [SerializeField] private Transform leftScrewPos;
    [SerializeField] private Transform rightScrewPos;
    
    [SerializeField] private GameObject leftScrewObject;  // Reference to left screw GameObject
    [SerializeField] private GameObject rightScrewObject; // Reference to right screw GameObject

    private float fallThresholdY = -10f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        boardManager = GetComponentInParent<BoardManager>();
    }

    void Update()
    {
        if (transform.position.y < fallThresholdY)
        {
            boardManager.PlankRemoved();
            Destroy(gameObject);
        }
    }

    public void ScrewRemoved(bool isLeftScrew)
    {
        if (isLeftScrew)
        {
            hasLeftScrew = false;
            if (leftScrewObject != null)
            {
                Destroy(leftScrewObject);  
                leftScrewObject = null;
            }
        }
        else
        {
            hasRightScrew = false;
            if (rightScrewObject != null)
            {
                Destroy(rightScrewObject);  
                rightScrewObject = null;
            }
        }

        CoinManager.Instance.AddCoins(10);
        
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

    // ✅ Remove one screw when Power Drill is used
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
