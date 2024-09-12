using UnityEngine;

public class InventoryItemTest2 : MonoBehaviour
{
    internal int Quantity = 300;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            Item grass = ItemManager.GetToolItem(4, Quantity);
            Debug.Log($"아이템 이름: {grass.Name}, 아이템 개수: {grass.Stack}");
            GameManager.Instance.inventory.AddItem(grass);
            GameManager.Instance.inventoryUI.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }

}