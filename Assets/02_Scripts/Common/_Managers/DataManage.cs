using UnityEngine;

public class DataManage : MonoBehaviour
{
    public Player player;
    public Inventory inven;
    public DateInfo dateInfo;
    public CurrentQuickSlot slotSelect;

    void Awake()
    {
        inven = gameObject.AddComponent<Inventory>();
        dateInfo = gameObject.AddComponent<DateInfo>();
        slotSelect = gameObject.AddComponent<CurrentQuickSlot>();
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
}