using UnityEngine;

public class InventoryItemTest2 : MonoBehaviour
{
    internal int Quantity = 300;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            FarmingPlantItem RadishSeed = ItemManager.GetFarmingPlantItem(1019, Quantity);
            GameManager.Instance.inventory.AddItem(RadishSeed);
            GameManager.Instance.inventoryUI.RefreshInventoryUI();
            Destroy(gameObject);
        }
    }

}