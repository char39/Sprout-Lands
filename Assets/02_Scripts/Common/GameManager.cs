using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public Player player;
    public GM_CameraSetting CameraSetting;
    public GM_GameTimeRule GameTimeRule;
    public GM_DateInfo DateInfo;
    public GM_DateInfoUI DateInfoUI;
    public GM_MousePosition MousePos;
    public GM_QuickSlotSelect SlotSelect;
    public Inventory Inventory;
    public InventoryUI InventoryUI;

    void Awake()
    {
        GM = this;
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
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        CameraSetting.ResetCameraPosLimit();
        CameraSetting.CameraFollow();

        if (Input.GetKeyDown(KeyCode.R))    // 아이템 삭제 테스트용 추후 삭제
            Inventory.RemoveItem(ItemManager.GetToolItem(4), 5);
    }
}
