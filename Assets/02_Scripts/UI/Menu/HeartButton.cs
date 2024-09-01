using UnityEngine;

public class HeartButton : ButtonBase
{
    public Sprite HeartButtonNormal;
    public Sprite HeartButtonPressed;

    protected override void InitializeSprites()
    {
        ButtonNormal = HeartButtonNormal;
        ButtonPressed = HeartButtonPressed;
    }

    protected override void OnButtonClick()
    {
        IsClicked = !IsClicked;
    }
}