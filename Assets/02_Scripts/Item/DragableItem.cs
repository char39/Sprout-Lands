using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CanvasGroup canvasGroup;
    public Canvas canvas;
    public RectTransform tr;
    public Vector2 originPos;
    public Transform originParentTr;
    public int index;

    public Item item;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        tr = GetComponent<RectTransform>();
        originPos = tr.anchoredPosition;
        originParentTr = transform.parent;
        canvasGroup.blocksRaycasts = true;
        //index = transform.parent.GetSiblingIndex();
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
        if (IsValidDropPosition(eventData) && eventData.pointerEnter.GetComponent<DragableItem>() != null)
        {
            tr.SetParent(eventData.pointerEnter.transform.parent);
            tr.anchoredPosition = eventData.pointerEnter.transform.GetComponent<RectTransform>().anchoredPosition;

            eventData.pointerEnter.transform.SetParent(originParentTr);
            eventData.pointerEnter.transform.GetComponent<RectTransform>().anchoredPosition = originPos;

            int tempIndex = eventData.pointerEnter.GetComponent<DragableItem>().index;
            GameManager.Instance.inventory.ChangeItemIndex(index, tempIndex);
            eventData.pointerEnter.GetComponent<DragableItem>().index = index;
            index = tempIndex;
        }
        else
        {
            tr.SetParent(originParentTr);
            tr.anchoredPosition = originPos;
        }
        canvasGroup.blocksRaycasts = true;
    }

    private bool IsValidDropPosition(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
            return true;
        return false;
    }
}