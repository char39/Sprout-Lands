using System.Collections;

public class SetOrderMask_Trees : SetOrderMask
{
    private Trees trees;

    private bool IsTreeOrderOrigin = false;
    private bool IsFruitOrderOrigin = false;

    protected override void Start()
    {
        transform.parent.TryGetComponent(out trees);
    }

    protected override IEnumerator StartOrderHigh()
    {
        if (trees.treeData != null && trees.treeData.sr != null)
        {
            IsTreeOrderOrigin = false;
            trees.treeData.sr.sortingOrder = 12;
        }
        if (trees.fruitData != null && trees.fruitData.sr != null)
        {
            IsFruitOrderOrigin = false;
            trees.fruitData.sr.sortingOrder = 13;
        }
        yield return null;
    }

    protected override IEnumerator StartOrderOrigin()
    {
        if (trees.treeData != null && trees.treeData.sr != null && !IsTreeOrderOrigin)
        {
            trees.treeData.sr.sortingOrder = 8;
            IsTreeOrderOrigin = true;
        }
        if (trees.fruitData != null && trees.fruitData.sr != null && !IsFruitOrderOrigin)
        {
            trees.fruitData.sr.sortingOrder = 9;
            IsFruitOrderOrigin = true;
        }
        yield return null;
    }
}