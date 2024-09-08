using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<IItem> Items;
    public Inventory() => Items = new List<IItem>();

    public void AddItem(IItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        Items.Remove(item);
    }

    public IItem GetItem(int id)
    {
        return Items.Find(item => item.ID == id);
    }

    public List<IItem> GetAllItems()
    {
        return Items;
    }




}
