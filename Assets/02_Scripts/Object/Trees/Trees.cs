using UnityEngine;

public partial class Trees : MonoBehaviour
{
    void Start()
    {
        GetTreeComponent();
        GetFruitComponent();

        treeIsVaild = GetTreeDataIsVaild();
        fruitIsVaild = GetFruitDataIsVaild();
    }

    void Update()
    {
        UpdateTreeSprite();
        UpdateFruitSprite();

        TreeInteraction();
    }

    private void GetTreeComponent() => treeData = GetComponentInChildren<TreeClass>();
    private void GetFruitComponent() => fruitData = GetComponentInChildren<FruitClass>();
    private bool GetTreeDataIsVaild() => treeData != null && treeData.ani != null && treeData.sr != null;
    private bool GetFruitDataIsVaild() => fruitData != null && fruitData.ani != null && fruitData.sr != null;

    private void UpdateTreeSprite()
    {
        if (!treeIsVaild)
        {
            GetTreeComponent();
            treeIsVaild = GetTreeDataIsVaild();
            return;
        }

        if (tree == ITree.Type.Tree && (state == ITree.State.Normal || state == ITree.State.Harvest))
            treeData.ani.enabled = true;
        else
        {
            treeData.ani.enabled = false;

            int index = TreeSprites.Index[(int)tree, (int)state];
            if (index != -1)
                treeData.sr.sprite = Icons.Trees[index];
        }
    }

    private void UpdateFruitSprite()
    {
        if (!fruitIsVaild)
        {
            GetFruitComponent();
            fruitIsVaild = GetFruitDataIsVaild();
            return;
        }

        int index = tree == ITree.Type.Tree && state == ITree.State.Harvest ? (int)fruit : 0;
        fruitData.ani.SetFloat(IFruit.FruitID, index);
    }











    private void TreeInteraction()
    {
        if (isBounceEnable)
            PlayBounce();
        if (isTreeMoveEnable)
            PlayTreeMove();
        if (isFruitDropEnable)
            PlayFruitDrop();
    }

    private void PlayBounce()
    {
        isBounceEnable = false;
        if (tree == ITree.Type.Tree)
        {
            if (GetTreeDataIsVaild())
                treeData.ani.SetTrigger(ITree.BounceTrigger);
            if (GetFruitDataIsVaild())
                fruitData.ani.SetTrigger(ITree.BounceTrigger);
        }
    }

    private void PlayTreeMove()
    {
        isTreeMoveEnable = false;
        if (tree == ITree.Type.Tree)
        {
            if (GetTreeDataIsVaild())
                treeData.ani.SetTrigger(ITree.TreeMoveTrigger);
            if (GetFruitDataIsVaild())
                fruitData.ani.SetTrigger(ITree.TreeMoveTrigger);
        }
    }

    private void PlayFruitDrop()
    {
        isFruitDropEnable = false;
        if (tree == ITree.Type.Tree)
        {
            if (GetTreeDataIsVaild())
                treeData.ani.SetTrigger(ITree.FruitDropTrigger);
            if (GetFruitDataIsVaild())
                fruitData.ani.SetTrigger(ITree.FruitDropTrigger);
        }
    }
}
