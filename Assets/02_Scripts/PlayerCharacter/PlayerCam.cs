using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    void Start()
    {
        GameManager.GM.CameraSetting.SetCameraTarget(transform);
        GameManager.GM.CameraSetting.SetCameraPosLimit_X(-20, 20);
        GameManager.GM.CameraSetting.SetCameraPosLimit_Y(-20, 20);
    }
}
