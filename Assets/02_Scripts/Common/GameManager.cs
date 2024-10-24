using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static GM_CameraSetting CameraSetting;
    public static GM_GameTimeRule GameTimeRule;
    public static GM_DateInfo DateInfo;
    public static GM_DateInfoUI DateInfoUI;
    public static GM_MousePosition MousePos;
    public static GM_QuickSlotSelect SlotSelect;
    public static Inventory Inventory;
    public static InventoryUI InventoryUI;

    void Awake()
    {
        Instance = this;
        AddComponent();
    }

    private void AddComponent()
    {
        CameraSetting = gameObject.AddComponent<GM_CameraSetting>();
        GameTimeRule = gameObject.AddComponent<GM_GameTimeRule>();
        DateInfo = gameObject.AddComponent<GM_DateInfo>();
        DateInfoUI = gameObject.AddComponent<GM_DateInfoUI>();
        MousePos = gameObject.AddComponent<GM_MousePosition>();
        SlotSelect = gameObject.AddComponent<GM_QuickSlotSelect>();
        Inventory = gameObject.AddComponent<Inventory>();
        InventoryUI = gameObject.AddComponent<InventoryUI>();
    }

    void Start()
    {
        CameraSetting.MainCam = Camera.main.transform;
    }

    void Update()
    {
        CameraSetting.ResetCameraPosLimit();
        CameraSetting.CameraFollow();

        if (Input.GetKeyDown(KeyCode.R))    // 아이템 삭제 테스트용 추후 삭제
            Inventory.RemoveItem(ItemManager.GetToolItem(4), 5);
    }
}
