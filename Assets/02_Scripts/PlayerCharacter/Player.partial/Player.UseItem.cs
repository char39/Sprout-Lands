using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    private KeyCode useKey = KeyCode.C;
    private KeyCode interactKey = KeyCode.X;

    public bool IsNowUse = false;
    public bool IsNowInteractive = false;

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
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(useKey)) && !IsNowUse)
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
        if (stateInfo.IsName("Idle, Walk, Run"))
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
    public void SetPlayerUseTool(int actionIndex)
    {
        ani.SetFloat(ACTION_TYPE, actionIndex);
        ani.SetTrigger(ACTION_TRIGGER);
    }

    public void UseSeed(int ID)
    {
        GameObject seedPref = Resources.Load<GameObject>("Object/Crops");
        Vector2 pos = SnapToGrid(GetRayOriginPos(pivotTr.position, 0.75f));
        GameObject seed = Instantiate(seedPref, pos, Quaternion.identity);
        Debug.Log($"Seed ID : {ID} 사용. 위치 : {pos}");
    }





    #endregion
}