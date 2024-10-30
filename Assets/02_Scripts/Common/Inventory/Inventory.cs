using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public int InventorySize = 32;
    public List<Item> ListItem = new(32) { };

    public delegate void RefreshInventoryUIDelegate();
    public event RefreshInventoryUIDelegate OnRefreshInventoryUI;

    public List<Item> GetAllItems() => ListItem;

    private int FindExistItemIndex(Item AddItem)
    {
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

                switch (AddItem)
                {
                    case ToolItem toolItem:
                        this.AddItem(NewItem(toolItem, RemainStack));
                        break;
                    case FarmingPlantItem farmingPlantItem:
                        this.AddItem(NewItem(farmingPlantItem, RemainStack));
                        break;
                    case FruitItem fruitItem:
                        this.AddItem(NewItem(fruitItem, RemainStack));
                        break;
                    case EggItem eggItem:
                        this.AddItem(NewItem(eggItem, RemainStack));
                        break;
                    case MilkItem milkItem:
                        this.AddItem(NewItem(milkItem, RemainStack));
                        break;
                }
            }
            else
            {
                Item RemainItem = ListItem[exListIndex];
                ListItem.RemoveAt(exListIndex);

                switch (RemainItem)
                {
                    case ToolItem toolItem:
                        ListItem.Insert(exListIndex, NewItem(toolItem, RemainItem.Stack + AddItem.Stack));
                        break;
                    case FarmingPlantItem farmingPlantItem:
                        ListItem.Insert(exListIndex, NewItem(farmingPlantItem, RemainItem.Stack + AddItem.Stack));
                        break;
                    case FruitItem fruitItem:
                        ListItem.Insert(exListIndex, NewItem(fruitItem, RemainItem.Stack + AddItem.Stack));
                        break;
                    case EggItem eggItem:
                        ListItem.Insert(exListIndex, NewItem(eggItem, RemainItem.Stack + AddItem.Stack));
                        break;
                    case MilkItem milkItem:
                        ListItem.Insert(exListIndex, NewItem(milkItem, RemainItem.Stack + AddItem.Stack));
                        break;
                }
            }
        }
        else
        {
            if (AddItem.Stack > AddItem.MaxStack)
            {
                RemainStack = AddItem.Stack - AddItem.MaxStack;
                ListItem.RemoveAt(nullListIndex);

                switch (AddItem)
                {
                    case ToolItem toolItem:
                        ListItem.Insert(nullListIndex, NewItem(toolItem, AddItem.MaxStack));
                        this.AddItem(NewItem(toolItem, RemainStack));
                        break;
                    case FarmingPlantItem farmingPlantItem:
                        ListItem.Insert(nullListIndex, NewItem(farmingPlantItem, AddItem.MaxStack));
                        this.AddItem(NewItem(farmingPlantItem, RemainStack));
                        break;
                    case FruitItem fruitItem:
                        ListItem.Insert(nullListIndex, NewItem(fruitItem, AddItem.MaxStack));
                        this.AddItem(NewItem(fruitItem, RemainStack));
                        break;
                    case EggItem eggItem:
                        ListItem.Insert(nullListIndex, NewItem(eggItem, AddItem.MaxStack));
                        this.AddItem(NewItem(eggItem, RemainStack));
                        break;
                    case MilkItem milkItem:
                        ListItem.Insert(nullListIndex, NewItem(milkItem, AddItem.MaxStack));
                        this.AddItem(NewItem(milkItem, RemainStack));
                        break;
                }
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

    private Item NewItem(Item item, int Stack)
    {
        return item switch
        {
            ToolItem toolItem => new ToolItem(toolItem.Icon, toolItem.ID, toolItem.Name, Stack, toolItem.MaxStack, toolItem.IsConsumable, toolItem.Durability, toolItem.MaxDurability),
            FarmingPlantItem farmingPlantItem => new FarmingPlantItem(farmingPlantItem.Icon, farmingPlantItem.ID, farmingPlantItem.Name, Stack, farmingPlantItem.MaxStack, farmingPlantItem.IsConsumable),
            FruitItem fruitItem => new FruitItem(fruitItem.Icon, fruitItem.ID, fruitItem.Name, Stack, fruitItem.MaxStack, fruitItem.IsConsumable),
            EggItem eggItem => new EggItem(eggItem.Icon, eggItem.ID, eggItem.Name, Stack, eggItem.MaxStack, eggItem.IsConsumable),
            MilkItem milkItem => new MilkItem(milkItem.Icon, milkItem.ID, milkItem.Name, Stack, milkItem.MaxStack, milkItem.IsConsumable),
            _ => throw new System.ArgumentException("Invalid Item Type (존재하지 않는 아이템 타입임)"),
        };
    }

    private int FindExistItemIndexForRemove(Item RemoveItem)
    {
        int index = ListItem.FindLastIndex(i => RemoveItem.ID == i.ID);
        if (index != -1 && index < InventorySize - 1)
            return index;
        return -1;
    }
    public void RemoveItem(Item RemoveItem, int Quantity = 1, int Index = -1)
    {
        int RemainQuantity;
        int existListIndex = Index != -1 ? Index : FindExistItemIndexForRemove(RemoveItem);
        if (existListIndex != -1)
        {
            if (Quantity >= RemoveItem.Stack)
            {
                RemainQuantity = Quantity - RemoveItem.Stack;
                ListItem.RemoveAt(existListIndex);
                ListItem.Insert(existListIndex, new Item(null, -1, "null", 0, 0, false));
                if (RemainQuantity > 0)
                    this.RemoveItem(RemoveItem, RemainQuantity);
            }
            else
            {
                RemainQuantity = RemoveItem.Stack - Quantity;
                ListItem.RemoveAt(existListIndex);
                
                switch (RemoveItem)
                {
                    case ToolItem toolItem:
                        ListItem.Insert(existListIndex, NewItem(toolItem, RemainQuantity));
                        break;
                    case FarmingPlantItem farmingPlantItem:
                        ListItem.Insert(existListIndex, NewItem(farmingPlantItem, RemainQuantity));
                        break;
                    case FruitItem fruitItem:
                        ListItem.Insert(existListIndex, NewItem(fruitItem, RemainQuantity));
                        break;
                    case EggItem eggItem:
                        ListItem.Insert(existListIndex, NewItem(eggItem, RemainQuantity));
                        break;
                    case MilkItem milkItem:
                        ListItem.Insert(existListIndex, NewItem(milkItem, RemainQuantity));
                        break;
                }
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

    protected virtual void OnRefreshInventory() => OnRefreshInventoryUI?.Invoke();
}