using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    void Start()
    {
        GameManager.GM.cameraSetting.SetCameraTarget(transform);
        GameManager.GM.cameraSetting.SetCameraPosLimit_X(-20, 20);
        GameManager.GM.cameraSetting.SetCameraPosLimit_Y(-20, 20);
    }
}
