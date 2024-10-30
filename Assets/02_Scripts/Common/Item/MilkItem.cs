using UnityEngine;

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
        base.Remove(Stack);
        Debug.Log("Remove MilkItem");
    }
}