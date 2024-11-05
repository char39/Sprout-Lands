using UnityEngine;

public class Trees : MonoBehaviour
{
    public TreeData treeData;
    public FruitData fruitData;

    void Start()
    {
        transform.GetChild(0).TryGetComponent(out treeData);
        transform.GetChild(1).TryGetComponent(out fruitData);


    }

    void Update()
    {
        if (testBounce)
            PlayBounce();
        if (testTreeMove)
            PlayTreeMove();
        if (testFruitDrop)
            PlayFruitDrop();
    }

    public bool testBounce = false;
    public bool testTreeMove = false;
    public bool testFruitDrop = false;

    private void PlayBounce()
    {
        testBounce = false;
        if (treeData != null && treeData.ani != null && fruitData != null && fruitData.ani != null)
        {
            if (treeData.type == ITree.Type.Tree)
            {
                treeData.ani.SetTrigger(ITree.BounceTrigger);
                fruitData.ani.SetTrigger(ITree.BounceTrigger);
            }
        }
    }

    private void PlayTreeMove()
    {
        testTreeMove = false;
        if (treeData != null && treeData.ani != null && fruitData != null && fruitData.ani != null)
        {
            if (treeData.type == ITree.Type.Tree)
            {
                treeData.ani.SetTrigger(ITree.TreeMoveTrigger);
                fruitData.ani.SetTrigger(ITree.TreeMoveTrigger);
            }
        }
    }

    private void PlayFruitDrop()
    {
        testFruitDrop = false;
        if (treeData != null && treeData.ani != null && fruitData != null && fruitData.ani != null)
        {
            if (treeData.type == ITree.Type.Tree)
            {
                treeData.ani.SetTrigger(ITree.FruitDropTrigger);
                fruitData.ani.SetTrigger(ITree.FruitDropTrigger);
            }
        }
    }



}
