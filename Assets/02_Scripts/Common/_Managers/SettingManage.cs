using UnityEngine;

public class SettingManage : MonoBehaviour
{
    public CameraSetting camSet;

    void Awake()
    {
        camSet = gameObject.AddComponent<CameraSetting>();
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
