using UnityEngine;

public class Item : IItem
{
    public Sprite Icon { get; private set; }
    public string Name { get; private set; }
    public int ID { get; private set; }
    public int Stack { get; private set; } = 1;
    public int MaxStack { get; private set; } = 1;
    public bool IsStackable => MaxStack > 1;
    public bool IsConsumable { get; private set; } = false;

    public Item(Sprite Icon, string Name, int ID)
    {
        this.Icon = Icon;
        this.Name = Name;
        this.ID = ID;
    }

    public Item(Sprite Icon, string Name, int ID, int Stack, int MaxStack, bool IsConsumable)
    {
        this.Icon = Icon;
        this.Name = Name;
        this.ID = ID;
        this.Stack = Stack;
        this.MaxStack = MaxStack;
        this.IsConsumable = IsConsumable;
    }

    public void Use()
    {

    }

    public void Remove()
    {

    }
}
