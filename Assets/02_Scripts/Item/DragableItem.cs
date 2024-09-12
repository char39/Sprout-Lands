using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CanvasGroup canvasGroup;
    public Canvas canvas;
    public RectTransform tr;
    public Vector2 originPos;
    public Transform originParentTr;
    public int siblingIndex;

    public Item item;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        tr = GetComponent<RectTransform>();
        originPos = tr.anchoredPosition;
        originParentTr = transform.parent;
        canvasGroup.blocksRaycasts = true;
        siblingIndex = transform.parent.GetSiblingIndex();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originPos = tr.anchoredPosition;
        originParentTr = transform.parent;
        tr.SetParent(GameManager.Instance.inventoryUI.TempItem);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        tr.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsInvalidDropPosition(eventData))
        {
            if (eventData.pointerEnter.GetComponent<DragableItem>() != null)
            {
                tr.SetParent(eventData.pointerEnter.transform.parent);
                tr.anchoredPosition = eventData.pointerEnter.transform.GetComponent<RectTransform>().anchoredPosition;
            
                eventData.pointerEnter.transform.SetParent(originParentTr);
                eventData.pointerEnter.transform.GetComponent<RectTransform>().anchoredPosition = originPos;

                int tempSiblingIndex = eventData.pointerEnter.GetComponent<DragableItem>().siblingIndex;
                GameManager.Instance.inventory.ChangeItemIndex(siblingIndex, tempSiblingIndex);
                eventData.pointerEnter.GetComponent<DragableItem>().siblingIndex = siblingIndex;
                siblingIndex = tempSiblingIndex;
            }
            else
            {
                tr.SetParent(originParentTr);
                tr.anchoredPosition = originPos;
            }
        }
        canvasGroup.blocksRaycasts = true;
    }

    private bool IsInvalidDropPosition(PointerEventData eventData)
    {
        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<SlotDrop>() == null)
            return true;
        return false;
    }
}
