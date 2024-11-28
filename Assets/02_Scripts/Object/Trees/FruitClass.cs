using UnityEngine;

public class FruitClass : MonoBehaviour, IFruit
{
    [HideInInspector] public Animator ani;
    [HideInInspector] public SpriteRenderer sr;

    void Awake()
    {
        TryGetComponent(out ani);
        TryGetComponent(out sr);
    }
}
