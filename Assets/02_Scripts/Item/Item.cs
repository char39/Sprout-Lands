using UnityEngine;

public class Item : IItem
{
    public Sprite Icon { get; private set; }                            // 아이템의 아이콘
    public string Name { get; private set; }                            // 아이템의 이름
    public int ID { get; private set; }                                 // 아이템의 고유 ID
    public int Stack { get; private set; }                              // 아이템의 개수
    public int MaxStack { get; private set; }                           // 아이템의 최대 개수 (기본값 255)
    public bool IsStackable { get => Stack < MaxStack; set { } }        // 아이템의 중첩 가능 여부
    public bool IsConsumable { get; private set; }                      // 아이템의 소모 가능 여부 (true: 소모, false: 사용)
    public int? Index { get; private set; }                             // 아이템의 인덱스. 인벤토리에서 순서를 정할 때 사용

    public Item(Sprite Icon, int ID, string Name, int Stack, int MaxStack, bool IsConsumable)
    {
        this.Icon = Icon;
        this.Name = Name;
        this.ID = ID;
        this.Stack = Stack;
        this.MaxStack = MaxStack;
        this.IsConsumable = IsConsumable;
        Index = null;
    }

    public void SetIndex(int Index) => this.Index = Index;
    public void SetStack(int Stack) => this.Stack = Stack;

    public virtual void Use()
    {
        if (IsConsumable) Debug.Log("Use Item [소비]");
        else Debug.Log("Use Item [사용]");
    }

    public virtual void Remove(int Stack)
    {
        Debug.Log("Remove Item");
    }
}

public class ToolItem : Item
{
    public int Durability { get; private set; }                        // 아이템의 내구도
    public int MaxDurability { get; private set; }                     // 아이템의 최대 내구도

    public ToolItem(Sprite Icon, int ID, string Name, int Stack, int MaxStack, bool IsConsumable)
        : base(Icon, ID, Name, Stack, MaxStack, IsConsumable)
    {
        Durability = 0;
        MaxDurability = 0;
    }
    public ToolItem(Sprite Icon, int ID, string Name, int Stack, int MaxStack, bool IsConsumable, int Durability, int MaxDurability)
        : base(Icon, ID, Name, Stack, MaxStack, IsConsumable)
    {
        this.Durability = Durability;
        this.MaxDurability = MaxDurability;
    }

    public void SetDurability(int Durability) => this.Durability = Durability;

    private void UseToolAni(int ID)
    {
        if (ID == 1 || ID == 2 || ID == 3)
            Player.Instance.SetPlayerAction(ID);
    }

    public override void Use()
    {
        if (IsConsumable)
        {
            
        }
        else
        {
            if (Durability > MaxDurability)
            {
                if (MaxDurability == 0)
                {
                    Debug.Log($"{Name} 사용. 내구도 무한.");
                    UseToolAni(ID);
                }
            }
            else   // = else if (Durability <= MaxDurability)
            {
                if (MaxDurability == 0)
                {
                    Debug.Log($"{Name} 사용. 내구도 존재하지 않음.");
                }
                else if (Durability <= 0)
                {
                    Durability = 0;
                    Debug.Log($"{Name}의 내구도가 {Durability}이 되었습니다.");
                }
                else
                {
                    Debug.Log($"{Name} 사용. 내구도 : {Durability}.");
                    UseToolAni(ID);
                    Durability -= 1;
                }
            }
        }
    }

    public override void Remove(int Stack)
    {
        Debug.Log("Remove ToolItem");
    }
}

public class FarmingPlantItem : Item
{
    public FarmingPlantItem(Sprite Icon, int ID, string Name, int Stack, int MaxStack, bool IsConsumable)
        : base(Icon, ID, Name, Stack, MaxStack, IsConsumable) { }
    
    public override void Use()
    {
        if (IsConsumable)
            Debug.Log("Use FarmingPlantItem [소비]");
        else
            Debug.Log("Use FarmingPlantItem [사용]");
    }

    public override void Remove(int Stack)
    {
        Debug.Log("Remove FarmingPlantItem");
    }
}

public class FruitItem : Item
{
    public FruitItem(Sprite Icon, int ID, string Name, int Stack, int MaxStack, bool IsConsumable)
        : base(Icon, ID, Name, Stack, MaxStack, IsConsumable) { }

    public override void Use()
    {
        if (IsConsumable)
            Debug.Log("Use FruitItem [소비]");
        else
            Debug.Log("Use FruitItem [사용]");
    }

    public override void Remove(int Stack)
    {
        Debug.Log("Remove FruitItem");
    }
}

public class EggItem : Item
{
    public EggItem(Sprite Icon, int ID, string Name, int Stack, int MaxStack, bool IsConsumable)
        : base(Icon, ID, Name, Stack, MaxStack, IsConsumable) { }

    public override void Use()
    {
        if (IsConsumable)
            Debug.Log("Use EggItem [소비]");
        else
            Debug.Log("Use EggItem [사용]");
    }

    public override void Remove(int Stack)
    {
        Debug.Log("Remove EggItem");
    }
}

public class MilkItem : Item
{
    public MilkItem(Sprite Icon, int ID, string Name, int Stack, int MaxStack, bool IsConsumable)
        : base(Icon, ID, Name, Stack, MaxStack, IsConsumable) { }

    public override void Use()
    {
        if (IsConsumable)
            Debug.Log("Use MilkItem [소비]");
        else
            Debug.Log("Use MilkItem [사용]");
    }

    public override void Remove(int Stack)
    {
        Debug.Log("Remove MilkItem");
    }
}