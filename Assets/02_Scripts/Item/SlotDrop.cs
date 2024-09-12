using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragableItem draggableItem = eventData.pointerDrag.GetComponent<DragableItem>();
        if (draggableItem != null)
        {
            draggableItem.transform.SetParent(transform);
            draggableItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}
