using UnityEngine;

public partial class Mouse : MonoBehaviour
{
    public Vector2 hotSpotDefault = new(5, 2);
    public Vector2 hotSpotCat = new(9, 6);
    public Vector2 hotSpotTriangle = new(3, 13);
    public Vector2 hotSpotTriangleSmall = new(2, 14);

    private GameObject mouse;
    private SpriteRenderer sprite;

    private MouseType Type_ = MouseType.Default;
    private MouseState State_ = MouseState.Normal;

    public bool isVisible = false;
    public bool isPointing = false;

    void Start()
    {
        MouseVisible(isVisible);
        LoadTextureAll();
        InitialSettings();
    }
    
    void Update()
    {
        SetState();
        SetMouse();
        MousePosition();
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

    public void MouseVisible(bool isVisible)
    {
        if (Cursor.visible == isVisible) return;
        Cursor.visible = isVisible;
    }

    private void MousePosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.transform.position = mousePos;
    }

    public void SetType(MouseType type) => Type = type;
    private void SetState()
    {
        if (isPointing) State = MouseState.Pointing;
        else
        {
            if (Input.GetMouseButton(0)) State = MouseState.Drag;
            else State = MouseState.Normal;
        }
    }

    private void SetMouse()
    {
        switch (Type)
        {
            case MouseType.Default:
                SetMouseSprite(Default, new Vector2(0.25f, 0.875f));
                break;
            case MouseType.Cat:
                SetMouseSprite(Cat, new Vector2(0.3125f, 0.75f));
                break;
            case MouseType.Triangle:
                SetMouseSprite(Triangle, new Vector2(0.1875f, 0.8125f));
                break;
            case MouseType.TriangleSmall:
                SetMouseSprite(TriangleSmall, new Vector2(0.125f, 0.875f));
                break;
        }
    }
    private void SetMouseSprite(Texture2D[] textures, Vector2 pivot)
    {
        Texture2D texture = textures[(int)State];
        sprite.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot, 16);
    }

}