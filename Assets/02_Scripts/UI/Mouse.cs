using System.Collections;
using UnityEngine;

public partial class Mouse : MonoBehaviour
{
    public static Mouse Instance {get; set;}
    private GameObject mouse;
    private SpriteRenderer sprite;

    private Vector2 hotSpotDefault = new(5, 2);
    private Vector2 hotSpotCat = new(9, 6);
    private Vector2 hotSpotTriangle = new(3, 13);
    private Vector2 hotSpotTriangleSmall = new(2, 14);

    private float DisappearTime = 2.0f;
    private float Timer = 0;
    private float fadeTime = 0.5f;
    private float alpha = 1;
    private Vector3 lastMousePos = Vector3.zero;

    private MouseType Type_ = MouseType.Cat;
    private MouseState State_ = MouseState.Normal;

    private bool isVisible = false;                 // 마우스 커서 보이는 여부
    public bool IsPointing { get; set; }            // 마우스 포인팅 여부
    private bool canDisappear = true;               // 마우스 커서 자동으로 사라지게 할지 여부

    private bool isBlinking = false;                    // 마우스 깜빡임 여부
    private Coroutine blinkCoroutine;

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
        if (IsPointing)
        {
            State = MouseState.Pointing;
            if (!isBlinking)
                blinkCoroutine = StartCoroutine(BlinkMouse());
        }
        else
        {
            if (Input.GetMouseButton(0)) State = MouseState.Drag;
            else State = MouseState.Normal;

            isBlinking = false;
            if (blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine);
                blinkCoroutine = null;
            }
            sprite.color = new Color(1, 1, 1, 1);

        }
    }
    private IEnumerator BlinkMouse()
    {
        isBlinking = true;
        while (isBlinking)
        {
            sprite.color = Color.white;
            yield return new WaitForSeconds(0.5f);
            sprite.color = new Color(0.85f, 0.85f, 0.85f, 1f);
            yield return new WaitForSeconds(0.5f);
        }
    }


    private void MouseDisappear()
    {
        if (!canDisappear && !isBlinking)
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