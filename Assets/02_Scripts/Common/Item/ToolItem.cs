using UnityEngine;

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
    public void AddDurability(int Durability) => this.Durability += Durability;

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
            SetDurability(MaxDurability);                   //Debug.Log($"{Name}의 사용 가능 횟수가 {Durability}이 되어 사용이 가능합니다.");
            RefreshInventoryUI();
            return;
        }

        if (Durability <= 0)                            // 내구도가 0 이하
            SetDurability(0);                               //Debug.Log($"{Name}의 사용 가능 횟수가 {Durability}이 되어 사용할 수 없습니다.");
        else                                            // 내구도가 0 초과
        {
            AddDurability(-1);                              //Debug.Log($"{Name} 사용. 사용 가능 횟수 : {Durability}.");
            player.SetPlayerUseTool(ID);
            if (Durability <= 0)
                SetDurability(0);                           //Debug.Log($"{Name}의 사용 가능 횟수가 {Durability}이 되어 사용할 수 없습니다.");
        }

        RefreshInventoryUI();
    }

    public override void Remove(int Stack)
    {
        base.Remove(Stack);
        Debug.Log("Remove ToolItem");
    }
}