using UnityEngine;

public class DataManage : MonoBehaviour
{
    public Player player;
    public Inventory inven;
    public GM_DateInfo dateInfo;
    public GM_QuickSlotSelect slotSelect;

    void Awake()
    {
        inven = gameObject.AddComponent<Inventory>();
        dateInfo = gameObject.AddComponent<GM_DateInfo>();
        slotSelect = gameObject.AddComponent<GM_QuickSlotSelect>();
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
}