using UnityEngine;

public class Item_Droped : MonoBehaviour
{
    private SpriteRenderer sr;
    public Item item;
    public int ID = -1;
    public int Stack = 0;
    private bool isUpdated = false;

    internal float waitTime = 0f;
    internal bool CanTrigger { get { return waitTime <= 0f; } }

    void Update()
    {
        if (!CanTrigger)
            waitTime -= Time.deltaTime;
    }

    public void SetItem(Item item, float waitTime = 0.25f)
    {
        this.item = item;
        isUpdated = true;
        this.waitTime = waitTime;
        UpdateItemInfo();
    }

    public void UpdateItemInfo()
    {
        TryGetComponent(out sr);
        if (item != null && sr != null)
        {
            ID = item.ID;
            Stack = item.Stack;
            sr.sprite = item.Icon;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player) && CanTrigger)
        {
            if (ID == -1 || Stack == 0)
                return;
            Item item = ItemManager.GetItem(ID, Stack);
            if (isUpdated)
                GM.DATA.inven.AddItem(this.item);
            else
                GM.DATA.inven.AddItem(item);
            GM.UI.inven.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }
}