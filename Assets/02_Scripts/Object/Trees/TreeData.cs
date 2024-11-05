using UnityEngine;

public class TreeData : MonoBehaviour, ITree
{
    public Animator ani;
    public SpriteRenderer sr;

    public ITree.Type type;
    public ITree.State state;
    public ITree.State prevState;

    void Awake()
    {
        TryGetComponent(out ani);
        TryGetComponent(out sr);
    }

    void Update()
    {
        if (type != ITree.Type.Tree)
            ani.enabled = false;
        else
            ani.enabled = true;
    }
}
