using UnityEngine;

public partial class Mouse : MonoBehaviour
{
    public static Mouse Instance {get; set;}

    private Vector2 PivotDefault = new(5, 2);
    private Vector2 PivotCat = new(9, 6);
    private Vector2 PivotTriangle = new(3, 13);
    private Vector2 PivotTriangleSmall = new(2, 14);

    public MouseType Type_ = MouseType.Default;
    public MouseState State_ = MouseState.Normal;
    public MouseAlpha Alpha_ = MouseAlpha.Full;
    public int MouseSize = 32;

    public bool IsVisible { get; set; }             // 마우스 커서 보이는 여부
    public bool IsPointing { get; set; }            // 마우스 포인팅 여부

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        MouseVisible(IsVisible);
        LoadTextureAll();

        
    }
    
    void Update()
    {
        SetState();
        GetTextureType();
    }

    /// <summary> 마우스 커서를 보이게 하거나 숨김. (외부에서 변경 가능) </summary>
    public void MouseVisible(bool isVisible)
    {
        if (Cursor.visible == isVisible) return;
        this.IsVisible = isVisible;
        Cursor.visible = this.IsVisible;
    }
    /// <summary> 마우스 종류 변경. (외부에서 변경 가능) </summary>
    public void SetType(MouseType type) => Type = type;
    private void SetState()
    {
        if (Input.GetMouseButton(0)) State = MouseState.Drag;   // 우선순위 1 (클릭중)
        else if (IsPointing) State = MouseState.Pointing;       // 우선순위 2 (포인팅)
        else State = MouseState.Normal;                         // 우선순위 3 (기본값)
    }
    /// <summary> 마우스 크기 변경. (외부에서 변경 가능) </summary>
    public void SetSize(int size) => MouseSize = size;
    /// <summary> 마우스 투명도 변경. (외부에서 변경 가능) </summary>
    public void SetAlpha(MouseAlpha alpha) => Alpha = alpha;
    private float GetAlpha(MouseAlpha alpha)
    {
        if (alpha == MouseAlpha.Full) return 1;
        else if (alpha == MouseAlpha.Half) return 0.5f;
        else return 0;
    }

    private void GetTextureType()
    {
        switch (Type)
        {
            case MouseType.Default:
                SetMouseCursor(Default, PivotDefault);
                break;
            case MouseType.Cat:
                SetMouseCursor(Cat, PivotCat);
                break;
            case MouseType.Triangle:
                SetMouseCursor(Triangle, PivotTriangle);
                break;
            case MouseType.TriangleSmall:
                SetMouseCursor(TriangleSmall, PivotTriangleSmall);
                break;
        }
    }
}