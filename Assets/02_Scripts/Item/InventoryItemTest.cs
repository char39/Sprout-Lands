using UnityEngine;

public class InventoryItemTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            FruitItem strawberry = ItemManager.GetFruitItem(5, 200);
            GameManager.Instance.inventory.AddItem(strawberry);
            GameManager.Instance.inventoryUI.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }
}
