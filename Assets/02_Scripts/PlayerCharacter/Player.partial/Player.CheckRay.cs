using UnityEngine;
using System.Collections.Generic;

public partial class Player
{
    private bool isFindObjectCheck = false;

    private RaycastHit2D GetFindTileObjectBoxCast(Vector3 pos, LayerMask mask, Vector2 size) => Physics2D.BoxCast(pos, size, 0, Vector2.zero, 0, mask);

    private List<Item> GetItems() => GameManager.GM.Inventory.GetAllItems();
    private int GetSelectedSlotNow() => GetItems()[(int)GameManager.GM.SlotSelect.slotPos - 1].ID;
    private bool IsSelecctedSlotNowIdSame(int id) => GetSelectedSlotNow() == id;

    private void SetFindTileObjectPos()
    {
        int idIndex = GetSelectedSlotNow();
        Item item = GetItems()[(int)GameManager.GM.SlotSelect.slotPos - 1];

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
            RaycastHit2D hitCrops = GetFindTileObjectBoxCast(FindTileObjectTr.position, cropsMask, new Vector2(0.2f, 0.2f));
            RaycastHit2D hitWater = GetFindTileObjectBoxCast(FindTileObjectTr.position, waterMask, new Vector2(0.2f, 0.2f));
            RaycastHit2D hitFarmLand = GetFindTileObjectBoxCast(FindTileObjectTr.position, farmLandMask, new Vector2(0.2f, 0.2f));
            
            if (IsSelecctedSlotNowIdSame(1))            // 물뿌리개를 들고 있을 때
            {
                if (hitCrops.collider != null && hitCrops.collider.TryGetComponent(out CropsData cropsData))      // 물뿌리개로 물을 줄 수 있는 농작물
                    return cropsData.IsWatered == false;
                else if (hitWater.collider != null && hitWater.collider.TryGetComponent(out WaterTile waterTile)) // 물뿌리개에 물을 채울 수 있는 물타일
                    return true;
            }
            else if (IsSelecctedSlotNowIdSame(2))       // 도끼를 들고 있을 때
            {

            }
            else if (IsSelecctedSlotNowIdSame(3))       // 괭이를 들고 있을 때
            {
                if (hitCrops.collider != null && hitCrops.collider.TryGetComponent(out CropsData cropsData))
                    return true;
                else if (hitFarmLand.collider != null && hitFarmLand.collider.TryGetComponent(out FarmLandTile farmLandTile))
                    return true;
            }
            else                                        // 씨앗을 들고 있을 때
            {
                if (hitFarmLand.collider != null && hitFarmLand.collider.TryGetComponent(out FarmLandTile farmLandTile) && farmLandTile.isFarmLandObject)
                    if (hitCrops.collider != null && hitCrops.collider.TryGetComponent(out CropsData cropsData))
                        return false;
                    else
                        return true;
            }
        }
        return false;
    }

    public bool IsWaterDetected()
    {
        if (isFindObjectCheck && IsSelecctedSlotNowIdSame(1))       // 물뿌리개를 들고 있을 때
        {
            RaycastHit2D hit = GetFindTileObjectBoxCast(FindTileObjectTr.position, waterMask, new Vector2(0.2f, 0.2f));
            if (hit.collider != null && hit.collider.TryGetComponent(out WaterTile waterTile))
                return true;
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