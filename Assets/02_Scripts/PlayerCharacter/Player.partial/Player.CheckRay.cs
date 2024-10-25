using UnityEngine;
using System.Collections.Generic;

public partial class Player
{
    private LayerMask tileObjectsMask;
    private LayerMask crops;
    private bool isFindObjectCheck = false;

    private RaycastHit2D GetFindTileObjectBoxCast(Vector3 pos, LayerMask mask, Vector2 size) => Physics2D.BoxCast(pos, size, 0, Vector2.zero, 0, mask);

    private void SetFindTileObjectPos()
    {
        List<Item> items = GameManager.GM.Inventory.GetAllItems();
        int idIndex = items[(int)GameManager.GM.SlotSelect.slotPos - 1].ID;
        Item item = items[(int)GameManager.GM.SlotSelect.slotPos - 1];

        // 도구, 농작물 중 소비 아이템이 아닌 경우 (씨앗)
        isFindObjectCheck = (1 <= idIndex && idIndex <= 3) || (item is FarmingPlantItem && !item.IsConsumable);

        if (isFindObjectCheck)
        {
            FindTileObjectTr.GetComponent<SpriteRenderer>().enabled = true;
            FindTileObjectTr.position = SnapToGrid(GetRayOriginPos(pivotTr.position, 0.75f));
        }
        else
        {
            FindTileObjectTr.localPosition = Vector2.zero;
            FindTileObjectTr.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public bool IsObjectDetected()
    {
        if (isFindObjectCheck)
        {
            RaycastHit2D hit = GetFindTileObjectBoxCast(FindTileObjectTr.position, crops, new Vector2(0.5f, 0.5f));
            if (hit.collider != null && hit.collider.TryGetComponent(out CropsData cropsData))
            {
                if (cropsData.Growth == ICrops.Growth.Harvest)
                    return true;
            }

        }
        return false;
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