using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> ListItem = new();

    public delegate void RefreshInventoryUIDelegate();
    public event RefreshInventoryUIDelegate OnRefreshInventoryUI;

    public List<Item> GetAllItems() => ListItem;


    /// <summary> 인벤토리에 있는 아이템들을 순회하며 중첩 가능한 아이템이 존재하면 해당 아이템의 인덱스를 반환. </summary>
    private int FindExistItemIndex(Item AddItem)
    {
        for (int index = 0; index < ListItem.Count; index++)
        {
            Item i = ListItem[index];
            if (AddItem.ID == i.ID && i.IsStackable)
                return index;
        }
        return -1;
    }

    public void AddItem(Item AddItem)
    {
        UpdateItemIndices();
        int TotalStack;
        int RemainStack;
        int ExistIndex = FindExistItemIndex(AddItem);

        if (ExistIndex != -1)                              // 인벤에 추가하려는 아이템이 존재하며 그 아이템이 현재 중첩가능한 상태인경우
        {
            TotalStack = ListItem[ExistIndex].Stack + AddItem.Stack;       // 기존 아이템과 추가하려는 아이템을 합한 개수
            if (TotalStack > AddItem.MaxStack)                  // 합한 개수가 최대개수를 초과한다면
            {
                ListItem[ExistIndex].Stack = ListItem[ExistIndex].MaxStack;               // 기존 아이템의 개수는 최대치로 변경
                RemainStack = TotalStack - ListItem[ExistIndex].MaxStack;      // 합한 개수 - 최대개수
                AddItem.Stack = RemainStack;                        // RemainStack에 저장한뒤
                this.AddItem(new Item(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable));    // RemainStack에 저장한뒤 추가
                return;
            }
            else                                                // 합한 개수가 최대개수를 초과하지 않는다면
            {
                ListItem[ExistIndex].Stack += AddItem.Stack;                   // 기존 아이템의 개수에 추가하려는 아이템 개수를 더함.
                UpdateItemIndices();
            }
        }
        else                                                // 인벤에 추가하려는 아이템이 존재하지 않는경우
        {
            if (AddItem.Stack > AddItem.MaxStack)               // 추가하려는 아이템의 개수가 최대개수를 초과한다면
            {
                RemainStack = AddItem.Stack - AddItem.MaxStack;     // 추가하려는 아이템 개수 - 최대개수
                ListItem.Add(new Item(AddItem.Icon, AddItem.ID, AddItem.Name, AddItem.MaxStack, AddItem.MaxStack, AddItem.IsConsumable));  // 최대개수로(아이템 생성)
                this.AddItem(new Item(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable));    // RemainStack에 저장한뒤 추가
                return;
            }
            else
            {
                ListItem.Add(AddItem);                                 // 해당개수로(아이템 생성)
                UpdateItemIndices();
            }
        }
    }

    //  while문
    //      인벤에 추가하려는 아이템이 존재하며 그 아이템이 현재 중첩가능한 상태인경우
    //          기존 아이템이 존재한다면
    //              기존 아이템과 추가하려는 아이템을 합한 개수가 최대개수를 초과한다면
    //                  기존 아이템의 개수는 최대치로 변경하고
    //                  합한 개수 - 최대개수 를 RemainStack에 저장한뒤
    //                  Continue;
    //              기존 아이템과 추가하려는 아이템을 합한 개수가 최대개수를 초과하지 않는다면
    //                  기존 아이템의 개수에 추가하려는 아이템 개수를 더함.
    //                  break;
    //          기존 아이템이 존재하지 않는다면
    //              추가하려는 아이템의 개수가 최대개수를 초과한다면
    //                  최대개수로(아이템 생성)
    //                  추가하려는 아이템 개수 - 최대개수 를 RemainStack에 저장한뒤
    //                  Continue;
    //              추가하려는 아이템의 개수가 최대개수를 초과하지 않는다면
    //                  해당개수로(아이템 생성)
    //                  break;




/*         public void AddItem(Item AddItem)
        {
            Item ExistItem = FindExistItem(AddItem);

            if (ExistItem != null)
            {
                // 중첩 가능한 아이템. [현재 통과한 조건. 중첩가능, 인벤에 아이템이 존재, 존재하는 아이템이 최대개수보다 작음]
                int totalStack = ExistItem.Stack + AddItem.Stack;
                if (totalStack > ExistItem.MaxStack)
                {
                    ExistItem.Stack = ExistItem.MaxStack;
                    int remainingStack = totalStack - ExistItem.MaxStack;
                    AddItem.Stack = remainingStack;
                    UpdateItemIndices();
                    OnRefreshInventory();

                    this.AddItem(AddItem);
                }
                else
                    ExistItem.Stack = totalStack;
            }
            else if (ExistItem == null)
            {
                // [현재 통과한 조건. 중첩불가능, 인벤에 아이템이 존재하지 않음]
                if (AddItem.Stack > AddItem.MaxStack)
                {
                    int remainingStack = AddItem.Stack - AddItem.MaxStack;
                    AddItem.Stack = AddItem.MaxStack;
                    Items.Add(AddItem);
                    UpdateItemIndices();
                    OnRefreshInventory();

                    this.AddItem(AddItem);
                }
                else
                    Items.Add(AddItem);
            }
            UpdateItemIndices();
            OnRefreshInventory();
        } */

















    public void RemoveItem(Item item, int Quantity = 1)
    {
        Item existItem = ListItem.Find(i => i.ID == item.ID);
        if (existItem != null)
        {
            if (Quantity >= existItem.Stack)
            {
                int remainingQuantity = Quantity - existItem.Stack;
                ListItem.Remove(existItem);
                UpdateItemIndices();
                if (remainingQuantity > 0)
                    RemoveItem(item, remainingQuantity);
            }
            else
            {
                existItem.Stack -= Quantity;
                if (existItem.Stack <= 0)
                    ListItem.Remove(existItem);
                UpdateItemIndices();
            }
        }
        else
            return;
    }

    public void UpdateItemIndices()
    {
        for (int i = 0; i < ListItem.Count; i++)
            ListItem[i].Index = i;
    }

    public void MoveItem(int oldIndex, int newIndex)
    {
        if (oldIndex < 0 || oldIndex >= ListItem.Count || newIndex < 0 || newIndex >= ListItem.Count)
            return;
        Item item = ListItem[oldIndex];
        ListItem.RemoveAt(oldIndex);
        ListItem.Insert(newIndex, item);
        UpdateItemIndices();
    }

    protected virtual void OnRefreshInventory()
    {
        OnRefreshInventoryUI?.Invoke();
    }
}