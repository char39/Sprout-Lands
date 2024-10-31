using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    void Start()
    {
        GM.SETTING.camSet.SetCameraTarget(transform);
        GM.SETTING.camSet.SetCameraPosLimit_X(-20, 20);
        GM.SETTING.camSet.SetCameraPosLimit_Y(-20, 20);
    }
}
