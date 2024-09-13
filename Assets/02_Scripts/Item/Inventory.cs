using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int InventorySize = 24;
    public List<Item> ListItem = new(24) { };

    public delegate void RefreshInventoryUIDelegate();
    public event RefreshInventoryUIDelegate OnRefreshInventoryUI;

    public List<Item> GetAllItems() => ListItem;

    private int FindExistItemIndex(Item AddItem)
    {
        /*  기존 for문으로 index 찾는 코드
        for (int index = 0; index < ListItem.Count; index++)
        {
            if (index >= InventorySize - 1) break;
            Item i = ListItem[index];
            if (AddItem.ID == i.ID && i.IsStackable)
                return index;
        }
        return -1;
        */
        int index = ListItem.FindIndex(i => AddItem.ID == i.ID && i.IsStackable);
        if (index != -1 && index < InventorySize - 1)
            return index;
        return -1;
        
    }
    private int FindNullItemIndex()
    {
        int index = ListItem.FindIndex(i => i.ID == -1);
        if (index != -1 && index < InventorySize - 1)
            return index;
        return -1;
    }

    public void AddItem(Item AddItem)
    {
        int TotalStack;
        int RemainStack;
        int exListIndex = FindExistItemIndex(AddItem);
        int nullListIndex = FindNullItemIndex();
        if (exListIndex != -1)
        {
            TotalStack = ListItem[exListIndex].Stack + AddItem.Stack;
            if (TotalStack > AddItem.MaxStack)
            {
                Item RemainItem = ListItem[exListIndex];
                RemainItem.SetStack(RemainItem.MaxStack);
                ListItem.RemoveAt(exListIndex);
                ListItem.Insert(exListIndex, RemainItem);
                RemainStack = TotalStack - ListItem[exListIndex].MaxStack;
                this.AddItem(new Item(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable));
            }
            else
            {
                Item RemainItem = ListItem[exListIndex];
                ListItem.RemoveAt(exListIndex);
                ListItem.Insert(exListIndex, new Item(RemainItem.Icon, RemainItem.ID, RemainItem.Name, RemainItem.Stack + AddItem.Stack, RemainItem.MaxStack, RemainItem.IsConsumable));
            }
        }
        else
        {
            if (AddItem.Stack > AddItem.MaxStack)
            {
                RemainStack = AddItem.Stack - AddItem.MaxStack;
                ListItem.RemoveAt(nullListIndex);
                ListItem.Insert(nullListIndex, new Item(AddItem.Icon, AddItem.ID, AddItem.Name, AddItem.MaxStack, AddItem.MaxStack, AddItem.IsConsumable));
                this.AddItem(new Item(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable));
            }
            else
            {
                ListItem.RemoveAt(nullListIndex);
                ListItem.Insert(nullListIndex, AddItem);
            }
        }
        UpdateItemIndices();
        OnRefreshInventory();
    }
    public void AddItem(ToolItem AddItem)
    {
        int TotalStack;
        int RemainStack;
        int exListIndex = FindExistItemIndex(AddItem);
        int nullListIndex = FindNullItemIndex();
        if (exListIndex != -1)
        {
            TotalStack = ListItem[exListIndex].Stack + AddItem.Stack;
            if (TotalStack > AddItem.MaxStack)
            {
                ToolItem RemainItem = (ToolItem)ListItem[exListIndex];
                RemainItem.SetStack(RemainItem.MaxStack);
                ListItem.RemoveAt(exListIndex);
                ListItem.Insert(exListIndex, RemainItem);
                RemainStack = TotalStack - ListItem[exListIndex].MaxStack;
                this.AddItem(new ToolItem(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable, RemainItem.Durability, RemainItem.MaxDurability));
            }
            else
            {
                ToolItem RemainItem = (ToolItem)ListItem[exListIndex];
                ListItem.RemoveAt(exListIndex);
                ListItem.Insert(exListIndex, new ToolItem(RemainItem.Icon, RemainItem.ID, RemainItem.Name, RemainItem.Stack + AddItem.Stack, RemainItem.MaxStack, RemainItem.IsConsumable, RemainItem.Durability, RemainItem.MaxDurability));
            }
        }
        else
        {
            if (AddItem.Stack > AddItem.MaxStack)
            {
                RemainStack = AddItem.Stack - AddItem.MaxStack;
                ListItem.RemoveAt(nullListIndex);
                ListItem.Insert(nullListIndex, new ToolItem(AddItem.Icon, AddItem.ID, AddItem.Name, AddItem.MaxStack, AddItem.MaxStack, AddItem.IsConsumable, AddItem.Durability, AddItem.MaxDurability));
                this.AddItem(new ToolItem(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable, AddItem.Durability, AddItem.MaxDurability));
            }
            else
            {
                ListItem.RemoveAt(nullListIndex);
                ListItem.Insert(nullListIndex, AddItem);
            }
        }
        UpdateItemIndices();
        OnRefreshInventory();
    }

    private int FindExistItemIndexForRemove(Item RemoveItem)
    {
        int index = ListItem.FindLastIndex(i => RemoveItem.ID == i.ID);
        if (index != -1 && index < InventorySize - 1)
            return index;
        return -1;
    }
    public void RemoveItem(Item RemoveItem, int Quantity = 1)
    {
        int RemainQuantity;
        int existListIndex = FindExistItemIndexForRemove(RemoveItem);
        if (existListIndex != -1)
        {
            Item ExistItem = null;
            ToolItem ExistToolItem = null;
            if (ListItem[existListIndex] is ToolItem)
                ExistToolItem = (ToolItem)ListItem[existListIndex];
            else
                ExistItem = ListItem[existListIndex];

            if ((ExistItem != null && Quantity >= ExistItem.Stack) || (ExistToolItem != null && Quantity >= ExistToolItem.Stack))
            {
                RemainQuantity = (ExistToolItem != null) ? Quantity - ExistToolItem.Stack : Quantity - ExistItem.Stack;
                ListItem.RemoveAt(existListIndex);
                ListItem.Insert(existListIndex, new Item(null, -1, "null", 0, 0, false));
                if (RemainQuantity > 0)
                    this.RemoveItem(RemoveItem, RemainQuantity);
            }
            else
            {
                RemainQuantity = (ExistToolItem != null) ? ExistToolItem.Stack - Quantity : ExistItem.Stack - Quantity;
                ListItem.RemoveAt(existListIndex);
                if (ExistToolItem != null)
                    ListItem.Insert(existListIndex, new ToolItem(ExistToolItem.Icon, ExistToolItem.ID, ExistToolItem.Name, RemainQuantity, ExistToolItem.MaxStack, ExistToolItem.IsConsumable, ExistToolItem.Durability, ExistToolItem.MaxDurability));
                else
                    ListItem.Insert(existListIndex, new Item(ExistItem.Icon, ExistItem.ID, ExistItem.Name, RemainQuantity, ExistItem.MaxStack, ExistItem.IsConsumable));
            }
        }
        UpdateItemIndices();
        OnRefreshInventory();
    }

    public void UpdateItemIndices()
    {
        for (int i = 0; i < ListItem.Count; i++)
            ListItem[i].SetIndex(i);
    }

    public void ChangeItemIndex(int Index1, int Index2)
    {
        if (Index1 < 0 || Index1 >= ListItem.Count || Index2 < 0 || Index2 >= ListItem.Count)
            return;
        Item item1 = ListItem[Index1];
        Item item2 = ListItem[Index2];
        if (item1.ID == item2.ID && (item1.IsStackable || item2.IsStackable))
        {
            int totalStack = item1.Stack + item2.Stack;
            int maxStack = item1.MaxStack;

            if (totalStack <= maxStack)
            {
                item2.SetStack(totalStack);
                ListItem.RemoveAt(Index1);
            }
            else
            {
                item2.SetStack(maxStack);
                item1.SetStack(totalStack - maxStack);
                ListItem[Index1] = item1;
            }
        }
        else
        {
            ListItem.RemoveAt(Index1);
            ListItem.Insert(Index1, item2);
            ListItem.RemoveAt(Index2);
            ListItem.Insert(Index2, item1);
        }
        UpdateItemIndices();
        OnRefreshInventory();
    }

    protected virtual void OnRefreshInventory()
    {
        OnRefreshInventoryUI?.Invoke();
    }
}