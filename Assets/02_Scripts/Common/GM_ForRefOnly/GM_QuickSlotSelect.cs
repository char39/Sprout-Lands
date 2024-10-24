using UnityEngine;

public class GM_QuickSlotSelect : MonoBehaviour
{
    public enum SelectedSlotIndex { Slot1 = 1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8 }
    public SelectedSlotIndex slotPos = SelectedSlotIndex.Slot1;

    [HideInInspector] public Transform Slot_Select;

    void Update()
    {
        GetMouseScroll();
        SetQuickSlotPosition();
        ApplySlotPosition();
    }

    public void SetQuickSlotPosition()
    {
        int slotNum = GetKeyNum();
        slotPos = slotNum != 0 ? (SelectedSlotIndex)slotNum : slotPos;
    }

    private int GetKeyNum()
    {
        for (int i = 1; i <= 8; i++)
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + i)))
                return i;
        return 0;
    }

    private void GetMouseScroll()
    {
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        float scrollValue = scroll > 0 ? 1 : scroll < 0 ? -1 : 0;

        if (scrollValue > 0)
            slotPos = slotPos == SelectedSlotIndex.Slot1 ? SelectedSlotIndex.Slot8 : slotPos - 1;
        else if (scrollValue < 0)
            slotPos = slotPos == SelectedSlotIndex.Slot8 ? SelectedSlotIndex.Slot1 : slotPos + 1;
    }

    private void ApplySlotPosition()
    {
        Transform invenQuickSlotGroupTr = GameManager.InventoryUI.QuickSlot_Group;
        if (invenQuickSlotGroupTr == null || Slot_Select == null)
            return;

        Vector2 QuickSlotPos = invenQuickSlotGroupTr.GetChild((int)slotPos - 1).position;

        Slot_Select.position = (Vector2)Slot_Select.position != QuickSlotPos ? QuickSlotPos : Slot_Select.position;
    }
}
