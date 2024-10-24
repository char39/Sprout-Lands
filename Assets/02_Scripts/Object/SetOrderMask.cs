using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetOrderMask : MonoBehaviour
{
    private SpriteRenderer spr;
    private TilemapRenderer tile;
    private bool IsOrderOrigin = false;

    void Start()
    {
        transform.parent.TryGetComponent(out spr);
        transform.parent.TryGetComponent(out tile);
    }

    /// <summary> SortingOrder을 높임. </summary>
    public void SetOrderHigh() => StartCoroutine(StartOrderHigh());
    private IEnumerator StartOrderHigh()
    {
        if (tile != null || spr != null)
        {
            IsOrderOrigin = false;
            if (spr != null)
                spr.sortingOrder = 11;
            else if (tile != null)
                tile.sortingOrder = 11;
            yield return null;
        }
    }
    /// <summary> SortingOrder을 복구함. </summary>
    public void SetOrderOrigin() => StartCoroutine(StartOrderOrigin());
    private IEnumerator StartOrderOrigin()
    {
        if ((tile != null || spr != null) && !IsOrderOrigin)
        {
            if (spr != null)
                spr.sortingOrder = 9;
            else if (tile != null)
                tile.sortingOrder = 9;
            IsOrderOrigin = true;
            yield return null;
        }
    }
}