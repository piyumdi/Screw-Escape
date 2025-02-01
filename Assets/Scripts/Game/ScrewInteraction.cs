using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrewInteraction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    public PlankController plank;
    public bool isLeftScrew;
    private bool isRemoved = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!isRemoved)
        {
            RemoveScrew();
        }
    }

    void RemoveScrew()
    {
        isRemoved = true;
        if (plank != null)
        {
            plank.ScrewRemoved(isLeftScrew);
        }
        gameObject.SetActive(false); // Hide screw after removal
    }
}
