using UnityEngine;

public class InventoryItemTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            ToolItem axe = ItemManager.GetToolItem(2, 1);
            GameManager.Instance.inventory.AddItem(axe);
            ToolItem hoe = ItemManager.GetToolItem(3, 1);
            GameManager.Instance.inventory.AddItem(hoe);
            ToolItem water = ItemManager.GetToolItem(1, 1);
            GameManager.Instance.inventory.AddItem(water);
            
            GameManager.Instance.inventoryUI.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }

}