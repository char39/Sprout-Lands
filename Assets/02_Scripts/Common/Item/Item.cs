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

    public virtual void Remove(int Stack) => GameManager.GM.inventory.RemoveItem(this, Stack, Index ?? -1);

    protected void RefreshInventoryUI() => GameManager.GM.inventoryUI.RefreshInventoryUI();
}