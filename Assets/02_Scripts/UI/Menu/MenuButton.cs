using UnityEngine;

public class MenuButton : ButtonBase
{
    protected override void InitializeSprites()
    {
        transform.parent.localPosition = IsClicked ? new Vector2(0, 0) : new Vector2(-6.6f, 0);
    }

    protected override void OnButtonClick()
    {
        IsClicked = !IsClicked;
        transform.parent.localPosition = IsClicked ? new Vector2(0, 0) : new Vector2(-6.6f, 0);
    }
}