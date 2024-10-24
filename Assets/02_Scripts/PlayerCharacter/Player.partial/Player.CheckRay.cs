using UnityEngine;
using System.Collections.Generic;

public partial class Player
{
    private LayerMask tileObjectsMask;
    private bool isFindObjectCheck = false;

    private RaycastHit2D GetFindObjectCheck(LayerMask mask, float distance = 1f)
    {
        Vector2 dir = state switch
        {
            State.UP => Vector2.down,
            State.DOWN => Vector2.up,
            State.LEFT => Vector2.right,
            State.RIGHT => Vector2.left,
            _ => Vector2.zero,
        };
        Vector2 origin = GetRayOriginPos(pivotTr.position, distance);
        return Physics2D.BoxCast(origin, new(0.1f, 0.1f), 0, dir, 1, mask);
    }

    public void FindObjectCheck()
    {
        List<Item> items = GameManager.Inventory.GetAllItems();
        int idIndex = items[(int)GameManager.SlotSelect.slotPos - 1].ID;
        Item item = items[(int)GameManager.SlotSelect.slotPos - 1];

        bool FindTileOnCondition = (1 <= idIndex && idIndex <= 3) || (item is FarmingPlantItem && !item.IsConsumable);
        if (FindTileOnCondition)
        {
            isFindObjectCheck = true;
            FindTileObjectTr.GetComponent<SpriteRenderer>().enabled = true;
            float distance;
            if (idIndex == 2) distance = 0.75f;
            else if (idIndex == 3) distance = 0.75f;
            else distance = 0.75f;
            FindTileObjectTr.position = SnapToGrid(GetRayOriginPos(pivotTr.position, distance));
        }
        else
        {
            isFindObjectCheck = false;
            FindTileObjectTr.localPosition = new Vector2(0, 0);
            FindTileObjectTr.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private Vector2 SnapToGrid(Vector2 original)
    {
        float x = Mathf.Floor(original.x) + 0.5f;
        float y = Mathf.Floor(original.y) + 0.5f;
        return new Vector2(x, y);
    }



    private void DrawFindObjectCheck()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(GetRayOriginPos(pivotTr.position, 0.75f), 0.1f);
    }
}