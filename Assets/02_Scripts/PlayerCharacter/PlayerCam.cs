using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    void Start()
    {
        GameManager.CameraSetting.SetCameraTarget(transform);
        GameManager.CameraSetting.SetCameraPosLimit_X(-20, 20);
        GameManager.CameraSetting.SetCameraPosLimit_Y(-20, 20);
    }
}
