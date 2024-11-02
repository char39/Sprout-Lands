using UnityEngine;
using UnityEngine.EventSystems;

public class CheckMousePosition : MonoBehaviour
{
    public Vector2 MousePos;
    public Vector2 MousePosNormal;
    [System.Obsolete]
    public bool IsShowInventory = false;
    [System.Obsolete]
    public bool IsShowOutInventory = true;
    public bool IsOnWeatherUI = false;

    public void Update()
    {
        MousePosFind();
        //IsShowInventory = IsMouseOnInventory();
        //IsShowOutInventory = IsMouseOutInventory();
        IsOnWeatherUI = IsMouseOnWeatherUI();
    }
    
    public void MousePosFind()
    {
        MousePos = Input.mousePosition;
        MousePosNormal = new Vector2(MousePos.x / Screen.width, MousePos.y / Screen.height);
    }

    public bool IsPointerOverGameObject()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    [System.Obsolete]
    public bool IsMouseOnInventory()
    {
        if (MousePosNormal.x > 0.25f && MousePosNormal.x < 0.75f && MousePosNormal.y < 0.02f)
            return true;
        return false;
    }
    
    [System.Obsolete]
    public bool IsMouseOutInventory()
    {
        if (!(MousePosNormal.x > 0.25f && MousePosNormal.x < 0.75f && MousePosNormal.y <= 0.5f))
            if (Input.GetMouseButtonDown(0))
                return true;
        return false;
    }

    public bool IsMouseOnWeatherUI()
    {
        bool Button = !(MousePosNormal.x > 0.945f && MousePosNormal.y < 0.84f);
        if (MousePosNormal.x > 0.831f && MousePosNormal.x < 0.976f && MousePosNormal.y > 0.747f && MousePosNormal.y < 0.976f && Button)
            return true;
        return false;
    }
}
