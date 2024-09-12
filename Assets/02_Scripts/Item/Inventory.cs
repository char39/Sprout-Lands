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
        for (int index = 0; index < ListItem.Count; index++)
        {
            if (index >= InventorySize - 1) break;
            Item i = ListItem[index];
            if (AddItem.ID == i.ID && i.IsStackable)
                return index;
        }
        return -1;
    }
    private int FindNullItemIndex()
    {
        for (int index = 0; index < ListItem.Count; index++)
        {
            if (index >= InventorySize - 1) break;
            Item i = ListItem[index];
            if (i.ID == -1)
                return index;
        }
        return -1;
    }
    // GameManager.Instance.inventory.ListItem.Add(new Item(null, -1, "null", 0, 0, false));
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
                existItem.SetStack(existItem.Stack - Quantity);
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
        {
            ListItem[i].SetIndex(i);
        }
    }

    public void ChangeItemIndex(int oldIndex, int newIndex)
    {
        if (oldIndex < 0 || oldIndex >= ListItem.Count || newIndex < 0 || newIndex >= ListItem.Count)
            return;
        Item Old = ListItem[oldIndex];
        Item New = ListItem[newIndex];
        ListItem.RemoveAt(oldIndex);
        ListItem.Insert(oldIndex, New);
        ListItem.RemoveAt(newIndex);
        ListItem.Insert(newIndex, Old);

        UpdateItemIndices();
        OnRefreshInventory();
    }

    protected virtual void OnRefreshInventory()
    {
        OnRefreshInventoryUI?.Invoke();
    }
}