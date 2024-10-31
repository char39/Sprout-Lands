using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM GAME;
    public static SceneManage SCENE;
    public static UIManage UI;
    public static SettingManage SETTING;
    public static ProcessManage PROCESS;
    public static DataManage DATA;
    public static SoundManage SOUND;
    
    void Awake()
    {
        GAME = this;
        SCENE = transform.GetComponentInChildren<SceneManage>();
        UI = transform.GetComponentInChildren<UIManage>();
        SETTING = transform.GetComponentInChildren<SettingManage>();
        PROCESS = transform.GetComponentInChildren<ProcessManage>();
        DATA = transform.GetComponentInChildren<DataManage>();
        SOUND = transform.GetComponentInChildren<SoundManage>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))    // 아이템 삭제 테스트용 추후 삭제
            DATA.inven.RemoveItem(ItemManager.GetToolItem(4), 5);
    }
}
