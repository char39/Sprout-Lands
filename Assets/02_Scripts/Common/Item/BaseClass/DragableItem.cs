using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Item item;

    public CanvasGroup canvasGroup;
    public Canvas canvas;
    public RectTransform tr;
    public Vector2 originPos;
    public Transform originParentTr;
    public int index;
    private bool IsDragable = false;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        tr = GetComponent<RectTransform>();
        originPos = tr.anchoredPosition;
        originParentTr = transform.parent;
        canvasGroup.blocksRaycasts = true;

        Invoke(nameof(SetIndex), 0.1f);
    }

    private void SetIndex()
    {
        item.SetIndex(index);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (index + 1 > 8 && !IsDragable)
            return;
        GameManager.GM.slotSelect.slotPos = (GM_QuickSlotSelect.SelectedSlotIndex)index + 1;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        IsDragable = true;
        originPos = tr.anchoredPosition;
        originParentTr = transform.parent;
        tr.SetParent(GameManager.GM.inventoryUI.TempItem);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsDragable)
            tr.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsValidDropPosition(eventData) && eventData.pointerEnter.GetComponent<DragableItem>() != null)
        {
            if (item.ID == -1)
            {
                tr.SetParent(originParentTr);
                tr.anchoredPosition = originPos;
                goto EndDrag;
                // 시험삼아 goto문을 사용함. 이렇게 사용하는 것은 좋지 않지만, 이 경우에는 사용해도 크게 문제가 없다고 판단했음.
                // 대체제로 return 대신 아래의 코드를 else문에 넣을 수도 있음.
            }
            tr.SetParent(eventData.pointerEnter.transform.parent);
            tr.anchoredPosition = eventData.pointerEnter.transform.GetComponent<RectTransform>().anchoredPosition;

            eventData.pointerEnter.transform.SetParent(originParentTr);
            eventData.pointerEnter.transform.GetComponent<RectTransform>().anchoredPosition = originPos;

            int tempIndex = eventData.pointerEnter.GetComponent<DragableItem>().index;
            GameManager.GM.inventory.ChangeItemIndex(index, tempIndex);
            eventData.pointerEnter.GetComponent<DragableItem>().index = index;
            index = tempIndex;
        }
        else
        {
            tr.SetParent(originParentTr);
            tr.anchoredPosition = originPos;
        }
    EndDrag:
        canvasGroup.blocksRaycasts = true;
        IsDragable = false;
        SetIndex();
    }

    private bool IsValidDropPosition(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
            return true;
        return false;
    }
}
