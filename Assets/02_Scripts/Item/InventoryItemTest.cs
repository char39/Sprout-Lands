using System.Collections;
using UnityEngine;

public class InventoryItemTest : MonoBehaviour
{
    internal int Quantity = 150;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            FruitItem strawberry = ItemManager.GetFruitItem(2005, Quantity);
            GameManager.Instance.inventory.AddItem(strawberry); // 이게 되는 이유는 GameManager에 inventory를 추가했기 때문. FruitItem은 Item을 상속받았기 때문에 AddItem이 가능.
            GameManager.Instance.inventoryUI.RefreshInventoryUI();

            Destroy(gameObject);
        }
    }

}