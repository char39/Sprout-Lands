using UnityEngine;

public class MousePointing : MonoBehaviour
{
    public Collider2D[] col;

    void Update()
    {
        if (col == null || Mouse.Instance == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        bool isPointing = false;
        if (hit.collider != null)
        {
            foreach (var collider in col)
            {
                if (hit.collider == collider)
                {
                    isPointing = true;
                    break;
                }
            }
        }

        //Mouse.Instance.IsPointing = isPointing;
    }
}