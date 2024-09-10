using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform InvenSlot_Group;
    public GameObject SlotPref;
    public GameObject ItemPref;

    void Start()
    {
        inventory = GameManager.Instance.inventory;
        inventory.OnRefreshInventoryUI += RefreshInventoryUI;
        InvenSlot_Group = GameObject.Find("InventorySlot_Group").transform;
        SlotPref = Resources.Load<GameObject>("Item/ItemSlot");
        ItemPref = Resources.Load<GameObject>("Item/GameItem");
        RefreshInventoryUI();
    }

    public void RefreshInventoryUI()
    {
        List<Item> items = inventory.GetAllItems();
        int itemCount = items.Count;    // 지금은 인벤토리 스크립트에서 아이템 개수를 가져오지만, 나중엔 여기에 인벤토리 개수를 작성할 예정.

        for (int i = InvenSlot_Group.childCount; i < itemCount; i++)
        {
            var slot = Instantiate(SlotPref, InvenSlot_Group);
            slot.name = "Slot (" + (i + 1) + ")";
        }

        for (int i = 0; i < InvenSlot_Group.childCount; i++)        // 인벤토리 슬롯 개수만큼 반복
        {
            Transform slot = InvenSlot_Group.GetChild(i);               // i번째 슬롯을 가져옴
            if (i < itemCount)                                          // i가 아이템 개수보다 작으면
            {
                Item item = items[i];                                       // i번째 아이템을 가져옴
                GameObject itemObj;                                         // 아이템 오브젝트를 담을 변수

                if (slot.childCount == 0)                                   // 슬롯에 아이템이 없으면
                    itemObj = Instantiate(ItemPref, slot);                      // 아이템을 생성
                else                                                        // 슬롯에 아이템이 있으면
                    itemObj = slot.GetChild(0).gameObject;                      // 아이템 오브젝트를 가져옴

                itemObj.GetComponent<Image>().sprite = item.Icon;
                itemObj.name = item.Name;
                itemObj.GetComponentsInChildren<Text>()[0].text = item.Stack.ToString();
                itemObj.SetActive(true);
            }
            else                                                        // i가 아이템 개수보다 크거나 같으면
                if (slot.childCount > 0)                                    // 슬롯에 아이템이 있으면
                    slot.GetChild(0).gameObject.SetActive(false);               // 아이템 오브젝트를 비활성화
        }
    }


}
