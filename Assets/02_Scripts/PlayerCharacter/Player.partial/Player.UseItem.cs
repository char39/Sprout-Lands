using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    private KeyCode useKey = KeyCode.C;
    private KeyCode interactKey = KeyCode.X;

    public bool IsNowUse = false;
    public bool IsNowInteractive = false;

    public const int WateringCan = 1;
    public const int Axe = 2;
    public const int Hoe = 3;

    /// <summary> 플레이어의 사용, 상호작용 등 키를 설정함. </summary>
    public void UpdateKeySettings(KeyCode use, KeyCode interact)
    {
        useKey = use;
        interactKey = interact;
    }

    private void OnUseKey()
    {
        if (GameManager.GM.MousePos.IsPointerOverGameObject())
            return;
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(useKey)) && !IsMoveStop)
        {
            IsNowUse = true;
            int nowSlotPos = (int)GameManager.GM.SlotSelect.slotPos;
            List<Item> items = GameManager.GM.Inventory.GetAllItems();
            if (items[nowSlotPos - 1].ID != -1)
            {
                items[nowSlotPos - 1].Use();
                IsMoveStop = true;
            }
        }
    }

    private void StateInfoCheck()
    {
        AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Idle, Walk, Run") && IsNowUse && IsMoveStop)
        {
            IsNowUse = false;
            IsMoveStop = false;
        }
    }

    private void OnInteractiveKey()
    {
        if ((Input.GetMouseButtonDown(1) || Input.GetKeyDown(interactKey)) && !IsNowInteractive)
        {
            IsNowInteractive = true;
            Debug.Log("Pressed Interactive Button");
            IsNowInteractive = false;
        }
    }


    #region 아이템 사용을 위한 호출 함수
    public void SetPlayerUseTool(int itemID)
    {
        ani.SetFloat(ACTION_TYPE, itemID);
        ani.SetTrigger(ACTION_TRIGGER);

        if (itemID == WateringCan)      // 물뿌리개 사용 시 호출
            PlayerUseWateringCan();
        else if (itemID == Hoe)         // 괭이 사용 시 호출
            StartCoroutine(PlayerUseHoe());
    }

    public void SetPlayerUseSeed(int itemID)
    {
        ani.SetFloat(ACTION_TYPE, 4);
        ani.SetTrigger(ACTION_TRIGGER);
        
        UseSeed(itemID);
    }

    private void PlayerUseWateringCan()
    {
        if (IsObjectDetected())
        {
            RaycastHit2D hitCrops = GetFindTileObjectBoxCast(FindTileObjectTr.position, cropsMask, new Vector2(0.2f, 0.2f));
            RaycastHit2D hitWater = GetFindTileObjectBoxCast(FindTileObjectTr.position, waterMask, new Vector2(0.2f, 0.2f));

            if (hitCrops.collider != null && hitCrops.collider.TryGetComponent(out CropsData cropsdata))
                cropsdata.SetWatered(true);
            else if (hitWater.collider != null && hitWater.collider.TryGetComponent(out WaterTile waterTile))
                return;
        }
        water.transform.position = FindTileObjectTr.position;
        water.WaterDropTrigger((int)state);
    }

    private IEnumerator PlayerUseHoe()
    {
        yield return new WaitForSeconds(0.25f);
        if (IsObjectDetected())
        {
            RaycastHit2D hitCrops = GetFindTileObjectBoxCast(FindTileObjectTr.position, cropsMask, new Vector2(0.2f, 0.2f));
            RaycastHit2D hitFarmLand = GetFindTileObjectBoxCast(FindTileObjectTr.position, farmLandMask, new Vector2(0.2f, 0.2f));

            if (hitCrops.collider != null && hitCrops.collider.TryGetComponent(out CropsData cropsdata))
                cropsdata.Hoeing();
            else if (hitFarmLand.collider != null && hitFarmLand.collider.TryGetComponent(out FarmLandTile farmLandTile))
            {
                if (!farmLandTile.isFarmLandObject)
                    farmLandTile.MadeFarmLand(FindTileObjectTr.position);
                else
                    farmLandTile.RemoveFarmLand();
            }
        }
    }




    private void UseSeed(int ID)
    {
        GameObject seedPref = Resources.Load<GameObject>("Object/Crops");
        Vector2 pos = FindTileObjectTr.position;
        GameObject seedObj = Instantiate(seedPref, pos, Quaternion.identity);
        int type = (int)((ID - 1001) * 0.5f);
        seedObj.TryGetComponent(out CropsData cropsData);
        cropsData.SetTypeAndGrowth((ICrops.CropType)type, ICrops.Growth.Sprout);
    }





    #endregion
}