using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public static GameManager instance { get { return Instance; } }
    public Transform MainCam;
    public Transform FollowTarget;

    private float MinX = 0;
    private float MaxX = 0;
    private float MinY = 0;
    private float MaxY = 0;

    private const float ScreenRatio_H = 16;
    private const float ScreenRatio_V = 9;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        MainCam = Camera.main.transform;
    }

    void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        if (FollowTarget == null || MainCam == null) return;
        MainCam.position = new Vector3(Mathf.Clamp(FollowTarget.position.x, MinX, MaxX), Mathf.Clamp(FollowTarget.position.y, MinY, MaxY), -10);
    }

    public void SetCameraTarget(Transform tr) => FollowTarget = tr;
    public void SetCameraPosLimit_X(float MinPosX, float MaxPosX)
    {
        float AspectRatio = ScreenRatio_H * MainCam.GetComponent<Camera>().orthographicSize / ScreenRatio_V;
        if (MinPosX + AspectRatio > MaxPosX - AspectRatio)
            throw new ArgumentOutOfRangeException("MinPosX는 MaxPosX보다 클 수 없습니다.");
        MinX = MinPosX + AspectRatio;
        MaxX = MaxPosX - AspectRatio;
    }
    public void SetCameraPosLimit_Y(float MinPosY, float MaxPosY)
    {
        float AspectRatio = MainCam.GetComponent<Camera>().orthographicSize;
        if (MinPosY + AspectRatio > MaxPosY - AspectRatio)
            throw new ArgumentOutOfRangeException("MinPosY는 MaxPosY보다 클 수 없습니다.");
        MinY = MinPosY + AspectRatio;
        MaxY = MaxPosY - AspectRatio; 
    }

}
