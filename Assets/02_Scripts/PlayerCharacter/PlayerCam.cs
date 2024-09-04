using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.CameraSetting.SetCameraTarget(transform);
        GameManager.Instance.CameraSetting.SetCameraPosLimit_X(-20, 20);
        GameManager.Instance.CameraSetting.SetCameraPosLimit_Y(-20, 20);
    }
}
