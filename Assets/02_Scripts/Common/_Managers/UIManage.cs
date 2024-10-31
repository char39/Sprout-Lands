using UnityEngine;

public class UIManage : MonoBehaviour
{
    public InventoryUI inven;
    public GM_DateInfoUI dateInfoUI;
    public GM_MousePosition mousePos;

    void Awake()
    {
        inven = gameObject.AddComponent<InventoryUI>();
        dateInfoUI = gameObject.AddComponent<GM_DateInfoUI>();
        mousePos = gameObject.AddComponent<GM_MousePosition>();
    }

    void LateUpdate()
    {
        if (inven.Inventory_Frame != null)
            inven.Inventory_Frame.localScale = new Vector3(0.675f * GM.SETTING.camSet.UI_Scale, 0.675f * GM.SETTING.camSet.UI_Scale, 1);
        if (GM.DATA.dateInfo.DateInfo_Frame != null)
            GM.DATA.dateInfo.DateInfo_Frame.localScale = new Vector3(0.75f * GM.SETTING.camSet.UI_Scale, 0.75f * GM.SETTING.camSet.UI_Scale, 1);
    }
}
