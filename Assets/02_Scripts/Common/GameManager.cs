using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GM_CameraSetting CameraSetting;
    public GM_GameTimeRule gameTimeRule;
    public GM_DateInfo DateInfo;
    public GM_DateInfoUI DateInfoUI;
    public GM_MousePosition MousePos;
    public GM_QuickSlotSelect SlotSelect;
    public Inventory inventory;
    public InventoryUI inventoryUI;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        AddComponent();
    }

    private void AddComponent()
    {
        CameraSetting = gameObject.AddComponent<GM_CameraSetting>();
        gameTimeRule = gameObject.AddComponent<GM_GameTimeRule>();
        DateInfo = gameObject.AddComponent<GM_DateInfo>();
        DateInfoUI = gameObject.AddComponent<GM_DateInfoUI>();
        MousePos = gameObject.AddComponent<GM_MousePosition>();
        SlotSelect = gameObject.AddComponent<GM_QuickSlotSelect>();
        inventory = gameObject.AddComponent<Inventory>();
        inventoryUI = gameObject.AddComponent<InventoryUI>();
    }

    void Start()
    {
        CameraSetting.MainCam = Camera.main.transform;
        var dummy = ItemManager.toolItem;    // 아이템 매니저 생성자를 호출하기 위함.
    }

    void Update()
    {
        CameraSetting.ResetCameraPosLimit();
        CameraSetting.CameraFollow();

        if (Input.GetKeyDown(KeyCode.R))    // 아이템 삭제 테스트용 추후 삭제
            inventory.RemoveItem(ItemManager.GetToolItem(4), 5);
    }
}
