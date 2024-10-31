using UnityEngine;

public class SettingManage : MonoBehaviour
{
    public GM_CameraSetting camSet;

    void Awake()
    {
        camSet = gameObject.AddComponent<GM_CameraSetting>();
    }

    void Start()
    {
        camSet.MainCam = Camera.main.transform;
    }

    void LateUpdate()
    {
        camSet.ResetCameraPosLimit();
        camSet.CameraFollow();
    }
}
