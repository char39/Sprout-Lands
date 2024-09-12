using UnityEngine;

public class InventoryItemTest2 : MonoBehaviour
{
    internal int Quantity = 300;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            ToolItem grass = ItemManager.GetToolItem(4, Quantity);
            GameManager.Instance.inventory.AddItem(grass);
            GameManager.Instance.inventoryUI.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }

}