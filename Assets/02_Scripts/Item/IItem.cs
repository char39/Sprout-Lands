using UnityEngine;

public interface IItem
{
    public Sprite Icon { get; }
    public string Name { get; }
    public int ID { get; }
    public int Stack { get; }
    public int MaxStack { get; }
    public bool IsStackable { get; }
    public bool IsConsumable { get; }   // 소비템인가
    public int Index { get; }
    public void Use();
    public void Remove();
}
