using UnityEngine;

public class FruitClass : MonoBehaviour, IFruit
{
    [HideInInspector] public Animator ani;
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public BoxCollider2D alpha;

    void Awake()
    {
        TryGetComponent(out ani);
        TryGetComponent(out sr);
        transform.GetChild(0).TryGetComponent(out alpha);
    }
}
