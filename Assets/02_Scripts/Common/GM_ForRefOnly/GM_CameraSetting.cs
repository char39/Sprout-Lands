using UnityEngine;

public class GM_CameraSetting : MonoBehaviour
{
    public Transform MainCam;
    public Transform FollowTarget;

    private float MinX = 0;
    private float MaxX = 0;
    private float MinY = 0;
    private float MaxY = 0;
    private float SetMinX = 0;
    private float SetMaxX = 0;
    private float SetMinY = 0;
    private float SetMaxY = 0;

    private const float ScreenRatio_H = 16;
    private const float ScreenRatio_V = 9;

    internal void CameraFollow()
    {
        if (FollowTarget == null || MainCam == null) return;
        MainCam.position = new Vector3(Mathf.Clamp(FollowTarget.position.x, SetMinX, SetMaxX), Mathf.Clamp(FollowTarget.position.y, SetMinY, SetMaxY), -1);
    }
    internal void ResetCameraPosLimit()
    {
        float AspectRatioV = ScreenRatio_H * MainCam.GetComponent<Camera>().orthographicSize / ScreenRatio_V;
        float AspectRatioH = MainCam.GetComponent<Camera>().orthographicSize;
        SetMinX = MinX + AspectRatioV;
        SetMaxX = MaxX - AspectRatioV;
        SetMinY = MinY + AspectRatioH;
        SetMaxY = MaxY - AspectRatioH;
    }

    /// <summary> 카메라가 따라갈 타겟을 지정함. </summary>
    public void SetCameraTarget(Transform tr) => FollowTarget = tr;
    /// <summary> 카메라의 X축 이동 제한을 설정함. </summary>
    public void SetCameraPosLimit_X(float MinPosX, float MaxPosX)
    {
        MinX = MinPosX;
        MaxX = MaxPosX;
    }
    /// <summary> 카메라의 Y축 이동 제한을 설정함. </summary>
    public void SetCameraPosLimit_Y(float MinPosY, float MaxPosY)
    {
        MinY = MinPosY;
        MaxY = MaxPosY;
    }
}