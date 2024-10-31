using UnityEngine;

public class FarmingPlantItem : Item
{
    public FarmingPlantItem(Sprite Icon, int ID, string Name, int Stack, int MaxStack, bool IsConsumable)
        : base(Icon, ID, Name, Stack, MaxStack, IsConsumable) { }

    public override void Use()
    {
        Player player = GM.DATA.player;
        if (player == null) return;

        if (IsConsumable)
            UseCrops(ID, player);
        else
            UseSeed(ID, player);
    }

    private void UseCrops(int ID, Player player)
    {
        if (player.IsObjectDetected())
        {
            // 다 자란 농작물 소비
            Remove(1);
        }
    }

    private void UseSeed(int ID, Player player)
    {
        if (player.IsObjectDetected())
        {
            player.SetPlayerUseSeed(ID);
            Remove(1);
        }
    }

    public override void Remove(int Stack)
    {
        base.Remove(Stack);
        Debug.Log("Remove FarmingPlantItem");
    }
}