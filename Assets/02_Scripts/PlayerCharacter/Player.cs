using UnityEngine;
using System.Collections.Generic;

public partial class Player : MonoBehaviour
{
    //--------------------------------------------------------//
    void Start()
    {
        GetComponents();
        SetValue();
    }

    void Update()
    {
        GetPlayerMoveKeyInput();
        OnUseKey();
        OnInteractiveKey();
        SetPlayerMoveVelocity();
        SetPlayerAnimation();

        UpdateAllAlphaObj();        // 임시
        UpdateAllOrderMaskObj();    // 임시
        SetObjectsOrderMask();
        SetObjectsAlphaMask();

        SetFindTileObjectPos();
    }
    
    void LateUpdate()
    {
        StateInfoCheck();
    }    
    //--------------------------------------------------------//
    private Animator ani;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Transform tr;
    public Transform pivotTr;   // 임시로 public으로 해둠. 추후 수정 필요.
    private Transform FindTileObjectTr;
    private WaterDrop water;
    private Collider2D col;
    //--------------------------------------------------------//
    private void GetComponents()
    {
        TryGetComponent(out ani);
        TryGetComponent(out sr);
        TryGetComponent(out rb);
        TryGetComponent(out tr);
        pivotTr = tr.GetChild(0).GetComponent<Transform>();
        FindTileObjectTr = pivotTr.GetChild(0).GetComponent<Transform>();
        water = FindTileObjectTr.GetChild(0).GetComponent<WaterDrop>();
        TryGetComponent(out col);
    }
    private void SetValue()
    {
        SetAlphaList = new List<SetAlpha>();
        SetOrderMaskList = new List<SetOrderMask>();
        groundMask = 1 << LayerMask.NameToLayer("GroundMask");
        waterMask = 1 << LayerMask.NameToLayer("Water");
        structureMask = 1 << LayerMask.NameToLayer("StructureMask");
        structureOrderMask = 1 << LayerMask.NameToLayer("StructureOrderMask");
        structureAlphaMask = 1 << LayerMask.NameToLayer("StructureAlphaMask");
        tileObjectsMask = 1 << LayerMask.NameToLayer("TileObjectMask");
        crops = 1 << LayerMask.NameToLayer("Crops");
    }



    private void OnDrawGizmos()
    {
        if (pivotTr == null) return;
        DrawGroundBoxCast();
        DrawGroundBoxCastLookAt();

        DrawFindObjectCheck();
    }
}
