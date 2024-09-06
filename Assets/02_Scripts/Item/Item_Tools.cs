using UnityEngine;

public class Item_Tools : IItem
{
    public Sprite Icon { get; private set; }
    public string Name { get; private set; }
    public int ID { get; private set; }
    public int Stack { get; private set; } = 1;
    public int MaxStack { get; private set; } = 1;
    public bool IsStackable { get; private set; } = false;
    public bool IsConsumable { get; private set; } = false;

    public Item_Tools(Sprite Icon, string Name, int ID)
    {
        this.Icon = Icon;
        this.Name = Name;
        this.ID = ID;
    }

    public void Use()
    {

    }

    public void Remove()
    {

    }
}
