using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetCameraTarget(transform);
        GameManager.Instance.SetCameraPosLimit_X(-20, 20);
        GameManager.Instance.SetCameraPosLimit_Y(-20, 20);
    }
}
