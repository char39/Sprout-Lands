using UnityEngine;

public abstract class ButtonBase : MonoBehaviour
{
    protected Vector3 mousePos;
    protected Vector2 mousePos2D;
    protected RaycastHit2D hit;

    protected SpriteRenderer Image;
    protected Sprite ButtonNormal;
    protected Sprite ButtonPressed;

    protected Collider2D ButtonCollider;    // 버튼 콜라이더
    public bool IsPressed = false;          // 버튼 눌림 여부
    public bool IsClicked = false;          // 버튼 클릭 여부

    void Start()
    {
        TryGetComponent(out Image);
        TryGetComponent(out ButtonCollider);
        InitializeSprites();
    }

    void Update()
    {
        MousePressCheck();
        MouseClickCheck();
    }

    protected abstract void InitializeSprites();
    protected abstract void OnButtonClick();

    public void MouseClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos2D = new(mousePos.x, mousePos.y);
            hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider == ButtonCollider)
            {
                OnButtonClick();
            }
        }
    }

    public void MousePressCheck()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos2D = new(mousePos.x, mousePos.y);
            hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider == ButtonCollider)
            {
                IsPressed = true;
                if (ButtonPressed != null)
                    Image.sprite = ButtonPressed;
            }
        }
        else
        {
            IsPressed = false;
            if (ButtonNormal != null)
                Image.sprite = ButtonNormal;
        }
    }
}