using UnityEngine;

public partial class Player
{
    private LayerMask groundMask;
    private LayerMask structureMask;
    private LayerMask structureOrderMask;
    private LayerMask structureAlphaMask;
    private SetAlpha[] SetAlphaObj;
    private SetOrderMask[] SetOrderMaskObj;

    private void SetPlayerOrderMask()
    {
        // player sortingOrder = 10
        var hits = GetOthersBoxCast(structureOrderMask);

        if (hits.Length > 0)
            foreach (var hit in hits)
                hit.transform.GetComponent<SetOrderMask>().SetOrderHigh();
        else
            foreach (var obj in SetOrderMaskObj)
                obj.SetOrderOrigin();

        var hitAlphas = GetOthersBoxCast(structureAlphaMask);

        if (hitAlphas.Length > 0)
            foreach (var hitAlpha in hitAlphas)
                hitAlpha.transform.GetComponent<SetAlpha>().SetAlphaLow();
        else
            foreach (var obj in SetAlphaObj)
                obj.SetAlphaOrigin();
    }

    /// <summary> SetAlpha가 적용된 오브젝트들을 찾아서 SetAlphaObj에 저장함. </summary>
    public void GetAllAlphaObj() => SetAlphaObj = FindObjectsOfType<SetAlpha>();
    /// <summary> SetOrderMask가 적용된 오브젝트들을 찾아서 SetOrderMaskObj에 저장함. </summary>
    public void GetAllOrderMaskObj() => SetOrderMaskObj = FindObjectsOfType<SetOrderMask>();

    private RaycastHit2D[] GetOthersBoxCast(LayerMask layerMasks)
    {
        Vector2 origin = GetRayOriginPos(pivotTr.position);
        RaycastHit2D[] hit = Physics2D.BoxCastAll(origin, new(0.3f, 0.3f), 0, Vector2.zero, 0, layerMasks);
        return hit;
    }
}
