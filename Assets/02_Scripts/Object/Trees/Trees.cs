using UnityEngine;

public partial class Trees : MonoBehaviour
{
    void Start()
    {
        GetTreeComponent();
        GetFruitComponent();

        treeIsVaild = GetTreeDataIsVaild();
        fruitIsVaild = GetFruitDataIsVaild();

        GetComponentInChildren<MaskClass>().gameObject.TryGetComponent(out mask);
        GetComponentInChildren<SetOrderMask_Trees>().gameObject.TryGetComponent(out order);
    }

    void Update()
    {
        RefreshAll();

        TreeInteraction();
    }

    private void GetTreeComponent() => treeData = GetComponentInChildren<TreeClass>();
    private void GetFruitComponent() => fruitData = GetComponentInChildren<FruitClass>();
    private bool GetTreeDataIsVaild() => treeData != null && treeData.ani != null && treeData.sr != null;
    private bool GetFruitDataIsVaild() => fruitData != null && fruitData.ani != null && fruitData.sr != null;

    private void RefreshAll()
    {
        SetTreeSprite();
        SetFruitSprite();
        SetMasks();
    }

    private void SetTreeSprite()
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

    private void SetFruitSprite()
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

    private void SetMasks()
    {
        Vector2? maskOffset = TreesStructureMasks.maskOffsets[(int)tree, (int)state];
        Vector2? maskSize = TreesStructureMasks.maskSizes[(int)tree, (int)state];
        Vector2? orderOffset = TreesStructureMasks.orderOffsets[(int)tree, (int)state];
        Vector2? orderSize = TreesStructureMasks.orderSizes[(int)tree, (int)state];
        Vector2? alphaOffset = TreesStructureMasks.alphaOffsets[(int)tree, (int)state];
        Vector2? alphaSize = TreesStructureMasks.alphaSizes[(int)tree, (int)state];

        SetMask(mask, maskOffset, maskSize);
        SetMask(order, orderOffset, orderSize);
        SetMask(treeData.alpha, alphaOffset, alphaSize);
        SetMask(fruitData.alpha, alphaOffset, alphaSize);

        static void SetMask(BoxCollider2D mask, Vector2? offset, Vector2? size)
        {
            if (mask == null) return;

            if (offset == null || size == null)
                mask.enabled = false;
            else
            {
                mask.enabled = true;
                mask.offset = (Vector2)offset;
                mask.size = (Vector2)size;
            }
        }
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
            if (GetTreeDataIsVaild() && (state == ITree.State.Normal || state == ITree.State.Harvest))
                treeData.ani.SetTrigger(ITree.BounceTrigger);
            if (GetFruitDataIsVaild() && state == ITree.State.Harvest)
                fruitData.ani.SetTrigger(ITree.BounceTrigger);
        }
    }

    private void PlayTreeMove()
    {
        isTreeMoveEnable = false;
        if (tree == ITree.Type.Tree)
        {
            if (GetTreeDataIsVaild() && (state == ITree.State.Normal || state == ITree.State.Harvest))
                treeData.ani.SetTrigger(ITree.TreeMoveTrigger);
            if (GetFruitDataIsVaild() && state == ITree.State.Harvest)
                fruitData.ani.SetTrigger(ITree.TreeMoveTrigger);
        }
    }

    private void PlayFruitDrop()
    {
        isFruitDropEnable = false;
        if (tree == ITree.Type.Tree)
        {
            if (GetTreeDataIsVaild() && (state == ITree.State.Normal || state == ITree.State.Harvest))
                treeData.ani.SetTrigger(ITree.FruitDropTrigger);
            if (GetFruitDataIsVaild() && state == ITree.State.Harvest)
                fruitData.ani.SetTrigger(ITree.FruitDropTrigger);
        }
    }



    private void OnDrawGizmos()
    {
        // 캐릭터의 움직임이 불가한 구역을 표시
        Gizmos.color = new Color(1, 1, 0, 0.5f);
        Vector2? offset = TreesStructureMasks.maskOffsets[(int)tree, (int)state];
        Vector2? size = TreesStructureMasks.maskSizes[(int)tree, (int)state];
        if (offset == null || size == null)
            return;
        Gizmos.DrawWireCube(transform.position + (Vector3)offset, (Vector2)size);
    }
}