using UnityEngine;

public partial class Mouse : MonoBehaviour
{
    private GameObject mouse;
    private SpriteRenderer sprite;

    public Vector2 hotSpotDefault = new(5, 2);
    public Vector2 hotSpotCat = new(9, 6);
    public Vector2 hotSpotTriangle = new(3, 13);
    public Vector2 hotSpotTriangleSmall = new(2, 14);

    private float DisappearTime = 2.0f;
    private float Timer = 0;
    private float fadeTime = 0.5f;
    private float alpha = 1;
    private Vector3 lastMousePos = Vector3.zero;

    private MouseType Type_ = MouseType.Triangle;
    private MouseState State_ = MouseState.Normal;

    public bool isVisible = false;
    private bool IsPointing_ = false;
    public bool IsPointing
    {
        get { return IsPointing_; }
        set { IsPointing_ = value; }
    }
    public bool canDisappear = true;

    void Start()
    {
        MouseVisible(isVisible);
        LoadTextureAll();
        InitialSettings();
    }
    
    void Update()
    {
        MousePosition();
        SetState();
        SetMouse();
        MouseDisappear();
    }

    private void InitialSettings()
    {
        mouse = new GameObject("Mouse");
        mouse.transform.SetParent(transform);
        mouse.AddComponent<SpriteRenderer>();

        sprite = mouse.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "UI";
        sprite.sortingOrder = 500;
    }

    /// <summary> 마우스 커서를 보이게 하거나 숨김. </summary>
    public void MouseVisible(bool isVisible)
    {
        if (Cursor.visible == isVisible) return;
        this.isVisible = isVisible;
        Cursor.visible = this.isVisible;
    }
    private void MousePosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.transform.position = mousePos;
    }

    /// <summary> 마우스 종류 변경. </summary>
    public void SetType(MouseType type) => Type = type;
    private void SetState()
    {
        if (IsPointing_) State = MouseState.Pointing;
        else
        {
            if (Input.GetMouseButton(0)) State = MouseState.Drag;
            else State = MouseState.Normal;
        }
    }

    private void MouseDisappear()
    {
        if (!canDisappear)
        {
            SetMouseAlpha(1);
            return;
        }
        if (Input.mousePosition != lastMousePos || State != MouseState.Normal)
        { 
            Timer = 0;
            SetMouseAlpha(1);
        }
        else
        {
            Timer += Time.deltaTime;
            if (Timer > DisappearTime) 
                FadeMouse();
        }
        lastMousePos = Input.mousePosition;
    }
    private void FadeMouse()
    {
        alpha = Mathf.Lerp(1, 0, (Timer - DisappearTime) / fadeTime);
        SetMouseAlpha(alpha);
    }
    private void SetMouseAlpha(float alpha)
    {
        Color color = sprite.color;
        color.a = alpha;
        sprite.color = color;
    }
}