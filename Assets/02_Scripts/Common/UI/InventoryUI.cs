using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    // 인벤토리 슬롯 Transform
    public Transform Inventory_Frame;

    public Transform InventorySlot_Frame;
    public Transform InventorySlot_Group;
    public CanvasGroup InvenSlotCanvasGroup;
    public Transform TempItem;

    public Transform QuickSlot_Frame;
    public Transform QuickSlot_Group;

    public GameObject SlotPref;
    public GameObject ItemPref;

    void Start()
    {
        inventory = GameManager.Instance.inventory;
        inventory.OnRefreshInventoryUI += RefreshInventoryUI;
        
        Inventory_Frame = GameObject.Find("UI_Canvas").transform.Find("Inventory_Frame");

        InventorySlot_Frame = Inventory_Frame.Find("InventorySlot_Frame");
        InventorySlot_Group = InventorySlot_Frame.GetChild(0).GetChild(0);
        InvenSlotCanvasGroup = InventorySlot_Frame.GetComponent<CanvasGroup>();
        TempItem = Inventory_Frame.Find("TempItem");

        QuickSlot_Frame = Inventory_Frame.Find("QuickSlot_Frame");
        QuickSlot_Group = QuickSlot_Frame.GetChild(0).GetChild(0);

        SlotPref = Resources.Load<GameObject>("Item/ItemSlot");
        ItemPref = Resources.Load<GameObject>("Item/GameItem");

        InitializeInventory();
        RefreshInventoryUI();
    }

    private void InitializeInventory()
    {
        for (int i = 0; i < 24; i++)
        {
            var slot = Instantiate(SlotPref, InventorySlot_Group);
            slot.name = "ItemSlot (" + (i + 1) + ")";
            slot.AddComponent<SlotDrop>();
            var itemObj = Instantiate(ItemPref, slot.transform);
            itemObj.GetComponent<Image>().sprite = null;
            itemObj.GetComponentsInChildren<Text>()[0].text = "";
            GameManager.Instance.inventory.ListItem.Add(new Item(null, -1, "null", 0, 0, false));
        }
    }

    public void RefreshInventoryUI()
    {
        List<Item> items = inventory.GetAllItems();
        int itemCount = items.Count;    // 지금은 인벤토리 스크립트에서 아이템 개수를 가져오지만, 나중엔 여기에 인벤토리 개수를 작성할 예정.

        for (int i = 0; i < InventorySlot_Group.childCount; i++)        // 인벤토리 슬롯 개수만큼 반복
        {
            Transform slot = InventorySlot_Group.GetChild(i);               // i번째 슬롯을 가져옴
            if (i < itemCount)                                          // i가 아이템 개수보다 작으면
            {
                Item item = items[i];                                       // i번째 아이템을 가져옴
                GameObject itemObj;                                         // 아이템 오브젝트를 담을 변수

                if (slot.childCount == 0)                                   // 슬롯에 아이템이 없으면
                    itemObj = Instantiate(ItemPref, slot);                      // 아이템을 생성
                else                                                        // 슬롯에 아이템이 있으면
                    itemObj = slot.GetChild(0).gameObject;                      // 아이템 오브젝트를 가져옴

                itemObj.transform.GetChild(0).GetComponent<Image>().sprite = item.Icon;
                itemObj.transform.GetChild(0).GetComponent<Image>().color = item.Icon != null ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
                itemObj.GetComponent<DragableItem>().item = item;
                itemObj.name = item.Name;
                itemObj.GetComponentsInChildren<Text>()[0].text = item.Stack != 0 ? item.Stack.ToString() : "";
                itemObj.SetActive(true);
            }
            else                                                        // i가 아이템 개수보다 크거나 같으면
                if (slot.childCount > 0)                                    // 슬롯에 아이템이 있으면
                    slot.GetChild(0).gameObject.SetActive(false);               // 아이템 오브젝트를 비활성화
        }
    }

    public bool IsNowInventoryMove = false;
    public void OnShowInventory()
    {
        bool OnInven = GameManager.Instance.MousePos.IsShowInventory;
        bool OutInven = GameManager.Instance.MousePos.IsShowOutInventory;

        if (OnInven)
            StartCoroutine(SlerpInventoryMove(-500, true));
        else if (OutInven)
            StartCoroutine(SlerpInventoryMove(-925, false));
    }
    private IEnumerator SlerpInventoryMove(float value, bool ShowInven)
    {
        if (IsNowInventoryMove) yield break;
        IsNowInventoryMove = true;
        float duration = 0.7f;
        float elapsed = 0f;
        Vector3 targetPos = new(0, value, 0);

        static bool IsApproximately(float a, float b, float tolerance) => Mathf.Abs(a - b) < tolerance;
        while (!IsApproximately(Inventory_Frame.localPosition.y, value, 0.05f))
        {
            Inventory_Frame.localPosition = Vector3.Slerp(Inventory_Frame.localPosition, targetPos, elapsed / duration);
            if (ShowInven)
                InvenSlotCanvasGroup.alpha = Mathf.Lerp(InvenSlotCanvasGroup.alpha, 1, elapsed / duration);
            else
                InvenSlotCanvasGroup.alpha = Mathf.Lerp(InvenSlotCanvasGroup.alpha, 0, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Inventory_Frame.localPosition = targetPos;
        InvenSlotCanvasGroup.alpha = ShowInven ? 1 : 0;
        IsNowInventoryMove = false;
    }
}
