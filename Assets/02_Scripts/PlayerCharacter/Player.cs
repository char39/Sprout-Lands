using UnityEngine;

public partial class Player : MonoBehaviour
{
    //--------------------------------------------------------//
    void Start()
    {
        GetComponents();
        SetValue();
        GetAllAlphaObj();
        GetAllOrderMaskObj();
    }

    void Update()
    {
        GetPlayerMoveKeyInput();
        OnUseKey();
        OnInteractiveKey();
        SetPlayerOrderMask();
        SetPlayerMoveVelocity();
        SetPlayerAnimation();

        FindObjectCheck();
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
    private Collider2D col;
    //--------------------------------------------------------//
    private void GetComponents()
    {
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        pivotTr = tr.GetChild(0).GetComponent<Transform>();
        FindTileObjectTr = pivotTr.GetChild(0).GetComponent<Transform>();
        col = GetComponent<BoxCollider2D>();
    }
    private void SetValue()
    {
        groundMask = 1 << LayerMask.NameToLayer("GroundMask");
        structureMask = 1 << LayerMask.NameToLayer("StructureMask");
        structureOrderMask = 1 << LayerMask.NameToLayer("StructureOrderMask");
        structureAlphaMask = 1 << LayerMask.NameToLayer("StructureAlphaMask");
        tileObjectsMask = 1 << LayerMask.NameToLayer("TileObjectMask");
    }



    private void OnDrawGizmos()
    {
        if (pivotTr == null) return;
        DrawGroundBoxCast();
        DrawGroundBoxCastLookAt();

        DrawFindObjectCheck();
    }
}
