using UnityEngine;

public class TreeClass : MonoBehaviour, ITree
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
