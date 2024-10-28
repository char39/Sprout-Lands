using UnityEngine;

public class Item_Droped : MonoBehaviour
{
    private SpriteRenderer sr;
    public Item item;
    public int ID = -1;
    public int Stack = 0;

    public void SetItem(Item item)
    {
        this.item = item;
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            if (ID == -1 || Stack == 0)
                return;
            Item item = ItemManager.GetItem(ID, Stack);
            GameManager.GM.Inventory.AddItem(item);
            GameManager.GM.InventoryUI.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }
}