using UnityEngine;

public class InventoryItemTest : MonoBehaviour
{
    internal int Quantity = 300;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            Item strawberry = ItemManager.GetFruitItem(2005, Quantity);
            Debug.Log($"아이템 이름: {strawberry.Name}, 아이템 개수: {strawberry.Stack}");
            GameManager.Instance.inventory.AddItem(strawberry);
            GameManager.Instance.inventoryUI.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }

}