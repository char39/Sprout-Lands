using UnityEngine;

public class Item_Droped : MonoBehaviour
{
    private SpriteRenderer sr;
    public Item item;
    public int ID = -1;
    public int Stack = 0;
    private bool isUpdated = false;

    public void SetItem(Item item)
    {
        this.item = item;
        isUpdated = true;
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
            if (isUpdated)
                GameManager.GM.inventory.AddItem(this.item);
            else
                GameManager.GM.inventory.AddItem(item);
            GameManager.GM.inventoryUI.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }
}