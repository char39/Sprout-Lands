using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public Player player;
    public Lights_Global light_Global;
    public Inventory inventory;
    public InventoryUI inventoryUI;
    public GM_CameraSetting cameraSetting;
    public GM_GameTimeRule gameTimeRule;
    public GM_DateInfo dateInfo;
    public GM_DateInfoUI dateInfoUI;
    public GM_MousePosition mousePos;
    public GM_QuickSlotSelect slotSelect;

    void Awake()
    {
        GM = this;
        AddComponent();
    }

    private void AddComponent()
    {
        inventory = gameObject.GetComponent<Inventory>();
        inventoryUI = gameObject.GetComponent<InventoryUI>();
        cameraSetting = gameObject.AddComponent<GM_CameraSetting>();
        gameTimeRule = gameObject.AddComponent<GM_GameTimeRule>();
        dateInfo = gameObject.AddComponent<GM_DateInfo>();
        dateInfoUI = gameObject.AddComponent<GM_DateInfoUI>();
        mousePos = gameObject.AddComponent<GM_MousePosition>();
        slotSelect = gameObject.AddComponent<GM_QuickSlotSelect>();
    }

    void Start()
    {
        cameraSetting.MainCam = Camera.main.transform;
        player = FindObjectOfType<Player>();
        light_Global = FindObjectOfType<Lights_Global>();
    }

    void LateUpdate()
    {
        cameraSetting.ResetCameraPosLimit();
        cameraSetting.CameraFollow();

        if (inventoryUI.Inventory_Frame != null)
            inventoryUI.Inventory_Frame.localScale = new Vector3(0.675f * cameraSetting.UI_Scale, 0.675f * cameraSetting.UI_Scale, 1);
        if (dateInfo.DateInfo_Frame != null)
            dateInfo.DateInfo_Frame.localScale = new Vector3(0.75f * cameraSetting.UI_Scale, 0.75f * cameraSetting.UI_Scale, 1);

        if (Input.GetKeyDown(KeyCode.R))    // 아이템 삭제 테스트용 추후 삭제
            inventory.RemoveItem(ItemManager.GetToolItem(4), 5);
    }
}
