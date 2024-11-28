using UnityEngine;

public class TreeClass : MonoBehaviour, ITree
{
    [HideInInspector] public Animator ani;
    [HideInInspector] public SpriteRenderer sr;

    void Awake()
    {
        TryGetComponent(out ani);
        TryGetComponent(out sr);
    }
}
