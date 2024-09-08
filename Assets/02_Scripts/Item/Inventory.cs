using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new();
    public List<Item> Items
    {
        get { return items; }
        private set { items = value; }
    }

    public List<Item> GetAllItems() => Items;

    public void AddItem(Item item)
    {
        Item existItem = items.Find(i => i.ID == item.ID);
        if (existItem != null && existItem.IsStackable)
        {
            int totalStack = existItem.Stack + item.Stack;
            if (totalStack > existItem.MaxStack)
            {
                existItem.Stack = existItem.MaxStack;
                int remainingStack = totalStack - existItem.MaxStack;
                if (item is ToolItem)
                    AddItem(new ToolItem(item.Icon, item.ID, item.Name, remainingStack, item.MaxStack, item.IsStackable));
                else if (item is FarmingPlantItem)
                    AddItem(new FarmingPlantItem(item.Icon, item.ID, item.Name, remainingStack, item.MaxStack, item.IsStackable));
                else if (item is FruitItem)
                    AddItem(new FruitItem(item.Icon, item.ID, item.Name, remainingStack, item.MaxStack, item.IsStackable));
                else if (item is EggItem)
                    AddItem(new EggItem(item.Icon, item.ID, item.Name, remainingStack, item.MaxStack, item.IsStackable));
                else if (item is MilkItem)
                    AddItem(new MilkItem(item.Icon, item.ID, item.Name, remainingStack, item.MaxStack, item.IsStackable));
            }
            else
                existItem.Stack = totalStack;
        }
        else
            items.Add(item);
        UpdateItemIndices();
    }

    public void RemoveItem(Item item, int Quantity = 1)
    {
        Item existItem = items.Find(i => i.ID == item.ID);
        if (existItem != null)
        {
            if (Quantity >= existItem.Stack)
            {
                int remainingQuantity = Quantity - existItem.Stack;
                items.Remove(existItem);
                UpdateItemIndices();
                if (remainingQuantity > 0)
                    RemoveItem(item, remainingQuantity);
            }
            else
            {
                existItem.Stack -= Quantity;
                if (existItem.Stack <= 0)
                    items.Remove(existItem);
                UpdateItemIndices();
            }
        }
        else
            return;
    }

    public void UpdateItemIndices()
    {
        for (int i = 0; i < Items.Count; i++)
            Items[i].Index = i;
    }

    public void MoveItem(int oldIndex, int newIndex)
    {
        if (oldIndex < 0 || oldIndex >= Items.Count || newIndex < 0 || newIndex >= Items.Count)
            return;
        Item item = Items[oldIndex];
        Items.RemoveAt(oldIndex);
        Items.Insert(newIndex, item);
        UpdateItemIndices();
    }
}