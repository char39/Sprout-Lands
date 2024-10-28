using System.Collections;
using UnityEngine;

public class SetOrderMask_Crops : SetOrderMask
{
    protected SpriteRenderer spr_water;
    private readonly string waterObjName = "Water";

    protected override void Start()
    {
        base.Start();
        transform.parent.Find(waterObjName).TryGetComponent(out spr_water);
    }

    protected override IEnumerator StartOrderHigh()
    {
        if (tile != null || spr != null)
        {
            IsOrderOrigin = false;
            if (spr != null)
            {
                spr.sortingOrder = 12;
                spr_water.sortingOrder = 13;
            }
            else if (tile != null)
            {
                tile.sortingOrder = 12;
                spr_water.sortingOrder = 13;
            }
            yield return null;
        }
    }

    protected override IEnumerator StartOrderOrigin()
    {
        if ((tile != null || spr != null) && !IsOrderOrigin)
        {
            if (spr != null)
            {
                spr.sortingOrder = 8;
                spr_water.sortingOrder = 9;
            }
            else if (tile != null)
            {
                tile.sortingOrder = 8;
                spr_water.sortingOrder = 9;
            }
            IsOrderOrigin = true;
            yield return null;
        }
    }
}