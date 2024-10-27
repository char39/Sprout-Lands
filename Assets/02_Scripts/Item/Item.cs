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

    protected void RefreshInventoryUI() => GameManager.GM.InventoryUI.RefreshInventoryUI();
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

    public override void Use()
    {
        Player player = GameManager.GM.player;
        if (player == null) return;

        if (IsConsumable) { }
        else
        {
            if (MaxDurability == 0)                         // 내구도가 존재하지 않음
                UseToolDoesNotExistDurability(player);
            else if (MaxDurability == -1)                   // 내구도 무한
                UseToolUnlimited(ID, player);
            else                                            // 내구도 유한
                UseToolLimited(ID, player);
        }
    }
    
    private void UseToolDoesNotExistDurability(Player player)
    {
        Debug.Log($"{Name} 사용.");
    }

    private void UseToolUnlimited(int ID, Player player)
    {
        player.SetPlayerUseTool(ID);
    }

    private void UseToolLimited(int ID, Player player)
    {
        if (ID == 1 && player.IsWaterDetected())
        {
            player.SetPlayerUseTool(ID);
            Durability = MaxDurability;
            //Debug.Log($"{Name}의 사용 가능 횟수가 {Durability}이 되어 사용이 가능합니다.");
            RefreshInventoryUI();
            return;
        }

        if (Durability <= 0)                            // 내구도가 0 이하
            Durability = 0;     //Debug.Log($"{Name}의 사용 가능 횟수가 {Durability}이 되어 사용할 수 없습니다.");
        else                                            // 내구도가 0 초과
        {
            Durability -= 1;    //Debug.Log($"{Name} 사용. 사용 가능 횟수 : {Durability}.");
            player.SetPlayerUseTool(ID);
            if (Durability <= 0)
                Durability = 0; //Debug.Log($"{Name}의 사용 가능 횟수가 {Durability}이 되어 사용할 수 없습니다.");
        }

        RefreshInventoryUI();
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
    
    private void UseSeed(int ID)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            
        }
    }

    public override void Use()
    {
        if (IsConsumable)
        {
            Debug.Log("Use FarmingPlantItem 작물 소비");
        }
        else
        {
            UseSeed(ID);
        }
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