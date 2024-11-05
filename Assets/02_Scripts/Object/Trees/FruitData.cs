using UnityEngine;

public class FruitData : MonoBehaviour, IFruit
{
    public Animator ani;
    public SpriteRenderer sr;

    public IFruit.Type type;

    void Awake()
    {
        TryGetComponent(out ani);
        TryGetComponent(out sr);
    }

    void Update()
    {
        if (ani != null)
            ani.SetFloat(IFruit.FruitID, (int)type);
    }
}
