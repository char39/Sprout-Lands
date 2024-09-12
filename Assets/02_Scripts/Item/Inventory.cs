using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int InventorySize = 24;
    private List<Item> ListItem = new(24) { };

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

    public void AddItem(Item AddItem)
    {
        int TotalStack;
        int RemainStack;
        int ExistIndex = FindExistItemIndex(AddItem);
        Debug.Log(ExistIndex);
        if (ExistIndex != -1)
        {
            TotalStack = ListItem[ExistIndex].Stack + AddItem.Stack;
            if (TotalStack > AddItem.MaxStack)
            {
                Item RemainItem = ListItem[ExistIndex];
                RemainItem.SetStack(RemainItem.MaxStack);
                ListItem.RemoveAt(ExistIndex);
                ListItem.Insert(ExistIndex, RemainItem);
                RemainStack = TotalStack - ListItem[ExistIndex].MaxStack;
                this.AddItem(new Item(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable));
            }
            else
            {
                Item RemainItem = ListItem[ExistIndex];
                ListItem.RemoveAt(ExistIndex);
                ListItem.Insert(ExistIndex, new Item(RemainItem.Icon, RemainItem.ID, RemainItem.Name, RemainItem.Stack + AddItem.Stack, RemainItem.MaxStack, RemainItem.IsConsumable));
            }
        }
        else
        {
            if (AddItem.Stack > AddItem.MaxStack)
            {
                RemainStack = AddItem.Stack - AddItem.MaxStack;
                ListItem.Add(new Item(AddItem.Icon, AddItem.ID, AddItem.Name, AddItem.MaxStack, AddItem.MaxStack, AddItem.IsConsumable));
                this.AddItem(new Item(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable));
            }
            else
                ListItem.Add(AddItem);
        }
        UpdateItemIndices();
        OnRefreshInventory();
    }

    public void AddItem(ToolItem AddItem)
    {
        int TotalStack;
        int RemainStack;
        int ExistIndex = FindExistItemIndex(AddItem);
        Debug.Log(ExistIndex);
        if (ExistIndex != -1)
        {
            TotalStack = ListItem[ExistIndex].Stack + AddItem.Stack;
            if (TotalStack > AddItem.MaxStack)
            {
                ToolItem RemainItem = (ToolItem)ListItem[ExistIndex];
                RemainItem.SetStack(RemainItem.MaxStack);
                ListItem.RemoveAt(ExistIndex);
                ListItem.Insert(ExistIndex, RemainItem);
                RemainStack = TotalStack - ListItem[ExistIndex].MaxStack;
                this.AddItem(new ToolItem(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable, RemainItem.Durability, RemainItem.MaxDurability));
            }
            else
            {
                ToolItem RemainItem = (ToolItem)ListItem[ExistIndex];
                ListItem.RemoveAt(ExistIndex);
                ListItem.Insert(ExistIndex, new ToolItem(RemainItem.Icon, RemainItem.ID, RemainItem.Name, RemainItem.Stack + AddItem.Stack, RemainItem.MaxStack, RemainItem.IsConsumable, RemainItem.Durability, RemainItem.MaxDurability));
            }
        }
        else
        {
            if (AddItem.Stack > AddItem.MaxStack)
            {
                RemainStack = AddItem.Stack - AddItem.MaxStack;
                ListItem.Add(new ToolItem(AddItem.Icon, AddItem.ID, AddItem.Name, AddItem.MaxStack, AddItem.MaxStack, AddItem.IsConsumable, AddItem.Durability, AddItem.MaxDurability));
                this.AddItem(new ToolItem(AddItem.Icon, AddItem.ID, AddItem.Name, RemainStack, AddItem.MaxStack, AddItem.IsConsumable, AddItem.Durability, AddItem.MaxDurability));
            }
            else
                ListItem.Add(AddItem);
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
            ListItem[i].SetIndex(i);
    }

    public void MoveItem(int oldIndex, int newIndex)
    {
        if (oldIndex < 0 || oldIndex >= ListItem.Count || newIndex < 0 || newIndex >= ListItem.Count)
            return;
        Item item = ListItem[oldIndex];
        ListItem.RemoveAt(oldIndex);
        ListItem.Insert(newIndex, item);
        UpdateItemIndices();
        OnRefreshInventory();
    }

    protected virtual void OnRefreshInventory()
    {
        OnRefreshInventoryUI?.Invoke();
    }
}