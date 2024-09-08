using UnityEngine;

public partial class Player
{
    private LayerMask groundMask;
    private LayerMask structureMask;
    private LayerMask structureOrderMask;
    private LayerMask structureAlphaMask;
    private SetAlpha[] SetAlphaObj;

    private void SetPlayerOrderMask()
    {
        var hit = GetOthersBoxCast(structureOrderMask);
        var hitAlpha = GetOthersBoxCast(structureAlphaMask);

        if (hit.collider != null)
            sr.sortingOrder = 0;
        else
            sr.sortingOrder = 10;

        if (hitAlpha.collider != null)
            hitAlpha.collider.SendMessage(nameof(SetAlpha.SetAlphaLow), SendMessageOptions.DontRequireReceiver);
        else
            foreach (var obj in SetAlphaObj)
                obj.SetAlphaOrigin();
    }

    /// <summary> SetAlpha가 적용된 오브젝트들을 찾아서 SetAlphaObj에 저장함. </summary>
    public void ReFreshAlphaObj() => SetAlphaObj = FindObjectsOfType<SetAlpha>();

    private RaycastHit2D GetOthersBoxCast(LayerMask layerMasks)
    {
        Vector2 origin = GetRayOriginPos(pivotTr.position);
        RaycastHit2D hit = Physics2D.BoxCast(origin, new(0.5f, 0.5f), 0, Vector2.zero, 0, layerMasks);
        return hit;
    }
}
