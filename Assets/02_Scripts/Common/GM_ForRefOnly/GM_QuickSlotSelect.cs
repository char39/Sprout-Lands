using UnityEngine;

public class GM_QuickSlotSelect : MonoBehaviour
{
    public enum SelectedSlotIndex { Slot1 = 1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8 }
    public SelectedSlotIndex slotPos = SelectedSlotIndex.Slot1;
    private SelectedSlotIndex slotPosPrev = SelectedSlotIndex.Slot1;

    [HideInInspector] public Transform Slot_Select;

    void Update()
    {
        GetMouseScroll();
        SetQuickSlotPosition();
    }

    void LateUpdate()
    {
        RefreshSlotPosition();
    }

    public void ApplySlotPosition()
    {
        Transform QSlotGroup = GameManager.GM.InventoryUI.QuickSlot_Group;
        if (QSlotGroup == null || Slot_Select == null)
            return;

        Vector2 QuickSlotPos = QSlotGroup.GetChild((int)slotPos - 1).position;

        Slot_Select.position = (Vector2)Slot_Select.position != QuickSlotPos ? QuickSlotPos : Slot_Select.position;
    }

    private void RefreshSlotPosition()
    {
        if (slotPosPrev != slotPos)
        {
            ApplySlotPosition();
            slotPosPrev = slotPos;
        }
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

    private int GetKeyNum()
    {
        for (int i = 1; i <= 8; i++)
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + i)))
                return i;
        return 0;
    }

    public void SetQuickSlotPosition()
    {
        int slotNum = GetKeyNum();

        if (slotNum != 0)
            slotPos = (SelectedSlotIndex)slotNum;
    }
}
