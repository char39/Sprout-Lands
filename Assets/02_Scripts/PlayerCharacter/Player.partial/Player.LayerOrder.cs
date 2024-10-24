using System;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private LayerMask groundMask;
    private LayerMask structureMask;
    private LayerMask structureOrderMask;           // SetOrderMask가 적용된 오브젝트들을 찾기 위한 마스크
    private LayerMask structureAlphaMask;           // SetAlpha가 적용된 오브젝트들을 찾기 위한 마스크
    
    private SetAlpha[] SetAlphaObj;                 // SetAlpha가 적용된 오브젝트들을 저장함.
    private SetOrderMask[] SetOrderMaskObj;         // SetOrderMask가 적용된 오브젝트들을 저장함.
    private List<SetAlpha> SetAlphaList;            // Raycast로 찾은 SetAlpha 오브젝트들을 저장함.
    private List<SetOrderMask> SetOrderMaskList;    // Raycast로 찾은 SetOrderMask 오브젝트들을 저장함.

    /// <summary> Raycast로 찾은 값들을 반환함. </summary>
    private RaycastHit2D[] GetOthersRayCast(LayerMask layerMasks) => Physics2D.RaycastAll(pivotTr.position, Vector2.zero, 0, layerMasks);

    /// <summary> SetOrderMask가 적용된 오브젝트들을 찾아서 SetOrderMaskList에 저장함. </summary>
    private void SetObjectsOrderMask()
    {
        RaycastHit2D[] hitOrderMask = GetOthersRayCast(structureOrderMask);

        if (hitOrderMask.Length > 0)
            foreach (var hit in hitOrderMask)
                if (hit.collider.TryGetComponent(out SetOrderMask orderMask))
                    if (!SetOrderMaskList.Contains(orderMask))  // 중복 방지
                        SetOrderMaskList.Add(orderMask);        // 리스트에 추가

        for (int i = SetOrderMaskList.Count - 1; i >= 0; i--)
            if (!Array.Exists(hitOrderMask, hit => hit.collider.GetComponent<SetOrderMask>() == SetOrderMaskList[i]))
                SetOrderMaskList.RemoveAt(i);

        foreach (var maskObj in SetOrderMaskObj)
        {
            if (SetOrderMaskList.Contains(maskObj))
                maskObj.SetOrderHigh();
            else
                maskObj.SetOrderOrigin();
        }
    }

    /// <summary> SetAlpha가 적용된 오브젝트들을 찾아서 SetAlphaList에 저장함. </summary>
    private void SetObjectsAlphaMask()
    {
        RaycastHit2D[] hitAlphaMask = GetOthersRayCast(structureAlphaMask);

        if (hitAlphaMask.Length > 0)
            foreach (var hit in hitAlphaMask)
                if (hit.collider.TryGetComponent(out SetAlpha alphaMask))
                    if (!SetAlphaList.Contains(alphaMask))      // 중복 방지
                        SetAlphaList.Add(alphaMask);            // 리스트에 추가

        for (int i = SetAlphaList.Count - 1; i >= 0; i--)
            if (!Array.Exists(hitAlphaMask, hit => hit.collider.GetComponent<SetAlpha>() == SetAlphaList[i]))
                SetAlphaList.RemoveAt(i);

        foreach (var alphaObj in SetAlphaObj)
        {
            if (SetAlphaList.Contains(alphaObj))
                alphaObj.SetAlphaLow();
            else
                alphaObj.SetAlphaOrigin();
        }
    }

    /// <summary> SetAlpha가 적용된 오브젝트들을 찾아서 SetAlphaObj에 저장함. </summary>
    public void UpdateAllAlphaObj()
    {
        SetAlphaObj = null;
        SetAlphaObj = FindObjectsOfType<SetAlpha>();
    }
    /// <summary> SetOrderMask가 적용된 오브젝트들을 찾아서 SetOrderMaskObj에 저장함. </summary>
    public void UpdateAllOrderMaskObj()
    {
        SetOrderMaskObj = null;
        SetOrderMaskObj = FindObjectsOfType<SetOrderMask>();
    }
}
