using UnityEngine;

public class InventoryItemTest : MonoBehaviour
{
    internal int Quantity = 3;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            ToolItem axe = ItemManager.GetToolItem(2, Quantity);
            GameManager.Instance.inventory.AddItem(axe);
            GameManager.Instance.inventoryUI.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }

}