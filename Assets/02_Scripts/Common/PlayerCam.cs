using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.SetCameraTarget(transform);
        GameManager.instance.SetCameraPosLimit_X(-20, 20);
        GameManager.instance.SetCameraPosLimit_Y(-20, 20);
    }
}
